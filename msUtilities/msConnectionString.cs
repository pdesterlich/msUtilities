using System;

namespace msUtilities
{
  public class msConnectionString
  {
    public String username { get; set; } = "";
    public String password { get; set; } = "";
    public String host { get; set; } = "localhost";
    public String database { get; set; } = "";

    /// <summary>
    /// class initialization
    /// </summary>
    /// <param name="username">user name</param>
    /// <param name="password">password</param>
    /// <param name="host">server</param>
    /// <param name="database">database</param>
    public msConnectionString(String username, String password, String host, String database)
    {
      this.username = username;
      this.password = password;
      this.host = host;
      this.database = database;
    }

    /// <summary>
    /// return the connection string for a firebird database
    /// </summary>
    /// <returns>connection string</returns>
    public String getFirebird()
    {
      return String.Format("User={0};Password={1};Database={2};DataSource={3};", this.username, this.password, this.database, this.host);
    }

    /// <summary>
    /// return the connection string for a sql server database
    /// </summary>
    /// <returns>connection string</returns>
    public String getSqlServer()
    {
      return String.Format("User Id={0};Password={1};Database={2};Server={3};", this.username, this.password, this.database, this.host);
    }
  }
}
