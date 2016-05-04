using System;
using System.Collections.Generic;
using System.Text;

namespace msUtilities
{
  public class msYear
  {
    public DateTime startDate;
    public DateTime endDate;

    /// <summary>
    /// creates a new msYear object for the current year
    /// </summary>
    public msYear()
    {
      this.startDate = msDateHelpers.startOfYear(DateTime.Now);
      this.endDate = msDateHelpers.endOfYear(DateTime.Now);
    }

    /// <summary>
    /// creates a new msYear object for the year containing the date
    /// </summary>
    /// <param name="date">date within the year</param>
    public msYear(DateTime date)
    {
      this.startDate = msDateHelpers.startOfYear(date);
      this.endDate = msDateHelpers.endOfYear(date);
    }

    /// <summary>
    /// returns a string representing the year
    /// </summary>
    /// <returns>String year (format: yyyy)</returns>
    public override string ToString()
    {
      return this.startDate.ToString("yyyy");
    }

    #region ricerca

    public override bool Equals(object obj)
    {
      msYear other = obj as msYear;
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
    /// returns a list of msYear object for a range before and after current year
    /// </summary>
    /// <param name="before">number of years before current year</param>
    /// <param name="after">number of years after current year</param>
    /// <returns>List<msYear> list of msYear</returns>
    public static List<msYear> yearsList(int before, int after)
    {
      List<msYear> lista = new List<msYear>();

      DateTime data = msDateHelpers.startOfYear(DateTime.Now);
      data = data.AddYears(-before);

      for (int i = 0; i <= (before + after); i++)
      {
        msYear anno = new msYear(data);

        lista.Add(anno);

        data = data.AddYears(1);
      }
      return lista;
    }

  }
}
