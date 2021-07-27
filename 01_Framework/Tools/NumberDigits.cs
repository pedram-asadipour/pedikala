using System.Collections.Generic;
using System.Linq;

namespace _01_Framework.Tools
{
    public static class NumberDigits
    {
        public static string ToEnglishDigits(this string persianString)
        {
            Dictionary<string, string> lettersDictionary = new Dictionary<string, string>
            {
                ["۰"] = "0",
                ["۱"] = "1",
                ["۲"] = "2",
                ["۳"] = "3",
                ["۴"] = "4",
                ["۵"] = "5",
                ["۶"] = "6",
                ["۷"] = "7",
                ["۸"] = "8",
                ["۹"] = "9"
            };
            return lettersDictionary.Aggregate(persianString, (current, item) =>
                current.Replace(item.Key, item.Value));
        }

        //public static string ToPersianDigits(this string englishString)
        //{
        //    Dictionary<string, string> lettersDictionary = new Dictionary<string, string>
        //    {
        //        ["0"] = "۰",
        //        ["1"] = "۱",
        //        ["2"] = "۲",
        //        ["3"] = "۳",
        //        ["4"] = "۴",
        //        ["5"] = "۵",
        //        ["6"] = "۶",
        //        ["7"] = "۷",
        //        ["8"] = "۸",
        //        ["9"] = "۹"
        //    };
        //    return lettersDictionary.Aggregate(englishString, (current, item) =>
        //        current.Replace(item.Key, item.Value));
        //}
    }
}