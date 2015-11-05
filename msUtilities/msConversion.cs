using System;

namespace msUtilities
{
  public class msConversion
  {

    /**
     * converts a c# DateTime object to a Unix TimeStamp
     *
     * @param  DateTime sourceDate datetime ojbect to convert
     * @output double              unit timestamp representingthe original datetime object
     **/
    public static double DateTimeToUnixTimestamp(DateTime sourceDate)
    {
      return Math.Truncate((sourceDate - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds);
    }

  }
}
