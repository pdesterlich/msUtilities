using System;
using System.Xml;

namespace msUtilities.Database
{
    /// <summary>
    /// currently supported database types (for connection string generation)
    /// </summary>
    public enum MsDatabaseType { None = 0, Firebird = 1, SqlServer = 2, Other = 99 };

    /// <summary>
    /// class msConnectionString
    /// holds database connection parameters and allows connection string generation
    /// currently supports connection string generation for
    /// - Firebird
    /// - Sql Server
    /// </summary>
    public class msConnectionParams
    {
        public MsDatabaseType databaseType { get; set; }
        public string DatabaseTypeCustom { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string host { get; set; }
        public string database { get; set; }

        /// <summary>
        /// class initialization (empty)
        /// </summary>
        public msConnectionParams()
        {
            this.databaseType = MsDatabaseType.None;
            this.DatabaseTypeCustom = "";
            this.username = "";
            this.password = "";
            this.host = "localhost";
            this.database = "";
        }

        /// <summary>
        /// class initialization (passing params)
        /// </summary>
        /// <param name="databaseType">database type</param>
        /// <param name="username">user name</param>
        /// <param name="password">password</param>
        /// <param name="host">server</param>
        /// <param name="database">database</param>
        public msConnectionParams(MsDatabaseType databaseType, String username, String password, String host, String database)
        {
            this.databaseType = databaseType;
            this.DatabaseTypeCustom = "";
            this.username = username;
            this.password = password;
            this.host = host;
            this.database = database;
        }

        /// <summary>
        /// class initialization (read params from XmlElement attributes)
        /// </summary>
        /// <param name="xmlElement">XmlElement to read params from</param>
        /// <param name="encryptionKey">optional encryption key used for password decryption (only for msUtilities.452)</param>
#if !NET452
        public msConnectionParams(XmlElement xmlElement)
#else
        public msConnectionParams(XmlElement xmlElement, string encryptionKey = "")
#endif
        {
            this.databaseType = MsDatabaseType.Firebird;
            this.DatabaseTypeCustom = "";
            this.username = "";
            this.password = "";
            this.host = "localhost";
            this.database = "";

#if !NET452
            this.FromXml(xmlElement);
#else
            this.FromXml(xmlElement, encryptionKey);
#endif
        }

        /// <summary>
        /// return the connection string based on the database type
        /// </summary>
        /// <returns>connection string</returns>
        public string getConnectionString()
        {
            switch (this.databaseType)
            {
                case MsDatabaseType.Firebird:
                    return getFirebird();
                case MsDatabaseType.SqlServer:
                    return getSqlServer();
                case MsDatabaseType.None:
                    return "";
                case MsDatabaseType.Other:
                    return "";
                default:
                    return "";
            }
        }

        /// <summary>
        /// return a text representation of the current connection
        /// in the form of database @ host
        /// </summary>
        /// <returns>current connection text</returns>
        public override String ToString()
        {
            return String.Format("{0} @ {1}", this.database, this.host);
        }

        /// <summary>
        /// writes connection params as attributes of a xml element
        /// </summary>
        /// <param name="xmlElement">XmlElement to add attributes to</param>
        /// <param name="encryptionKey">optional encryption key used for password encryption (if empty, password is written in clear) (only for msUtilities.452)</param>
#if !NET452
        public void ToXml(XmlElement xmlElement)
#else
        public void ToXml(XmlElement xmlElement, string encryptionKey = "")
#endif
        {
            xmlElement.SetAttribute("databaseType", this.databaseType.ToString());
            xmlElement.SetAttribute("databaseTypeCustom", this.DatabaseTypeCustom);
            xmlElement.SetAttribute("host", this.host);
            xmlElement.SetAttribute("database", this.database);
            xmlElement.SetAttribute("username", this.username);
#if !NET452
            xmlElement.SetAttribute("password", this.password);
#else
            if (encryptionKey == "")
            {
                xmlElement.SetAttribute("password", this.password);
            }
            else
            {
                xmlElement.SetAttribute("password", msStringCipher.Encrypt(this.password, encryptionKey));
            }
#endif
        }

        /// <summary>
        /// loads connection params from attributes of a xml element
        /// </summary>
        /// <param name="xmlElement">XmlElement to read attributes from</param>
        /// <param name="encryptionKey">optional encryption key used for password decryption (if empty, password is read as is) (only for msUtilities.452)</param>
#if !NET452
        public void FromXml(XmlElement xmlElement)
#else
        public void FromXml(XmlElement xmlElement, string encryptionKey = "")
#endif
        {
            string type = msXmlHelpers.attribute(xmlElement, "databaseType", "Firebird");
            if (type.StartsWith("dt")) type = type.Remove(0, 2);
            this.databaseType = (MsDatabaseType)Enum.Parse(typeof(MsDatabaseType), type);
            this.DatabaseTypeCustom = msXmlHelpers.attribute(xmlElement, "databaseTypeCustom", "");
            this.host = msXmlHelpers.attribute(xmlElement, "host", "localhost");
            this.database = msXmlHelpers.attribute(xmlElement, "database", "");
            this.username = msXmlHelpers.attribute(xmlElement, "username", "");
#if !NET452
            this.password = msXmlHelpers.attribute(xmlElement, "password", "");
#else
            if (encryptionKey == "")
            {
                this.password = msXmlHelpers.attribute(xmlElement, "password", "");
            }
            else
            {
                try
                {
                    this.password = msStringCipher.Decrypt(msXmlHelpers.attribute(xmlElement, "password", ""), encryptionKey);
                }
                catch
                {
                    this.password = msXmlHelpers.attribute(xmlElement, "password", "");
                }
            }
#endif
        }

        /// <summary>
        /// return the connection string for a firebird database
        /// </summary>
        /// <returns>connection string</returns>
        private String getFirebird()
        {
            return String.Format("User={0};Password={1};Database={2};DataSource={3};", this.username, this.password, this.database, this.host);
        }

        /// <summary>
        /// return the connection string for a sql server database
        /// </summary>
        /// <returns>connection string</returns>
        private String getSqlServer()
        {
            return String.Format("User Id={0};Password={1};Database={2};Server={3};", this.username, this.password, this.database, this.host);
        }

    }
}
