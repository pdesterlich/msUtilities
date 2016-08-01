using Microsoft.VisualStudio.TestTools.UnitTesting;
using msUtilities.Database;
using System.Xml;

namespace msUtilities.Tests
{
    [TestClass]
    public class MsConnectionParamsTest
    {
        private const string User = "user";
        private const string Password = "password";
        private const string Host = "host";
        private const string DatabaseName = "DatabaseName";

        private const string EncryptionKey = "key";

        [TestMethod]
        public void TestConnectionStringGenerationFirebird()
        {
            var conn = new MsConnectionParams(
              MsDatabaseType.Firebird,
              User,
              Password,
              Host,
              DatabaseName
              );

            var test = $"User={User};Password={Password};Database={DatabaseName};DataSource={Host};";
            var result = conn.GetConnectionString();

            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void TestConnectionStringGenerationFirebirdEmpty()
        {
            var conn = new MsConnectionParams
            {
                DatabaseType = MsDatabaseType.Firebird,
                Username = User,
                Password = Password,
                Host = Host,
                Database = DatabaseName
            };

            var test = $"User={User};Password={Password};Database={DatabaseName};DataSource={Host};";
            var result = conn.GetConnectionString();

            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void TestConnectionStringGenerationSqlServer()
        {
            var conn = new MsConnectionParams(
              MsDatabaseType.SqlServer,
              User,
              Password,
              Host,
              DatabaseName
              );

            var test = $"User Id={User};Password={Password};Database={DatabaseName};Server={Host};";
            var result = conn.GetConnectionString();

            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void TestConnectionStringGenerationOther()
        {
            var conn = new MsConnectionParams(
              MsDatabaseType.Other,
              User,
              Password,
              Host,
              DatabaseName
              );

            const string test = "";
            var result = conn.GetConnectionString();

            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void TestConnectionParamsToXml()
        {
            var conn = new MsConnectionParams(
              MsDatabaseType.Firebird,
              User,
              Password,
              Host,
              DatabaseName
              );

            var xml = new XmlDocument();
            var xmlElement = xml.CreateElement("connection");
            conn.ToXml(xmlElement, EncryptionKey);

            Assert.AreEqual("user", xmlElement.GetAttribute("username"));
            Assert.AreNotEqual("password", xmlElement.GetAttribute("password"));
            Assert.AreEqual("password", MsStringCipher.Decrypt(xmlElement.GetAttribute("password"), EncryptionKey));
        }

        [TestMethod]
        public void TestConnectionParamsFromXml()
        {
            var xml = new XmlDocument();
            var xmlElement = xml.CreateElement("connection");
            xmlElement.SetAttribute("databaseType", "Firebird");
            xmlElement.SetAttribute("databaseTypeCustom", "");
            xmlElement.SetAttribute("host", Host);
            xmlElement.SetAttribute("DatabaseName", DatabaseName);
            xmlElement.SetAttribute("username", User);
            xmlElement.SetAttribute("password", MsStringCipher.Encrypt(Password, EncryptionKey));

            var conn = new MsConnectionParams(xmlElement, EncryptionKey);

            Assert.AreEqual(MsDatabaseType.Firebird, conn.DatabaseType);
            Assert.AreEqual(Password, conn.Password);
        }

        [TestMethod]
        public void TestConnectionParamsFromXmlOld()
        {
            var xml = new XmlDocument();
            var xmlElement = xml.CreateElement("connection");
            xmlElement.SetAttribute("databaseType", "dtFirebird");
            xmlElement.SetAttribute("databaseTypeCustom", "");
            xmlElement.SetAttribute("host", Host);
            xmlElement.SetAttribute("DatabaseName", DatabaseName);
            xmlElement.SetAttribute("username", User);
            xmlElement.SetAttribute("password", MsStringCipher.Encrypt(Password, EncryptionKey));

            var conn = new MsConnectionParams(xmlElement, EncryptionKey);

            Assert.AreEqual(MsDatabaseType.Firebird, conn.DatabaseType);
            Assert.AreEqual(Password, conn.Password);
        }
    }
}
