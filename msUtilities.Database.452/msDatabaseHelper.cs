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
            var error = "";
            var dbConn = getConnection(out error, connectionParams);
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
                    return string.Format(Messages.databaseConnectionTestResult, connectionParams.Host, connectionParams.Database);
                }
                catch (Exception err)
                {
                    return string.Format(Messages.databaseConnectionError, connectionParams.Host, connectionParams.Database, err.Message);
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

        public static DbCommand GetCommand(MsConnectionParams connectionParams)
        {
            switch (connectionParams.DatabaseType)
            {
                case MsDatabaseType.Firebird:
#if !NET20
                    return new FbCommand();
#else
                    return null;
#endif
                case MsDatabaseType.SqlServer:
                    return new SqlCommand();
                case MsDatabaseType.None:
                    return null;
                case MsDatabaseType.Other:
                    return null;
                default:
                    return null;
            }
        }

        public static DbCommand GetCommand(MsConnectionParams connectionParams, DbConnection dbConn, string commandText)
        {
            switch (connectionParams.DatabaseType)
            {
                case MsDatabaseType.Firebird:
#if !NET20
                    return new FbCommand(commandText, (FbConnection)dbConn);
#else
                    return null;
#endif
                case MsDatabaseType.SqlServer:
                    return new SqlCommand(commandText, (SqlConnection)dbConn);
                case MsDatabaseType.None:
                    return null;
                case MsDatabaseType.Other:
                    return null;
                default:
                    return null;
            }
        }

        public static DbParameter GetParameter(MsConnectionParams connectionParams)
        {
            switch (connectionParams.DatabaseType)
            {
                case MsDatabaseType.Firebird:
#if !NET20
                    return new FbParameter();
#else
                    return null;
#endif
                case MsDatabaseType.SqlServer:
                    return new SqlParameter();
                case MsDatabaseType.None:
                    return null;
                case MsDatabaseType.Other:
                    return null;
                default:
                    return null;
            }
        }

        public static DbParameter GetParameter(MsConnectionParams connectionParams, string paramName, object paramValue)
        {
            switch (connectionParams.DatabaseType)
            {
                case MsDatabaseType.Firebird:
#if !NET20
                    return new FbParameter(paramName, paramValue);
#else
                    return null;
#endif
                case MsDatabaseType.SqlServer:
                    return new SqlParameter(paramName, paramValue);
                case MsDatabaseType.None:
                    return null;
                case MsDatabaseType.Other:
                    return null;
                default:
                    return null;
            }
        }
    }
}
