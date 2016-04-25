using System;
using System.Globalization;
using System.Windows.Forms;

namespace msUtilities
{
  /// <summary>
  /// repository for conversion functions
  /// </summary>
  public static class msConversion
  {
    /// <summary>
    /// converts a c# DateTime object to a Unix TimeStamp
    /// </summary>
    /// <param name="sourceDate">datetime object to convert</param>
    /// <returns>unix timestamp representing the original datetime object</returns>
    public static double DateTimeToUnixTimestamp(DateTime sourceDate)
    {
      return Math.Truncate((sourceDate - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds);
    }

    /// <summary>
    /// converts a string into an int value, with a default in case of errors
    /// </summary>
    /// <param name="value">string value to convert</param>
    /// <param name="defaultValue">default value</param>
    /// <returns>int converted value</returns>
    public static int stringToInt(String value, int defaultValue)
    {
      int j;
      if (int.TryParse(value, out j))
        return j;
      else
        return defaultValue;
    }

    /// <summary>
    /// converts a string into a float value, with a default in case of errors
    /// </summary>
    /// <param name="value">string value to convert</param>
    /// <param name="defaultValue">default value</param>
    /// <returns>float converted value</returns>
    public static float stringToFloat(String value, float defaultValue)
    {
      float j;

      value = value.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
      value = value.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

      if (float.TryParse(value, out j))
        return j;
      else
        return defaultValue;
    }

    /// <summary>
    /// converts an integer representation of time (minutes elapsed from midnight) in a DateTime value
    /// </summary>
    /// <param name="minutes">number of minutes elapsed from midnight</param>
    /// <param name="date">reference date (default today)</param>
    /// <returns>datetime</returns>
    public static DateTime minutesToDateTime(int minutes, DateTime date = default(DateTime))
    {
      if (date == DateTime.MinValue) date = DateTime.Now;
      return new DateTime(date.Year, date.Month, date.Day, minutes / 60, minutes % 60, 0);
    }
  }
}