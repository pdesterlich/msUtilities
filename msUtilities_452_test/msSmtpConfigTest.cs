using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using msUtilities;

namespace msUtilities_452_test
{
  [TestClass]
  public class msSmtpConfigTest
  {
    [TestMethod]
    public void TestSmtpConfigToXml()
    {
      string enctryptionKey = "key";
      msSmtpConfig config = new msSmtpConfig(
        "description",
        "mail.example.com",
        "user",
        "password",
        25,
        false
        );

      XmlDocument xml = new XmlDocument();
      XmlElement xmlElement = xml.CreateElement("config");
      config.ToXml(xmlElement, enctryptionKey);

      Assert.AreEqual("user", xmlElement.GetAttribute("username"));
      Assert.AreNotEqual("password", xmlElement.GetAttribute("password"));
      Assert.AreEqual("password", msStringCipher.Decrypt(xmlElement.GetAttribute("password"), enctryptionKey));
    }

    [TestMethod]
    public void TestSmtpConfigFromXml()
    {
      string encryptionKey = "key";

      XmlDocument xml = new XmlDocument();
      XmlElement xmlElement = xml.CreateElement("config");
      xmlElement.SetAttribute("name", "description");
      xmlElement.SetAttribute("host", "mail.example.com");
      xmlElement.SetAttribute("username", "user");
      xmlElement.SetAttribute("port", 25.ToString());
      xmlElement.SetAttribute("enablessl", false.ToString());
      xmlElement.SetAttribute("password", msStringCipher.Encrypt("password", encryptionKey));

      msSmtpConfig config = new msSmtpConfig(xmlElement, encryptionKey);

      Assert.AreEqual("password", config.Password);
    }

  }
}
