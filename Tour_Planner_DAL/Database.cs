using Npgsql;

namespace Tour_Planner_DAL
{
    public class Database
    {
        static Database instance;
        private NpgsqlConnection _connection;

        protected Database()
        {
            var config = new DataSourceConfig();
            _connection = new NpgsqlConnection(config.DataSourceAddress);
            _connection.Open();
        }

        public static Database Instance() {
            if (instance == null)
            {
                instance = new Database();            
            }
            return instance;
        }

        public NpgsqlConnection Connection
        {
            get { return _connection; }
        }

        public bool executeNonQuery(NpgsqlCommand command) {

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { 
                //log ex
                return false;
            }

            return true;
        }

        public NpgsqlDataReader executeReader(NpgsqlCommand command) { 
            return command.ExecuteReader();
        }

    }
}
