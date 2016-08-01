using System;

namespace msUtilities
{
    /// <summary>
    /// repository for comparison functions
    /// </summary>
    public static class MsComparison
    {
        /// <summary>
        /// check if a DateTime value is in a range
        /// </summary>
        /// <param name="value">value to check</param>
        /// <param name="min">range lower limit</param>
        /// <param name="max">range upper limi</param>
        /// <param name="insideOnly">if true, value must not be equal to upper or lower limit (default false)</param>
        /// <returns>true if value is between limits, false otherwise</returns>
        public static bool Between(DateTime value, DateTime min, DateTime max, bool insideOnly = false)
        {
            return insideOnly ? value > min && value < max : value >= min && value <= max;
        }

        /// <summary>
        /// check if an int value is in a range
        /// </summary>
        /// <param name="value">value to check</param>
        /// <param name="min">range lower limit</param>
        /// <param name="max">range upper limi</param>
        /// <param name="insideOnly">if true, value must not be equal to upper or lower limit (default false)</param>
        /// <returns>true if value is between limits, false otherwise</returns>
        public static bool Between(int value, int min, int max, bool insideOnly = false)
        {
            return insideOnly ? value > min && value < max : value >= min && value <= max;
        }
    }
}
