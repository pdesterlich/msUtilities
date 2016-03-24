using System;
using System.Text;

namespace msUtilities
{
  public class msText
  {
    /// <summary>
    /// replace common line break characters with Environment.NewLine
    /// </summary>
    /// <param name="source">original text</param>
    /// <returns>converted text</returns>
    public static string newLine(string source)
    {
      StringBuilder text = new StringBuilder(source);
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