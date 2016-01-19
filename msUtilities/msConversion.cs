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

  }
}
