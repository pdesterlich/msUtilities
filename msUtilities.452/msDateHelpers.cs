using System;

namespace msUtilities
{
  public static class msDateHelpers
  {
    /// <summary>
    /// returns the first day of month containing the specified date
    /// </summary>
    /// <param name="date">date inside the month</param>
    /// <returns>DateTime first day of month</returns>
    public static DateTime startOfMonth(DateTime date)
    {
      return date.AddDays(-(date.Day - 1)).Date;
    }

    /// <summary>
    /// returns the last day of month containing the specified date
    /// </summary>
    /// <param name="date">date inside the month</param>
    /// <returns>DateTime last day of month</returns>
    public static DateTime endOfMonth(DateTime date)
    {
      return date.AddDays(-(date.Day - 1)).AddMonths(1).AddDays(-1).Date;
    }

    /// <summary>
    /// returns the first day of year containing the specified date
    /// </summary>
    /// <param name="date">date inside the year</param>
    /// <returns>DateTime first day of year</returns>
    public static DateTime startOfYear(DateTime date)
    {
      int year = date.Year;
      return new DateTime(year, 1, 1).Date;
    }

    /// <summary>
    /// returns the last day of year containing the specified date
    /// </summary>
    /// <param name="date">date inside the year</param>
    /// <returns>DateTime last day of year</returns>
    public static DateTime endOfYear(DateTime date)
    {
      int year = date.Year;
      return new DateTime(year, 12, 31).Date;
    }

    /// <summary>
    /// return the lowest date from a group of dates
    /// </summary>
    /// <param name="list">list of dates to parse</param>
    /// <returns>DateTime lowest date</returns>
    public static DateTime minDate(params DateTime[] list)
    {
      DateTime result = DateTime.Today.AddYears(100);
      foreach (DateTime data in list)
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
    public static DateTime maxDate(params DateTime[] list)
    {
      DateTime refDate = DateTime.Today.AddYears(-100);
      DateTime result = DateTime.Today.AddYears(-100);
      foreach (DateTime data in list)
      {
        if ((data > refDate) && (data > result)) result = data;
      }
      return result;
    }

  }
}
