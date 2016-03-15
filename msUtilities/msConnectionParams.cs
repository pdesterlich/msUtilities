using System;
using System.Xml;

namespace msUtilities
{
  /// <summary>
  /// currently supported database types (for connection string generation)
  /// </summary>
  public enum DatabaseType { dtFirebird, dtSqlServer, dtOther };

  /// <summary>
  /// class msConnectionString
  /// holds database connection parameters and allows connection string generation
  /// currently supports connection string generation for
  /// - Firebird
  /// - Sql Server
  /// </summary>
  public class msConnectionParams
  {
    public DatabaseType databaseType { get; set; } = DatabaseType.dtFirebird;
    public String databaseTypeCustom { get; set; } = "";
    public String username { get; set; } = "";
    public String password { get; set; } = "";
    public String host { get; set; } = "localhost";
    public String database { get; set; } = "";

    /// <summary>
    /// class initialization (empty)
    /// </summary>
    public msConnectionParams()
    {
      this.databaseType = DatabaseType.dtFirebird;
      this.databaseTypeCustom = "";
      this.username = "";
      this.password = "";
      this.host = "localhost";
      this.database = "";
    }

    /// <summary>
    /// class initialization
    /// </summary>
    /// <param name="databaseType">database type</param>
    /// <param name="username">user name</param>
    /// <param name="password">password</param>
    /// <param name="host">server</param>
    /// <param name="database">database</param>
    public msConnectionParams(DatabaseType databaseType, String username, String password, String host, String database)
    {
      this.databaseType = databaseType;
      this.databaseTypeCustom = "";
      this.username = username;
      this.password = password;
      this.host = host;
      this.database = database;
    }

    /// <summary>
    /// class initialization (read params from XmlElement attributes)
    /// </summary>
    /// <param name="xmlElement">XmlElement to read params from</param>
    public msConnectionParams(XmlElement xmlElement)
    {
      this.databaseType = DatabaseType.dtFirebird;
      this.databaseTypeCustom = "";
      this.username = "";
      this.password = "";
      this.host = "localhost";
      this.database = "";

      this.FromXml(xmlElement);
    }

    /// <summary>
    /// return the connection string based on the database type
    /// </summary>
    /// <returns>connection string</returns>
    public String getConnectionString()
    {
      switch (this.databaseType)
      {
        case DatabaseType.dtFirebird:
          return getFirebird();
        case DatabaseType.dtSqlServer:
          return getSqlServer();
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
    public void ToXml(XmlElement xmlElement)
    {
      xmlElement.SetAttribute("databaseType", this.databaseType.ToString());
      xmlElement.SetAttribute("databaseTypeCustom", this.databaseTypeCustom);
      xmlElement.SetAttribute("host", this.host);
      xmlElement.SetAttribute("database", this.database);
      xmlElement.SetAttribute("username", this.username);
      xmlElement.SetAttribute("password", this.password);
    }

    /// <summary>
    /// loads connection params from attributes of a xml element
    /// </summary>
    /// <param name="xmlElement">XmlElement to read attributes from</param>
    public void FromXml(XmlElement xmlElement)
    {
      this.databaseType = (DatabaseType)Enum.Parse(typeof(DatabaseType), msXmlHelpers.attribute(xmlElement, "databaseType", "dtFirebird"));
      this.databaseTypeCustom = msXmlHelpers.attribute(xmlElement, "databaseTypeCustom", "");
      this.host = msXmlHelpers.attribute(xmlElement, "host", "localhost");
      this.database = msXmlHelpers.attribute(xmlElement, "database", "");
      this.username = msXmlHelpers.attribute(xmlElement, "username", "");
      this.password = msXmlHelpers.attribute(xmlElement, "password", "");
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