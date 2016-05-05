using System;
using System.Xml;

namespace msUtilities
{
  /// <summary>
  /// class msSmtpConfig
  /// holds smtp server connection parameters
  /// </summary>
  public class msSmtpConfig
  {
    public string Name { get; set; } = "";
    public string Host { get; set; } = "";
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public int Port { get; set; } = 25;
    public bool EnableSSL { get; set; } = false;

    /// <summary>
    /// class initialization (empty)
    /// </summary>
    public msSmtpConfig()
    {
      this._init();
    }

    /// <summary>
    /// class initialization (passing parameters)
    /// </summary>
    /// <param name="Name">smtp config description name</param>
    /// <param name="Host">host name</param>
    /// <param name="Username">user name</param>
    /// <param name="Password">password</param>
    /// <param name="Port">port number</param>
    /// <param name="EnableSSL">enable ssl</param>
    public msSmtpConfig(string Name, string Host, string Username, string Password, int Port, bool EnableSSL)
    {
      this.Name = Name;
      this.Host = Host;
      this.Username = Username;
      this.Password = Password;
      this.Port = Port;
      this.EnableSSL = EnableSSL;
    }

    /// <summary>
    /// class initialization (read params from XmlElement attributes)
    /// </summary>
    /// <param name="xmlElement">XmlElement to read params from</param>
    /// <param name="encryptionKey">optional encryption key used for password decryption (only for msUtilities.452)</param>
#if NET20
    public msSmtpConfig(XmlElement xmlElement)
#else
    public msSmtpConfig(XmlElement xmlElement, string encryptionKey = "")
#endif
    {
      this._init();
#if NET20
      this.FromXml(xmlElement);
#else
      this.FromXml(xmlElement, encryptionKey);
#endif
    }

    /// <summary>
    /// intialize all fields to default value
    /// </summary>
    private void _init()
    {
      this.Name = "";
      this.Host = "";
      this.Username = "";
      this.Password = "";
      this.Port = 25;
      this.EnableSSL = false;
    }

    /// <summary>
    /// writes smtp server params as attributes of a xml element
    /// </summary>
    /// <param name="xmlElement">XmlElement to add attributes to</param>
    /// <param name="encryptionKey">optional encryption key used for password encryption (if empty, password is written in clear) (only for msUtilities.452)</param>
#if NET20
    public void ToXml(XmlElement xmlElement)
#else
    public void ToXml(XmlElement xmlElement, String encryptionKey = "")
#endif
    {
      xmlElement.SetAttribute("name", this.Name);
      xmlElement.SetAttribute("host", this.Host);
      xmlElement.SetAttribute("username", this.Username);
      xmlElement.SetAttribute("port", this.Port.ToString());
      xmlElement.SetAttribute("enablessl", this.EnableSSL.ToString());
#if NET20
      xmlElement.SetAttribute("password", this.Password);
#else
      if (encryptionKey == "")
      {
        xmlElement.SetAttribute("password", this.Password);
      }
      else
      {
        xmlElement.SetAttribute("password", msStringCipher.Encrypt(this.Password, encryptionKey));
      }
#endif
    }

    /// <summary>
    /// loads smtp server params from attributes of a xml element
    /// </summary>
    /// <param name="xmlElement">XmlElement to read attributes from</param>
    /// <param name="encryptionKey">optional encryption key used for password decryption (if empty, password is read as is) (only for msUtilities.452)</param>
#if NET20
    public void FromXml(XmlElement xmlElement)
#else
    public void FromXml(XmlElement xmlElement, string encryptionKey = "")
#endif
    {
      this.Name = msXmlHelpers.attribute(xmlElement, "name", "");
      this.Host = msXmlHelpers.attribute(xmlElement, "host", "");
      this.Username = msXmlHelpers.attribute(xmlElement, "username", "");
      this.Port = msXmlHelpers.attribute(xmlElement, "port", 25);
      this.EnableSSL = msXmlHelpers.attribute(xmlElement, "enablessl", false);
#if NET20
      this.Password = msXmlHelpers.attribute(xmlElement, "password", "");
#else
      if (encryptionKey == "")
      {
        this.Password = msXmlHelpers.attribute(xmlElement, "password", "");
      }
      else
      {
        try
        {
          this.Password = msStringCipher.Decrypt(msXmlHelpers.attribute(xmlElement, "password", ""), encryptionKey);
        }
        catch
        {
          this.Password = msXmlHelpers.attribute(xmlElement, "password", "");
        }
      }
#endif
    }
  }
}
