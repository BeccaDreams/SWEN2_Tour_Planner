using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Tour_Planner_DAL
{
    public class Database
    {
        private string connectionString;
        private DbConnection connection;
        public Database(string connectionString)
        {
            this.connectionString = connectionString;
            //var dataSourceConfig = config.Get<DataSourceConfig>();
            //return dataSourceConfig.DataSourceAddress;
            var connection = Connect();

        }

        public Database()
        {

        }

        private DbConnection CreateOpenConnection()
        {
            DbConnection connection = new NpgsqlConnection(this.connectionString);
            connection.Open();

            return connection;
        }



        private DbConnection Connect()
        {
            var testcon = new DataSourceConfig();
            DbConnection conn = new NpgsqlConnection(testcon.DataSourceAddress);
            conn.Open();

            return conn;
        }
    }
}
