using System;
using System.Collections.Generic;

namespace msUtilities
{
  public class msMonth
  {
    public DateTime startDate;
    public DateTime endDate;

    /// <summary>
    /// creates a new msMonth object for the current month
    /// </summary>
    public msMonth()
    {
      this.startDate = msDateHelpers.startOfMonth(DateTime.Now);
      this.endDate = msDateHelpers.endOfMonth(DateTime.Now);
    }

    /// <summary>
    /// creates a new msMonth object for the month containing the date
    /// </summary>
    /// <param name="date">date within the month</param>
    public msMonth(DateTime date)
    {
      this.startDate = msDateHelpers.startOfMonth(date);
      this.endDate = msDateHelpers.endOfMonth(date);
    }

    /// <summary>
    /// returns a string representing the month
    /// </summary>
    /// <returns>String month (format: MMMM yyyy)</returns>
    public override string ToString()
    {
      return this.startDate.ToString("MMMM yyyy");
    }

    #region ricerca

    public override bool Equals(object obj)
    {
      msMonth other = obj as msMonth;
      if (other == null)
        return false;
      else
        return (this.startDate == other.startDate);
    }

    public override int GetHashCode()
    {
      return startDate.GetHashCode() + endDate.GetHashCode();
    }

    #endregion

    /// <summary>
    /// returns a list of msMonth object for a range before and after current month
    /// </summary>
    /// <param name="before">number of months before current month</param>
    /// <param name="after">number of months after current month</param>
    /// <returns>List<msMonth> list of msMonth</returns>
    public static List<msMonth> monthsList(int before, int after)
    {
      List<msMonth> lista = new List<msMonth>();

      DateTime data = msDateHelpers.startOfMonth(DateTime.Now);
      data = data.AddMonths(-before);

      for (int i = 0; i <= (before + after); i++)
      {
        msMonth mese = new msMonth(data);

        lista.Add(mese);

        data = data.AddMonths(1);
      }
      return lista;
    }

  }
}
