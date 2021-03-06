﻿using System;
using System.Data.Common;
using System.Data.SqlClient;
#if !NET20
using FirebirdSql.Data.FirebirdClient;
#endif

namespace msUtilities.Database
{
    public static class MsDatabaseHelpers
    {
        public static string DatabaseConnectionTest(MsConnectionParams connectionParams)
        {
            string error;

            var dbConn = GetConnection(out error, connectionParams);
            if (dbConn == null)
            {
                return string.Format(Messages.databaseNotConfigured, error);
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

        public static DbConnection GetConnection(out string error, MsConnectionParams connectionParams)
        {
            error = "";

            try
            {
                switch (connectionParams.DatabaseType)
                {
                    case MsDatabaseType.Firebird:
#if !NET20
                        return new FbConnection(connectionParams.GetConnectionString());
#else
                        error = Messages.databaseNotSupported;
                        return null;
#endif
                    case MsDatabaseType.SqlServer:
                        return new SqlConnection(connectionParams.GetConnectionString());
                    case MsDatabaseType.None:
                        error = Messages.databaseTypeNotSelected;
                        return null;
                    case MsDatabaseType.Other:
                        error = Messages.databaseNotSupported;
                        return null;
                    default:
                        error = Messages.databaseNotSupported;
                        return null;
                }
            }
            catch (Exception err)
            {
                error = err.Message;
                return null;
            }
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
