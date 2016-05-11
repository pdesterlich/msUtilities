using System;
using System.Xml;

namespace msUtilities
{
  public static class msXmlHelpers
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

    /// <summary>
    /// returns the value (string) of a node attribute
    /// (original code by Ari Roth - http://stackoverflow.com/a/14132062)
    /// </summary>
    /// <param name="node">xml node</param>
    /// <param name="attribute">attribute name</param>
    /// <param name="defaultValue">default value if not found</param>
    /// <returns>attribute value</returns>
    public static string attribute(XmlNode node, String attribute, String defaultValue)
    {
      if (node.Attributes == null)
        return defaultValue;
      else
      {
        var nameAttribute = node.Attributes[attribute];
        if (nameAttribute == null)
          return defaultValue;
        else
          return nameAttribute.Value;
      }
    }

    /// <summary>
    /// returns the value (bool) of a node attribute
    /// </summary>
    /// <param name="node">xml node</param>
    /// <param name="attribute">attribute name</param>
    /// <param name="defaultValue">default value if not found or in case of conversion error</param>
    /// <returns>attribute value</returns>
    public static int attribute(XmlNode node, String attribute, int defaultValue)
    {
      if (node.Attributes == null)
        return defaultValue;
      else
      {
        var nameAttribute = node.Attributes[attribute];
        if (nameAttribute == null)
          return defaultValue;
        else
        {
          // return nameAttribute.Value;
          int j;
          String value = nameAttribute.Value;
          if (Int32.TryParse(value, out j))
            return j;
          else
            return defaultValue;
        }
      }
    }

    /// <summary>
    /// returns the value (bool) of a node attribute
    /// </summary>
    /// <param name="node">xml node</param>
    /// <param name="attribute">attribute name</param>
    /// <param name="defaultValue">default value if not found or in case of conversion error</param>
    /// <returns>attribute value</returns>
    public static bool attribute(XmlNode node, String attribute, bool defaultValue)
    {
      if (node.Attributes == null)
        return defaultValue;
      else
      {
        var nameAttribute = node.Attributes[attribute];
        if (nameAttribute == null)
          return defaultValue;
        else
        {
          // return nameAttribute.Value;
          bool j;
          String value = nameAttribute.Value;
          if (bool.TryParse(value, out j))
            return j;
          else
            return defaultValue;
        }
      }
    }

  }
}
