using System;
using System.Collections.Generic;
using System.Text;
using ExCSS.Model;
using ExCSS.Model.Extensions;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public sealed class DocumentRule : AggregateRule
    {
        readonly List<DocumentCondition> _conditions;

        internal DocumentRule()
        { 
            RuleType = RuleType.Document;
            _conditions = new List<DocumentCondition>();
        }

        public string ConditionText
        {
            get
            {
                var builder = new StringBuilder();
                var concat = false;

                foreach (var condition in _conditions)
                {
                    if (concat)
                    {
                        builder.Append(',');
                    }

                    switch (condition.Type)
                    {
                        case DocumentFunction.Url:
                            builder.Append("url");
                            break;

                        case DocumentFunction.UrlPrefix:
                            builder.Append("url-prefix");
                            break;

                        case DocumentFunction.Domain:
                            builder.Append("domain");
                            break;

                        case DocumentFunction.RegExp:
                            builder.Append("regexp");
                            break;
                    }

                    builder.Append(Specification.ParenOpen);
                    builder.Append(Specification.DoubleQuote);
                    builder.Append(condition.Value);
                    builder.Append(Specification.DoubleQuote);
                    builder.Append(Specification.ParenClose);
                    concat = true;
                }

                return builder.ToString();
            }
        }

        internal List<DocumentCondition> Conditions
        {
            get { return _conditions; }
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public override string ToString(bool friendlyFormat, int indentation = 0)
        {
            return "@document " + ConditionText + " {" + 
                RuleSets + 
                "}".NewLineIndent(friendlyFormat, indentation);
        }
    }

    internal sealed class DocumentCondition
    {
        public readonly DocumentFunction Type;

        public readonly string Value;

        public DocumentCondition(DocumentFunction type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
