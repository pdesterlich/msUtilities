using System.Xml;

namespace msUtilities
{
    public static class MsXmlHelpers
    {
        /// <summary>
        /// returns the value (string) of a single node (inside a xml document)
        /// </summary>
        /// <param name="xml">xml document</param>
        /// <param name="path">node path</param>
        /// <param name="defaultValue">default value if not found</param>
        /// <returns>node value</returns>
        public static string Get(XmlDocument xml, string path, string defaultValue)
        {
            var node = xml.SelectSingleNode(path);

            return node?.InnerText ?? defaultValue;
        }

        /// <summary>
        /// returns the value (string) of a single node (inside a xml node)
        /// </summary>
        /// <param name="xml">xml node</param>
        /// <param name="path">node path</param>
        /// <param name="defaultValue">default value if not found</param>
        /// <returns>node value</returns>
        public static string Get(XmlNode xml, string path, string defaultValue)
        {
            var node = xml.SelectSingleNode(path);

            return node?.InnerText ?? defaultValue;
        }

        /// <summary>
        /// returns the value (int) of a single node (inside a xml document)
        /// </summary>
        /// <param name="xml">xml document</param>
        /// <param name="path">node path</param>
        /// <param name="defaultValue">default value if not found or in case of conversion errors</param>
        /// <returns>node value</returns>
        public static int Get(XmlDocument xml, string path, int defaultValue)
        {
            var node = xml.SelectSingleNode(path);

            if (node == null)
                return defaultValue;
            else
            {
                int j;
                var value = node.InnerText;

                return int.TryParse(value, out j) ? j : defaultValue;
            }
        }

        /// <summary>
        /// returns the value (int) of a single node (inside a xml node)
        /// </summary>
        /// <param name="xml">xml node</param>
        /// <param name="path">node path</param>
        /// <param name="defaultValue">default value if not found or in case of conversion errors</param>
        /// <returns>node value</returns>
        public static int Get(XmlNode xml, string path, int defaultValue)
        {
            var node = xml.SelectSingleNode(path);

            if (node == null)
                return defaultValue;
            else
            {
                int j;
                var value = node.InnerText;

                return int.TryParse(value, out j) ? j : defaultValue;
            }
        }

        /// <summary>
        /// returns the value (bool) of a single node (inside a xml document)
        /// </summary>
        /// <param name="xml">xml document</param>
        /// <param name="path">node path</param>
        /// <param name="defaultValue">default value if not found or in case of conversion errors</param>
        /// <returns>node value</returns>
        public static bool Get(XmlDocument xml, string path, bool defaultValue)
        {
            var node = xml.SelectSingleNode(path);

            if (node == null)
                return defaultValue;
            else
            {
                bool j;
                var value = node.InnerText;

                return bool.TryParse(value, out j) ? j : defaultValue;
            }
        }

        /// <summary>
        /// returns the value (bool) of a single node (inside a xml node)
        /// </summary>
        /// <param name="xml">xml node</param>
        /// <param name="path">node path</param>
        /// <param name="defaultValue">default value if not found or in case of conversion errors</param>
        /// <returns>node value</returns>
        public static bool Get(XmlNode xml, string path, bool defaultValue)
        {
            var node = xml.SelectSingleNode(path);

            if (node == null)
                return defaultValue;
            else
            {
                bool j;
                var value = node.InnerText;

                return bool.TryParse(value, out j) ? j : defaultValue;
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
        public static string Attribute(XmlNode node, string attribute, string defaultValue)
        {
            if (node.Attributes == null)
                return defaultValue;
            else
            {
                var nameAttribute = node.Attributes[attribute];

                return nameAttribute == null ? defaultValue : nameAttribute.Value;
            }
        }

        /// <summary>
        /// returns the value (bool) of a node attribute
        /// </summary>
        /// <param name="node">xml node</param>
        /// <param name="attribute">attribute name</param>
        /// <param name="defaultValue">default value if not found or in case of conversion error</param>
        /// <returns>attribute value</returns>
        public static int Attribute(XmlNode node, string attribute, int defaultValue)
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
                    var value = nameAttribute.Value;

                    return int.TryParse(value, out j) ? j : defaultValue;
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
        public static bool Attribute(XmlNode node, string attribute, bool defaultValue)
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
                    var value = nameAttribute.Value;

                    return bool.TryParse(value, out j) ? j : defaultValue;
                }
            }
        }

    }
}
