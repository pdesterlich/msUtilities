﻿using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using msUtilities;

namespace msUtilities_452_test
{
  [TestClass]
  public class msConnectionParamsTest
  {
    [TestMethod]
    public void TestConnectionStringGenerationFirebird()
    {
      msConnectionParams conn = new msConnectionParams(
        DatabaseType.dtFirebird,
        "user",
        "password",
        "host",
        "database"
        );

      string test = String.Format("User={0};Password={1};Database={2};DataSource={3};", "user", "password", "database", "host");
      string result = conn.getConnectionString();

      Assert.AreEqual(test, result);
    }

    [TestMethod]
    public void TestConnectionStringGenerationFirebirdEmpty()
    {
      var conn = new msConnectionParams();
      conn.databaseType = DatabaseType.dtFirebird;
      conn.username = "user";
      conn.password = "password";
      conn.host = "host";
      conn.database = "database";

      string test = String.Format("User={0};Password={1};Database={2};DataSource={3};", "user", "password", "database", "host");
      string result = conn.getConnectionString();

      Assert.AreEqual(test, result);
    }

    [TestMethod]
    public void TestConnectionStringGenerationSqlServer()
    {
      msConnectionParams conn = new msConnectionParams(
        DatabaseType.dtSqlServer,
        "user",
        "password",
        "host",
        "database"
        );

      string test = String.Format("User Id={0};Password={1};Database={2};Server={3};", "user", "password", "database", "host");
      string result = conn.getConnectionString();

      Assert.AreEqual(test, result);
    }

    [TestMethod]
    public void TestConnectionStringGenerationOther()
    {
      msConnectionParams conn = new msConnectionParams(
        DatabaseType.dtOther,
        "user",
        "password",
        "host",
        "database"
        );

      string test = "";
      string result = conn.getConnectionString();

      Assert.AreEqual(test, result);
    }

    [TestMethod]
    public void TestConnectionParamsToXml()
    {
      string enctryptionKey = "key";
      msConnectionParams conn = new msConnectionParams(
        DatabaseType.dtFirebird,
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
      Assert.AreEqual("password", msStringCipher.Decrypt(xmlElement.GetAttribute("password"), enctryptionKey));
    }

    [TestMethod]
    public void TestConnectionParamsFromXml()
    {
      string encryptionKey = "key";

      XmlDocument xml = new XmlDocument();
      XmlElement xmlElement = xml.CreateElement("connection");
      xmlElement.SetAttribute("databaseType", "dtFirebird");
      xmlElement.SetAttribute("databaseTypeCustom", "");
      xmlElement.SetAttribute("host", "host");
      xmlElement.SetAttribute("database", "database");
      xmlElement.SetAttribute("username", "username");
      xmlElement.SetAttribute("password", msStringCipher.Encrypt("password", encryptionKey));

      msConnectionParams conn = new msConnectionParams(xmlElement, encryptionKey);

      Assert.AreEqual(DatabaseType.dtFirebird, conn.databaseType);
      Assert.AreEqual("password", conn.password);
    }
  }
}
