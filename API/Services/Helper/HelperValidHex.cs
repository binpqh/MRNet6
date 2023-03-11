using System.Text.RegularExpressions;

namespace Services.Helper
{
    public static class HelperValidHex
    {
        public static bool Check(string hex)
        {
            bool isHex = Regex.IsMatch(hex, @"\A\b[0-9a-fA-F]+\b\Z");
            return isHex;
        }
    }
}
