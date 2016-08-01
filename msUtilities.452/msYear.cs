using System;
using System.Collections.Generic;

namespace msUtilities
{
    public class MsYear
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        /// <summary>
        /// creates a new msYear object for the current year
        /// </summary>
        public MsYear()
        {
#if NET20
            StartDate = MsDateHelpers.StartOfYear(DateTime.Now);
            EndDate = MsDateHelpers.EndOfYear(DateTime.Now);
#else
            StartDate = DateTime.Now.StartOfYear();
            EndDate = DateTime.Now.EndOfYear();
#endif
        }

        /// <summary>
        /// creates a new msYear object for the year containing the date
        /// </summary>
        /// <param name="date">date within the year</param>
        public MsYear(DateTime date)
        {
#if NET20
            StartDate = MsDateHelpers.StartOfYear(date);
            EndDate = MsDateHelpers.EndOfYear(date);
#else
            StartDate = date.StartOfYear();
            EndDate = date.EndOfYear();
#endif
        }

        /// <summary>
        /// returns a string representing the year
        /// </summary>
        /// <returns>String year (format: yyyy)</returns>
        public override string ToString()
        {
            return StartDate.ToString("yyyy");
        }

        #region ricerca

        public override bool Equals(object obj)
        {
            var other = obj as MsYear;
            if (other == null)
                return false;
            return (StartDate == other.StartDate);
        }

        public override int GetHashCode()
        {
            return StartDate.GetHashCode() + EndDate.GetHashCode();
        }

        #endregion

        /// <summary>
        /// returns a list of msYear object for a range before and after current year
        /// </summary>
        /// <param name="before">number of years before current year</param>
        /// <param name="after">number of years after current year</param>
        /// <returns>list of msYear</returns>
        public static List<MsYear> YearsList(int before, int after)
        {
            var lista = new List<MsYear>();

#if NET20
            var data = MsDateHelpers.StartOfYear(DateTime.Now);
#else
            var data = DateTime.Now.StartOfYear();
#endif
            data = data.AddYears(-before);

            for (var i = 0; i <= (before + after); i++)
            {
                var anno = new MsYear(data);

                lista.Add(anno);

                data = data.AddYears(1);
            }
            return lista;
        }

    }
}
