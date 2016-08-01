using Microsoft.VisualStudio.TestTools.UnitTesting;
using msUtilities;
using msUtilities.Database;
using System;
using System.Xml;

namespace msUtilities_452_test
{
    [TestClass]
    public class msConnectionParamsTest
    {
        [TestMethod]
        public void TestConnectionStringGenerationFirebird()
        {
            MsConnectionParams conn = new MsConnectionParams(
              MsDatabaseType.Firebird,
              "user",
              "password",
              "host",
              "database"
              );

            string test = String.Format("User={0};Password={1};Database={2};DataSource={3};", "user", "password", "database", "host");
            string result = conn.GetConnectionString();

            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void TestConnectionStringGenerationFirebirdEmpty()
        {
            var conn = new MsConnectionParams();
            conn.DatabaseType = MsDatabaseType.Firebird;
            conn.Username = "user";
            conn.Password = "password";
            conn.Host = "host";
            conn.Database = "database";

            string test = String.Format("User={0};Password={1};Database={2};DataSource={3};", "user", "password", "database", "host");
            string result = conn.GetConnectionString();

            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void TestConnectionStringGenerationSqlServer()
        {
            MsConnectionParams conn = new MsConnectionParams(
              MsDatabaseType.SqlServer,
              "user",
              "password",
              "host",
              "database"
              );

            string test = String.Format("User Id={0};Password={1};Database={2};Server={3};", "user", "password", "database", "host");
            string result = conn.GetConnectionString();

            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void TestConnectionStringGenerationOther()
        {
            MsConnectionParams conn = new MsConnectionParams(
              MsDatabaseType.Other,
              "user",
              "password",
              "host",
              "database"
              );

            string test = "";
            string result = conn.GetConnectionString();

            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void TestConnectionParamsToXml()
        {
            string enctryptionKey = "key";
            MsConnectionParams conn = new MsConnectionParams(
              MsDatabaseType.Firebird,
              "user",
              "password",
              "host",
              "database"
              );

            XmlDocument xml = new XmlDocument();
            XmlElement xmlElement = xml.CreateElement("connection");
            conn.ToXml(xmlElement, enctryptionKey);

            Assert.AreEqual("user", xmlElement.GetAttribute("username"));
            Assert.AreNotEqual("password", xmlElement.GetAttribute("password"));
            Assert.AreEqual("password", MsStringCipher.Decrypt(xmlElement.GetAttribute("password"), enctryptionKey));
        }

        [TestMethod]
        public void TestConnectionParamsFromXml()
        {
            string encryptionKey = "key";

            XmlDocument xml = new XmlDocument();
            XmlElement xmlElement = xml.CreateElement("connection");
            xmlElement.SetAttribute("databaseType", "Firebird");
            xmlElement.SetAttribute("databaseTypeCustom", "");
            xmlElement.SetAttribute("host", "host");
            xmlElement.SetAttribute("database", "database");
            xmlElement.SetAttribute("username", "username");
            xmlElement.SetAttribute("password", MsStringCipher.Encrypt("password", encryptionKey));

            MsConnectionParams conn = new MsConnectionParams(xmlElement, encryptionKey);

            Assert.AreEqual(MsDatabaseType.Firebird, conn.DatabaseType);
            Assert.AreEqual("password", conn.Password);
        }

        [TestMethod]
        public void TestConnectionParamsFromXmlOld()
        {
            string encryptionKey = "key";

            XmlDocument xml = new XmlDocument();
            XmlElement xmlElement = xml.CreateElement("connection");
            xmlElement.SetAttribute("databaseType", "dtFirebird");
            xmlElement.SetAttribute("databaseTypeCustom", "");
            xmlElement.SetAttribute("host", "host");
            xmlElement.SetAttribute("database", "database");
            xmlElement.SetAttribute("username", "username");
            xmlElement.SetAttribute("password", MsStringCipher.Encrypt("password", encryptionKey));

            MsConnectionParams conn = new MsConnectionParams(xmlElement, encryptionKey);

            Assert.AreEqual(MsDatabaseType.Firebird, conn.DatabaseType);
            Assert.AreEqual("password", conn.Password);
        }
    }
}
