using System;

namespace msUtilities
{
    public static class MsDateHelpers
    {
        /// <summary>
        /// returns the first day of month containing the specified date
        /// </summary>
        /// <param name="date">date inside the month</param>
        /// <returns>DateTime first day of month</returns>
#if NET20
        public static DateTime StartOfMonth(DateTime date)
#else
        public static DateTime StartOfMonth(this DateTime date)
#endif
        {
            return date.AddDays(-(date.Day - 1)).Date;
        }

        /// <summary>
        /// returns the last day of month containing the specified date
        /// </summary>
        /// <param name="date">date inside the month</param>
        /// <returns>DateTime last day of month</returns>
#if NET20
        public static DateTime EndOfMonth(DateTime date)
#else
        public static DateTime EndOfMonth(this DateTime date)
#endif
        {
            return date.AddDays(-(date.Day - 1)).AddMonths(1).AddDays(-1).Date;
        }

        /// <summary>
        /// returns the first day of year containing the specified date
        /// </summary>
        /// <param name="date">date inside the year</param>
        /// <returns>DateTime first day of year</returns>
#if NET20
        public static DateTime StartOfYear(DateTime date)
#else
        public static DateTime StartOfYear(this DateTime date)
#endif
        {
            var year = date.Year;
            return new DateTime(year, 1, 1).Date;
        }

        /// <summary>
        /// returns the last day of year containing the specified date
        /// </summary>
        /// <param name="date">date inside the year</param>
        /// <returns>DateTime last day of year</returns>
#if NET20
        public static DateTime EndOfYear(DateTime date)
#else
        public static DateTime EndOfYear(this DateTime date)
#endif
        {
            var year = date.Year;
            return new DateTime(year, 12, 31).Date;
        }

        /// <summary>
        /// return the lowest date from a group of dates
        /// </summary>
        /// <param name="list">list of dates to parse</param>
        /// <returns>DateTime lowest date</returns>
        public static DateTime MinDate(params DateTime[] list)
        {
            var result = DateTime.Today.AddYears(100);
            foreach (var data in list)
            {
                if (data < result) result = data;
            }
            return result;
        }

        /// <summary>
        /// return the highest date from a group of dates
        /// </summary>
        /// <param name="list">list of dates to parse</param>
        /// <returns>DateTime highest date</returns>
        public static DateTime MaxDate(params DateTime[] list)
        {
            var refDate = DateTime.Today.AddYears(-100);
            var result = DateTime.Today.AddYears(-100);
            foreach (var data in list)
            {
                if ((data > refDate) && (data > result)) result = data;
            }
            return result;
        }

    }
}
