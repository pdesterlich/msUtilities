using System;
using System.Data.Common;
using System.Data.SqlClient;
#if !NET20
using FirebirdSql.Data.FirebirdClient;
#endif

namespace msUtilities.Database
{
    public class msDatabaseHelper
    {
        public static string databaseConnectionTest(MsConnectionParams connectionParams)
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
                    return String.Format(Messages.databaseConnectionTestResult, connectionParams.Host, connectionParams.Database);
                }
                catch (Exception err)
                {
                    return String.Format(Messages.databaseConnectionError, connectionParams.Host, connectionParams.Database, err.Message);
                }
            }
        }

        public static DbConnection getConnection(out string error, MsConnectionParams connectionParams)
        {
            error = "";
            DbConnection dbConn = null;

            try
            {
                switch (connectionParams.DatabaseType)
                {
                    case MsDatabaseType.Firebird:
#if !NET20
                        dbConn = new FbConnection(connectionParams.GetConnectionString());
#else
            error = Messages.databaseNotSupported;
#endif
                        break;
                    case MsDatabaseType.SqlServer:
                        dbConn = new SqlConnection(connectionParams.GetConnectionString());
                        break;
                    default:
                        error = Messages.databaseNotSupported;
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

        public static DbCommand getCommand(MsConnectionParams connectionParams)
        {
            DbCommand dbCommand = null;

            switch (connectionParams.DatabaseType)
            {
                case MsDatabaseType.Firebird:
#if !NET20
                    dbCommand = new FbCommand();
#endif
                    break;
                case MsDatabaseType.SqlServer:
                    dbCommand = new SqlCommand();
                    break;
                default:
                    break;
            }

            return dbCommand;
        }

        public static DbCommand getCommand(MsConnectionParams connectionParams, DbConnection dbConn, string commandText)
        {
            DbCommand dbCommand = null;

            switch (connectionParams.DatabaseType)
            {
                case MsDatabaseType.Firebird:
#if !NET20
                    dbCommand = new FbCommand(commandText, (FbConnection)dbConn);
#endif
                    break;
                case MsDatabaseType.SqlServer:
                    dbCommand = new SqlCommand(commandText, (SqlConnection)dbConn);
                    break;
                default:
                    break;
            }

            return dbCommand;
        }

        public static DbParameter getParameter(MsConnectionParams connectionParams)
        {
            DbParameter dbParam = null;

            switch (connectionParams.DatabaseType)
            {
                case MsDatabaseType.Firebird:
#if !NET20
                    dbParam = new FbParameter();
#endif
                    break;
                case MsDatabaseType.SqlServer:
                    dbParam = new SqlParameter();
                    break;
                default:
                    break;
            }

            return dbParam;
        }

        public static DbParameter getParameter(MsConnectionParams connectionParams, string paramName, object paramValue)
        {
            DbParameter dbParam = null;

            switch (connectionParams.DatabaseType)
            {
                case MsDatabaseType.Firebird:
#if !NET20
                    dbParam = new FbParameter(paramName, paramValue);
#endif
                    break;
                case MsDatabaseType.SqlServer:
                    dbParam = new SqlParameter(paramName, paramValue);
                    break;
                default:
                    break;
            }

            return dbParam;
        }
    }
}
