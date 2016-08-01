using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace msUtilities.Tests
{
    [TestClass]
    public class MsSmtpConfigTest
    {
        private const string EncryptionKey = "key";

        [TestMethod]
        public void TestSmtpConfigToXml()
        {
            var config = new msSmtpConfig(
              "description",
              "mail.example.com",
              "user",
              "password",
              25,
              false
              );

            var xml = new XmlDocument();
            var xmlElement = xml.CreateElement("config");
            config.ToXml(xmlElement, EncryptionKey);

            Assert.AreEqual("user", xmlElement.GetAttribute("username"));
            Assert.AreNotEqual("password", xmlElement.GetAttribute("password"));
            Assert.AreEqual("password", MsStringCipher.Decrypt(xmlElement.GetAttribute("password"), EncryptionKey));
        }

        [TestMethod]
        public void TestSmtpConfigFromXml()
        {
            var xml = new XmlDocument();
            var xmlElement = xml.CreateElement("config");
            xmlElement.SetAttribute("name", "description");
            xmlElement.SetAttribute("host", "mail.example.com");
            xmlElement.SetAttribute("username", "user");
            xmlElement.SetAttribute("port", 25.ToString());
            xmlElement.SetAttribute("enablessl", false.ToString());
            xmlElement.SetAttribute("password", MsStringCipher.Encrypt("password", EncryptionKey));

            var config = new msSmtpConfig(xmlElement, EncryptionKey);

            Assert.AreEqual("password", config.Password);
        }

    }
}
