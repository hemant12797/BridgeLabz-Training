namespace StringTesting
{
    public class StringUtils
    {
        public string Reverse(string value)
        {
            if (value == null)
                return null;

            char[] chars = value.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public bool IsPalindrome(string value)
        {
            if (value == null)
                return false;

            string reversed = Reverse(value);
            return value.Equals(reversed, StringComparison.Ordinal);
        }

        public string ToUpperCase(string value)
        {
            if (value == null)
                return null;

            return value.ToUpper();
        }
    }
}
