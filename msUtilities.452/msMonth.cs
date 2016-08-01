using System;
using System.Collections.Generic;

namespace msUtilities
{
    public class MsMonth
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        /// <summary>
        /// creates a new msMonth object for the current month
        /// </summary>
        public MsMonth()
        {
#if NET20
            StartDate = MsDateHelpers.StartOfMonth(DateTime.Now);
            EndDate = MsDateHelpers.EndOfMonth(DateTime.Now);
#else
            StartDate = DateTime.Now.StartOfMonth();
            EndDate = DateTime.Now.EndOfMonth();
#endif
        }

        /// <summary>
        /// creates a new msMonth object for the month containing the date
        /// </summary>
        /// <param name="date">date within the month</param>
        public MsMonth(DateTime date)
        {
#if NET20
            StartDate = MsDateHelpers.StartOfMonth(date);
            EndDate = MsDateHelpers.EndOfMonth(date);
#else
            StartDate = date.StartOfMonth();
            EndDate = date.EndOfMonth();
#endif
        }

        /// <summary>
        /// returns a string representing the month
        /// </summary>
        /// <returns>String month (format: MMMM yyyy)</returns>
        public override string ToString()
        {
            return StartDate.ToString("MMMM yyyy");
        }

        #region ricerca

        public override bool Equals(object obj)
        {
            var other = obj as MsMonth;
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
        /// returns a list of msMonth object for a range before and after current month
        /// </summary>
        /// <param name="before">number of months before current month</param>
        /// <param name="after">number of months after current month</param>
        /// <returns>list of MsMonth</returns>
        public static List<MsMonth> MonthsList(int before, int after)
        {
            var lista = new List<MsMonth>();

#if NET20
            var data = MsDateHelpers.StartOfMonth(DateTime.Now);
#else
            var data = DateTime.Now.StartOfMonth();
#endif
            data = data.AddMonths(-before);

            for (var i = 0; i <= (before + after); i++)
            {
                var mese = new MsMonth(data);

                lista.Add(mese);

                data = data.AddMonths(1);
            }
            return lista;
        }

    }
}
