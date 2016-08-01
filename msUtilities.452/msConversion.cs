using System;
using System.Globalization;

namespace msUtilities
{
    /// <summary>
    /// repository for conversion functions
    /// </summary>
    public static class MsConversion
    {
        /// <summary>
        /// converts a c# DateTime object to a Unix TimeStamp
        /// </summary>
        /// <param name="sourceDate">datetime object to convert</param>
        /// <returns>unix timestamp representing the original datetime object</returns>
#if NET20
        public static double DateTimeToUnixTimestamp(DateTime sourceDate)
#else
        public static double DateTimeToUnixTimestamp(this DateTime sourceDate)
#endif
        {
            return Math.Truncate((sourceDate - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds);
        }

        /// <summary>
        /// converts a string into an int value, with a default in case of errors
        /// </summary>
        /// <param name="value">string value to convert</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>int converted value</returns>
#if NET20
        public static int StringToInt(string value, int defaultValue)
#else
        public static int StringToInt(this string value, int defaultValue)
#endif
        {
            int j;
            return int.TryParse(value, out j) ? j : defaultValue;
        }

        /// <summary>
        /// converts a string into a float value, with a default in case of errors
        /// </summary>
        /// <param name="value">string value to convert</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>float converted value</returns>
#if NET20
        public static float StringToFloat(string value, float defaultValue)
#else
        public static float StringToFloat(this string value, float defaultValue)
#endif
        {
            float j;

            value = value.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            value = value.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            return float.TryParse(value, out j) ? j : defaultValue;
        }

        /// <summary>
        /// converts an integer representation of time (minutes elapsed from midnight) in a DateTime value
        /// </summary>
        /// <param name="minutes">number of minutes elapsed from midnight</param>
        /// <param name="date">reference date (default today)</param>
        /// <returns>datetime</returns>
        public static DateTime MinutesToDateTime(int minutes, DateTime date = default(DateTime))
        {
            if (date == DateTime.MinValue) date = DateTime.Now;
            return new DateTime(date.Year, date.Month, date.Day, minutes / 60, minutes % 60, 0);
        }
    }
}