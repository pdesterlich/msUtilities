using System;
using System.Xml;

namespace msUtilities.Database
{
    /// <summary>
    /// class MsConnectionParams
    /// holds database connection parameters and allows connection string generation
    /// currently supports connection string generation for
    /// - Firebird
    /// - Sql Server
    /// </summary>
    public class MsConnectionParams
    {
        public MsDatabaseType DatabaseType { get; set; }
        public string DatabaseTypeCustom { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Database { get; set; }

        /// <summary>
        /// class initialization (empty)
        /// </summary>
        public MsConnectionParams()
        {
            DatabaseType = MsDatabaseType.None;
            DatabaseTypeCustom = "";
            Username = "";
            Password = "";
            Host = "localhost";
            Database = "";
        }

        /// <summary>
        /// class initialization (passing params)
        /// </summary>
        /// <param name="databaseType">database type</param>
        /// <param name="username">user name</param>
        /// <param name="password">password</param>
        /// <param name="host">server</param>
        /// <param name="database">database</param>
        public MsConnectionParams(MsDatabaseType databaseType, string username, string password, string host, string database)
        {
            DatabaseType = databaseType;
            DatabaseTypeCustom = "";
            Username = username;
            Password = password;
            Host = host;
            Database = database;
        }

        /// <summary>
        /// class initialization (read params from XmlElement attributes)
        /// </summary>
        /// <param name="xmlElement">XmlElement to read params from</param>
#if NET452
        /// <param name="encryptionKey">optional encryption key used for password decryption (only for msUtilities.452)</param>
        public MsConnectionParams(XmlElement xmlElement, string encryptionKey = "")
#else
        public MsConnectionParams(XmlElement xmlElement)
#endif
        {
            DatabaseType = MsDatabaseType.Firebird;
            DatabaseTypeCustom = "";
            Username = "";
            Password = "";
            Host = "localhost";
            Database = "";

#if !NET452
            FromXml(xmlElement);
#else
            FromXml(xmlElement, encryptionKey);
#endif
        }

        /// <summary>
        /// return the connection string based on the database type
        /// </summary>
        /// <returns>connection string</returns>
        public string GetConnectionString()
        {
            switch (DatabaseType)
            {
                case MsDatabaseType.Firebird:
                    return GetFirebird();
                case MsDatabaseType.SqlServer:
                    return GetSqlServer();
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
        public override string ToString()
        {
            return $"{Database} @ {Host}";
        }

        /// <summary>
        /// writes connection params as attributes of a xml element
        /// </summary>
        /// <param name="xmlElement">XmlElement to add attributes to</param>
#if NET452
        /// <param name="encryptionKey">optional encryption key used for password encryption (if empty, password is written in clear) (only for msUtilities.452)</param>
        public void ToXml(XmlElement xmlElement, string encryptionKey = "")
#else
        public void ToXml(XmlElement xmlElement)
#endif
        {
            xmlElement.SetAttribute("databaseType", DatabaseType.ToString());
            xmlElement.SetAttribute("databaseTypeCustom", DatabaseTypeCustom);
            xmlElement.SetAttribute("host", Host);
            xmlElement.SetAttribute("database", Database);
            xmlElement.SetAttribute("username", Username);
#if !NET452
            xmlElement.SetAttribute("password", Password);
#else
            xmlElement.SetAttribute("password",
                encryptionKey == "" ? Password : MsStringCipher.Encrypt(Password, encryptionKey));
#endif
        }

        /// <summary>
        /// loads connection params from attributes of a xml element
        /// </summary>
        /// <param name="xmlElement">XmlElement to read attributes from</param>
#if NET452
        /// <param name="encryptionKey">optional encryption key used for password decryption (if empty, password is read as is) (only for msUtilities.452)</param>
        public void FromXml(XmlElement xmlElement, string encryptionKey = "")
#else
        public void FromXml(XmlElement xmlElement)
#endif
        {
            var type = MsXmlHelpers.Attribute(xmlElement, "databaseType", "Firebird");
            if (type.StartsWith("dt")) type = type.Remove(0, 2);
            DatabaseType = (MsDatabaseType)Enum.Parse(typeof(MsDatabaseType), type);
            DatabaseTypeCustom = MsXmlHelpers.Attribute(xmlElement, "databaseTypeCustom", "");
            Host = MsXmlHelpers.Attribute(xmlElement, "host", "localhost");
            Database = MsXmlHelpers.Attribute(xmlElement, "database", "");
            Username = MsXmlHelpers.Attribute(xmlElement, "username", "");
#if !NET452
            Password = MsXmlHelpers.Attribute(xmlElement, "password", "");
#else
            if (encryptionKey == "")
            {
                Password = MsXmlHelpers.Attribute(xmlElement, "password", "");
            }
            else
            {
                try
                {
                    Password = MsStringCipher.Decrypt(MsXmlHelpers.Attribute(xmlElement, "password", ""), encryptionKey);
                }
                catch
                {
                    Password = MsXmlHelpers.Attribute(xmlElement, "password", "");
                }
            }
#endif
        }

        /// <summary>
        /// return the connection string for a firebird database
        /// </summary>
        /// <returns>connection string</returns>
        private string GetFirebird()
        {
            return $"User={Username};Password={Password};Database={Database};DataSource={Host};";
        }

        /// <summary>
        /// return the connection string for a sql server database
        /// </summary>
        /// <returns>connection string</returns>
        private string GetSqlServer()
        {
            return $"User Id={Username};Password={Password};Database={Database};Server={Host};";
        }

    }
}
