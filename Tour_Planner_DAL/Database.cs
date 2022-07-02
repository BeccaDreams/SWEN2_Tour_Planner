using Npgsql;
using Shared.Logging;

namespace Tour_Planner_DAL
{
    public class Database
    {
        static Database instance;
        private NpgsqlConnection _connection;
        private ILoggerWrapper _logger;

        protected Database()
        {
            var config = new DataSourceConfig();
            _connection = new NpgsqlConnection(config.DataSourceAddress);
            _connection.Open();
            _logger = LoggerFactory.GetLogger("Data Access Layer");

            _logger.Debug("Database initialized.");
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

        public virtual bool executeNonQuery(NpgsqlCommand command) {

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex) {

                _logger.Error("Exception executing Query: " + ex.Message);
                return false;
            }

            return true;
        }

        public virtual NpgsqlDataReader executeReader(NpgsqlCommand command) {
            return command.ExecuteReader();
        }

    }
}
