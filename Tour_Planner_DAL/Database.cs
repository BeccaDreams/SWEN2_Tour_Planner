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
        public Database(string connectionString)
        {
            this.connectionString = connectionString;
            //var dataSourceConfig = config.Get<DataSourceConfig>();
            //return dataSourceConfig.DataSourceAddress;

        }

        private DbConnection CreateOpenConnection()
        {
            DbConnection connection = new NpgsqlConnection(this.connectionString);
            connection.Open();

            return connection;
        }

    }
}
