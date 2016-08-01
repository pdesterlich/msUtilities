using System.Xml;

namespace msUtilities
{
    /// <summary>
    /// class msSmtpConfig
    /// holds smtp server connection parameters
    /// </summary>
    public class MsSmtpConfig
    {
        public string Name { get; set; } = "";
        public string Host { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public int Port { get; set; } = 25;
        public bool EnableSsl { get; set; }

        /// <summary>
        /// class initialization (empty)
        /// </summary>
        public MsSmtpConfig()
        {
            _init();
        }

        /// <summary>
        /// class initialization (passing parameters)
        /// </summary>
        /// <param name="name">smtp config description name</param>
        /// <param name="host">host name</param>
        /// <param name="username">user name</param>
        /// <param name="password">password</param>
        /// <param name="port">port number</param>
        /// <param name="enableSsl">enable ssl</param>
        public MsSmtpConfig(string name, string host, string username, string password, int port, bool enableSsl)
        {
            Name = name;
            Host = host;
            Username = username;
            Password = password;
            Port = port;
            EnableSsl = enableSsl;
        }

        /// <summary>
        /// class initialization (read params from XmlElement attributes)
        /// </summary>
        /// <param name="xmlElement">XmlElement to read params from</param>
#if NET452
        /// <param name="encryptionKey">optional encryption key used for password decryption (only for msUtilities.452)</param>
        public MsSmtpConfig(XmlElement xmlElement, string encryptionKey = "")
#else
        public MsSmtpConfig(XmlElement xmlElement)
#endif
        {
            _init();
#if NET452
            FromXml(xmlElement, encryptionKey);
#else
            FromXml(xmlElement);
#endif
        }

        /// <summary>
        /// intialize all fields to default value
        /// </summary>
        private void _init()
        {
            Name = "";
            Host = "";
            Username = "";
            Password = "";
            Port = 25;
            EnableSsl = false;
        }

        /// <summary>
        /// writes smtp server params as attributes of a xml element
        /// </summary>
        /// <param name="xmlElement">XmlElement to add attributes to</param>
#if NET452
        /// <param name="encryptionKey">optional encryption key used for password encryption (if empty, password is written in clear) (only for msUtilities.452)</param>
        public void ToXml(XmlElement xmlElement, string encryptionKey = "")
#else
        public void ToXml(XmlElement xmlElement)
#endif
        {
            xmlElement.SetAttribute("name", Name);
            xmlElement.SetAttribute("host", Host);
            xmlElement.SetAttribute("username", Username);
            xmlElement.SetAttribute("port", Port.ToString());
            xmlElement.SetAttribute("enablessl", EnableSsl.ToString());
#if NET452
            xmlElement.SetAttribute("password",
                encryptionKey == "" ? Password : MsStringCipher.Encrypt(Password, encryptionKey));
#else
            xmlElement.SetAttribute("password", Password);
#endif
        }

        /// <summary>
        /// loads smtp server params from attributes of a xml element
        /// </summary>
        /// <param name="xmlElement">XmlElement to read attributes from</param>
#if NET452
        /// <param name="encryptionKey">optional encryption key used for password decryption (if empty, password is read as is) (only for msUtilities.452)</param>
        public void FromXml(XmlElement xmlElement, string encryptionKey = "")
#else
        public void FromXml(XmlElement xmlElement)
#endif
        {
            Name = msXmlHelpers.attribute(xmlElement, "name", "");
            Host = msXmlHelpers.attribute(xmlElement, "host", "");
            Username = msXmlHelpers.attribute(xmlElement, "username", "");
            Port = msXmlHelpers.attribute(xmlElement, "port", 25);
            EnableSsl = msXmlHelpers.attribute(xmlElement, "enablessl", false);
#if NET452
            if (encryptionKey == "")
            {
                Password = msXmlHelpers.attribute(xmlElement, "password", "");
            }
            else
            {
                try
                {
                    Password = MsStringCipher.Decrypt(msXmlHelpers.attribute(xmlElement, "password", ""), encryptionKey);
                }
                catch
                {
                    Password = msXmlHelpers.attribute(xmlElement, "password", "");
                }
            }
#else
            Password = msXmlHelpers.attribute(xmlElement, "password", "");
#endif
        }
    }
}
