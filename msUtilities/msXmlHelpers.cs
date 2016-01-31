using System;
using System.Xml;

namespace msUtilities
{
  public class msXmlHelpers
  {
    /// <summary>
    /// returns the value (string) of a single node (inside a xml document)
    /// </summary>
    /// <param name="xml">xml document</param>
    /// <param name="path">node path</param>
    /// <param name="defaultValue">default value if not found</param>
    /// <returns>node value</returns>
    public static String get(XmlDocument xml, String path, String defaultValue)
    {
      XmlNode node = xml.SelectSingleNode(path);

      if (node == null)
        return defaultValue;
      else
        return node.InnerText;
    }

    /// <summary>
    /// returns the value (string) of a single node (inside a xml node)
    /// </summary>
    /// <param name="xml">xml node</param>
    /// <param name="path">node path</param>
    /// <param name="defaultValue">default value if not found</param>
    /// <returns>node value</returns>
    public static String get(XmlNode xml, String path, String defaultValue)
    {
      XmlNode node = xml.SelectSingleNode(path);

      if (node == null)
        return defaultValue;
      else
        return node.InnerText;
    }

    /// <summary>
    /// returns the value (int) of a single node (inside a xml document)
    /// </summary>
    /// <param name="xml">xml document</param>
    /// <param name="path">node path</param>
    /// <param name="defaultValue">default value if not found or in case of conversion errors</param>
    /// <returns>node value</returns>
    public static int get(XmlDocument xml, String path, int defaultValue)
    {
      XmlNode node = xml.SelectSingleNode(path);

      if (node == null)
        return defaultValue;
      else
      {
        int j;
        String value = xml.SelectSingleNode(path).InnerText;
        if (Int32.TryParse(value, out j))
          return j;
        else
          return defaultValue;
      }
    }

    /// <summary>
    /// returns the value (int) of a single node (inside a xml node)
    /// </summary>
    /// <param name="xml">xml node</param>
    /// <param name="path">node path</param>
    /// <param name="defaultValue">default value if not found or in case of conversion errors</param>
    /// <returns>node value</returns>
    public static int get(XmlNode xml, String path, int defaultValue)
    {
      XmlNode node = xml.SelectSingleNode(path);

      if (node == null)
        return defaultValue;
      else
      {
        int j;
        String value = xml.SelectSingleNode(path).InnerText;
        if (Int32.TryParse(value, out j))
          return j;
        else
          return defaultValue;
      }
    }

    /// <summary>
    /// returns the value (bool) of a single node (inside a xml document)
    /// </summary>
    /// <param name="xml">xml document</param>
    /// <param name="path">node path</param>
    /// <param name="defaultValue">default value if not found or in case of conversion errors</param>
    /// <returns>node value</returns>
    public static bool get(XmlDocument xml, String path, bool defaultValue)
    {
      XmlNode node = xml.SelectSingleNode(path);

      if (node == null)
        return defaultValue;
      else
      {
        bool j;
        String value = xml.SelectSingleNode(path).InnerText;
        if (bool.TryParse(value, out j))
          return j;
        else
          return defaultValue;
      }
    }

    /// <summary>
    /// returns the value (bool) of a single node (inside a xml node)
    /// </summary>
    /// <param name="xml">xml node</param>
    /// <param name="path">node path</param>
    /// <param name="defaultValue">default value if not found or in case of conversion errors</param>
    /// <returns>node value</returns>
    public static bool get(XmlNode xml, String path, bool defaultValue)
    {
      XmlNode node = xml.SelectSingleNode(path);

      if (node == null)
        return defaultValue;
      else
      {
        bool j;
        String value = xml.SelectSingleNode(path).InnerText;
        if (bool.TryParse(value, out j))
          return j;
        else
          return defaultValue;
      }
    }
  }
}
