using System;

namespace _01_Framework.Tools
{
    public class DateTools
    {
        public static bool DateChecker(DateTime dateStart, DateTime dateEnd)
        {
            var dateNow = DateTime.Now;
            dateNow = dateNow.Date;

            return dateEnd > dateNow && dateNow >= dateStart;
        }
    }

    public class DiscountOperation
    {
        public static bool DiscountStatus(DateTime startDate, DateTime endDate, bool status)
        {
            return DateTools.DateChecker(startDate, endDate) && status;
        }
    }
}

