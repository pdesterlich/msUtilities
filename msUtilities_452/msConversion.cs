using System;

namespace msUtilities
{
  public class msConversion
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
      if (float.TryParse(value, out j))
        return j;
      else
        return defaultValue;
    }
  }
}