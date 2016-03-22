using System;
using System.Data.Common;
using System.Data.SqlClient;
using FirebirdSql.Data.FirebirdClient;

namespace msDatabaseUtilities
{
  public class msDatabaseHelper
  {
    public static string databaseConnectionTest(msConnectionParams connectionParams)
    {
      string error = "";
      DbConnection dbConn = getConnection(out error, connectionParams);
      if (dbConn == null)
      {
        return Messages.databaseNotConfigured + "\n" + error;
      }
      else
      {
        try
        {
          dbConn.Open();
          dbConn.Close();
          return String.Format(Messages.databaseConnectionTestResult, connectionParams.host, connectionParams.database);
        }
        catch (Exception err)
        {
          return String.Format(Messages.databaseConnectionError, connectionParams.host, connectionParams.database, err.Message);
        }
      }
    }

    public static DbConnection getConnection(out string error, msConnectionParams connectionParams)
    {
      error = "";
      DbConnection dbConn = null;

      try
      {
        switch (connectionParams.databaseType)
        {
          case DatabaseType.Firebird:
            dbConn = new FbConnection(connectionParams.getConnectionString());
            break;
          case DatabaseType.SqlServer:
            dbConn = new SqlConnection(connectionParams.getConnectionString());
            break;
          default:
            break;
        }
      }
      catch (Exception err)
      {
        error = err.Message;
        dbConn = null;
      }
      return dbConn;
    }

    public static DbCommand getCommand(msConnectionParams connectionParams, DbConnection dbConn, string commandText)
    {
      DbCommand dbCommand = null;

      switch (connectionParams.databaseType)
      {
        case DatabaseType.Firebird:
          dbCommand = new FbCommand(commandText, (FbConnection)dbConn);
          break;
        case DatabaseType.SqlServer:
          dbCommand = new SqlCommand(commandText, (SqlConnection)dbConn);
          break;
        default:
          break;
      }

      return dbCommand;
    }

    public static DbParameter getParameter(msConnectionParams connectionParams, string paramName, object paramValue)
    {
      DbParameter dbParam = null;

      switch (connectionParams.databaseType)
      {
        case DatabaseType.Firebird:
          dbParam = new FbParameter(paramName, paramValue);
          break;
        case DatabaseType.SqlServer:
          dbParam = new SqlParameter(paramName, paramValue);
          break;
        default:
          break;
      }

      return dbParam;
    }
  }
}
