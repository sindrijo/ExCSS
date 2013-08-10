﻿
namespace ExCSS.Model
{
    abstract class CharacterBlock : Block
    {
        private readonly char _value;

        protected CharacterBlock()
        {
            _value = Specification.NULL;
        }

        protected CharacterBlock(char value)
        {
            _value = value;
        }

        public char Value
        {
            get { return _value; }
        }
    }
}