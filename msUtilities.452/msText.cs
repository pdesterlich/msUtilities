using System;
using System.Text;

namespace msUtilities
{
    public static class MsText
    {
        /// <summary>
        /// replace common line break characters with Environment.NewLine
        /// </summary>
        /// <param name="source">original text</param>
        /// <returns>converted text</returns>
#if NET20
        public static string NewLine(string source)
#else
        public static string NewLine(this string source)
#endif
        {
            var text = new StringBuilder(source);
            text.Replace("\n", Environment.NewLine);
            text.Replace("\r", Environment.NewLine);
            text.Replace("\r\n", Environment.NewLine);
            text.Replace("\\n", Environment.NewLine);
            text.Replace("\\r", Environment.NewLine);
            text.Replace("\\r\\n", Environment.NewLine);
            return text.ToString();
        }
    }
}