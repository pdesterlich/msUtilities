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
            databaseType = MsDatabaseType.None;
            DatabaseTypeCustom = "";
            username = "";
            password = "";
            host = "localhost";
            database = "";
        }

        /// <summary>
        /// class initialization (passing params)
        /// </summary>
        /// <param name="databaseType">database type</param>
        /// <param name="username">user name</param>
        /// <param name="password">password</param>
        /// <param name="host">server</param>
        /// <param name="database">database</param>
        public msConnectionParams(MsDatabaseType databaseType, string username, string password, string host, string database)
        {
            this.databaseType = databaseType;
            DatabaseTypeCustom = "";
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
            databaseType = MsDatabaseType.Firebird;
            DatabaseTypeCustom = "";
            username = "";
            password = "";
            host = "localhost";
            database = "";

#if !NET452
            this.FromXml(xmlElement);
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
            switch (databaseType)
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
            return $"{database} @ {host}";
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
            xmlElement.SetAttribute("databaseType", databaseType.ToString());
            xmlElement.SetAttribute("databaseTypeCustom", DatabaseTypeCustom);
            xmlElement.SetAttribute("host", host);
            xmlElement.SetAttribute("database", database);
            xmlElement.SetAttribute("username", username);
#if !NET452
            xmlElement.SetAttribute("password", password);
#else
            xmlElement.SetAttribute("password",
                encryptionKey == "" ? password : msStringCipher.Encrypt(password, encryptionKey));
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
            var type = msXmlHelpers.attribute(xmlElement, "databaseType", "Firebird");
            if (type.StartsWith("dt")) type = type.Remove(0, 2);
            databaseType = (MsDatabaseType)Enum.Parse(typeof(MsDatabaseType), type);
            DatabaseTypeCustom = msXmlHelpers.attribute(xmlElement, "databaseTypeCustom", "");
            host = msXmlHelpers.attribute(xmlElement, "host", "localhost");
            database = msXmlHelpers.attribute(xmlElement, "database", "");
            username = msXmlHelpers.attribute(xmlElement, "username", "");
#if !NET452
            this.password = msXmlHelpers.attribute(xmlElement, "password", "");
#else
            if (encryptionKey == "")
            {
                password = msXmlHelpers.attribute(xmlElement, "password", "");
            }
            else
            {
                try
                {
                    password = msStringCipher.Decrypt(msXmlHelpers.attribute(xmlElement, "password", ""), encryptionKey);
                }
                catch
                {
                    password = msXmlHelpers.attribute(xmlElement, "password", "");
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
            return $"User={username};Password={password};Database={database};DataSource={host};";
        }

        /// <summary>
        /// return the connection string for a sql server database
        /// </summary>
        /// <returns>connection string</returns>
        private string GetSqlServer()
        {
            return $"User Id={username};Password={password};Database={database};Server={host};";
        }

    }
}
