using Microsoft.Data.SqlClient;
using System.Data;

namespace App.Tuya.Logistica.Data.DBConfig
{
    public class DBConnectionConfig
    {
        protected DBConnectionConfig() { }

        protected static IDbConnection OpenSqlConnection(string connectionString)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        protected static bool CloseConnection(IDbConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
            }
            return true;
        }
    }
}
