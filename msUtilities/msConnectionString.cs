using System;

namespace msUtilities
{
  public class msConnectionString
  {
    public enum DatabaseType { dtFirebird, dtSqlServer };

    public DatabaseType databaseType { get; set; } = DatabaseType.dtFirebird;
    public String username { get; set; } = "";
    public String password { get; set; } = "";
    public String host { get; set; } = "localhost";
    public String database { get; set; } = "";

    /// <summary>
    /// class initialization
    /// </summary>
    /// <param name="databaseType">database type</param>
    /// <param name="username">user name</param>
    /// <param name="password">password</param>
    /// <param name="host">server</param>
    /// <param name="database">database</param>
    public msConnectionString(DatabaseType databaseType, String username, String password, String host, String database)
    {
      this.databaseType = databaseType;
      this.username = username;
      this.password = password;
      this.host = host;
      this.database = database;
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