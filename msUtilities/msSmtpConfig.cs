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
    public msSmtpConfig(XmlElement xmlElement)
    {
      this._init();
      this.FromXml(xmlElement);
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
    public void ToXml(XmlElement xmlElement)
    {
      xmlElement.SetAttribute("name", this.Name);
      xmlElement.SetAttribute("host", this.Host);
      xmlElement.SetAttribute("username", this.Username);
      xmlElement.SetAttribute("port", this.Port.ToString());
      xmlElement.SetAttribute("enablessl", this.EnableSSL.ToString());
      xmlElement.SetAttribute("password", this.Password);
    }

    /// <summary>
    /// loads smtp server params from attributes of a xml element
    /// </summary>
    /// <param name="xmlElement">XmlElement to read attributes from</param>
    public void FromXml(XmlElement xmlElement)
    {
      this.Name = msXmlHelpers.attribute(xmlElement, "name", "");
      this.Host = msXmlHelpers.attribute(xmlElement, "host", "");
      this.Username = msXmlHelpers.attribute(xmlElement, "username", "");
      this.Port = msXmlHelpers.attribute(xmlElement, "port", 25);
      this.EnableSSL = msXmlHelpers.attribute(xmlElement, "enablessl", false);
      this.Password = msXmlHelpers.attribute(xmlElement, "password", "");
    }
  }
}