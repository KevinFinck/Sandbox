namespace TestingLibrary
{
    public static class MyExtensions
    {
        public static string MyPadLeft(this string value, int len)
        {
            if (value == null)
                return "It's null you ninny.";

            return value.PadLeft(len);
        }
    }
}
