using System;
using System.Globalization;

namespace _01_Framework.Tools
{
    public static class DateConvention
    {
        public static string ToPersianDate(this DateTime date)
        {
            var persianCalender = new PersianCalendar();
            return $"{persianCalender.GetYear(date)}/{persianCalender.GetMonth(date)}/{persianCalender.GetDayOfMonth(date)}";
        }

        public static DateTime ToGregorianDate(this string persianDate)
        {
            var date = persianDate.Split("/");
            var year = int.Parse(date[0].ToEnglishDigits());
            var month = int.Parse(date[1].ToEnglishDigits());
            var day = int.Parse(date[2].ToEnglishDigits());

            return new DateTime(year,month,day, new PersianCalendar());
        }
    }
}