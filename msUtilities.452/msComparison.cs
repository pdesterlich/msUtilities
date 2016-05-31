using System;

namespace msUtilities
{
  /// <summary>
  /// repository for comparison functions
  /// </summary>
  public static class msComparison
  {
    /// <summary>
    /// check if a DateTime value is in a range
    /// </summary>
    /// <param name="value">value to check</param>
    /// <param name="min">range lower limit</param>
    /// <param name="max">range upper limi</param>
    /// <param name="InsideOnly">if true, value must not be equal to upper or lower limit (default false)</param>
    /// <returns>true if value is between limits, false otherwise</returns>
    public static bool Between(DateTime value, DateTime min, DateTime max, bool InsideOnly = false)
    {
      if (InsideOnly)
      {
        return (value > min && value < max);
      }
      else
      {
        return (value >= min && value <= max);
      }
    }

    /// <summary>
    /// check if an int value is in a range
    /// </summary>
    /// <param name="value">value to check</param>
    /// <param name="min">range lower limit</param>
    /// <param name="max">range upper limi</param>
    /// <param name="InsideOnly">if true, value must not be equal to upper or lower limit (default false)</param>
    /// <returns>true if value is between limits, false otherwise</returns>
    public static bool Between(int value, int min, int max, bool InsideOnly = false)
    {
      if (InsideOnly)
      {
        return (value > min && value < max);
      }
      else
      {
        return (value >= min && value <= max);
      }
    }
  }
}
