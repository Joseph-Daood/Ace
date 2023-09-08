using System.Globalization;
using System.Text.RegularExpressions;

namespace Isg.Shared.Extensions
{
    public static class StringExtensions
    {
        public static void Save(this string contents, string path)
        {
            File.WriteAllText(path, contents);
        }

        public static string ReplaceLast(this string str, string find, string replace)
        {
            int lastIndex = str.LastIndexOf(find);

            if (lastIndex == -1)
            {
                return str;
            }

            string beginString = str.Substring(0, lastIndex);
            string endString = str.Substring(lastIndex + find.Length);

            return beginString + replace + endString;
        }

        public static DateTime GetTimeStamp(this string str)
        {
            var timeStampMatch = Regex.Match(str, @"_(\d{8}-\d{6})");
            if (!timeStampMatch.Success)
            {
                throw new FormatException($"{str} does not contain a valid timestamp (yyyyMMdd-HHmmss).");
            }
            return DateTime.ParseExact(timeStampMatch.Groups[1].Value, "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
        }

        public static bool IsOneOf(this string str, params string[] list)
        {
            return list.Contains(str);
        }
    }
}
