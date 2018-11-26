namespace System.Text
{
    public static class StringBuilderExt
    {
        public static void Clear(this StringBuilder builder)
        {
            builder.Remove(0, builder.Length);
        }
    }
}