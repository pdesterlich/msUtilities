using System;
using System.Reflection;

namespace msUtilities
{
  public class msUtilities
  {
    /// <summary>
    /// returns current application version
    /// </summary>
    /// <param name="fieldCount">number of fields to return - default 3 (major.minor.build)</param>
    /// <returns>string</returns>
    public static string getAppVersion(int fieldCount = 3)
    {
      Version version = Assembly.GetExecutingAssembly().GetName().Version;
      return version.ToString(fieldCount);
    }
  }
}
