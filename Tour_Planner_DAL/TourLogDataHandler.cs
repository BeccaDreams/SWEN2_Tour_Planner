using Npgsql;
using Shared.Logging;
using Shared.Models;

namespace Tour_Planner_DAL
{
    public class TourLogDataHandler
    {
        private Database _db;
        private TourLogSqlCommands _sqlCommands;
        private ILoggerWrapper _logger;


        public TourLogDataHandler() 
        {
            _db = Database.Instance();
            var connection = _db.Connection;
            _sqlCommands = new TourLogSqlCommands(connection);
            _logger = LoggerFactory.GetLogger("Data Access Layer");

            _logger.Debug("TourLogDataHandler initialized.");
        }

        public List<TourLog> getTourLogsByTourId(int tourId) 
        {
            var reader = _db.executeReader(_sqlCommands.getTourLogsByTourId(tourId));
            return getToursFromReader(reader);
        }

        public List<TourLog> searchTourLog(string searchTerm) 
        {
            var reader = _db.executeReader(_sqlCommands.searchTourLog(searchTerm));
            return getToursFromReader(reader);
        }

        public bool addTourLog(int tourId, TourLog log) 
        {
            return _db.executeNonQuery(_sqlCommands.addTourLog(tourId, log));
        }
        
        public bool updateTourLog(TourLog log) 
        {
            return _db.executeNonQuery(_sqlCommands.updateTourLog(log));
        } 
        
        public bool deleteTourLog(TourLog log) 
        {
            return _db.executeNonQuery(_sqlCommands.deleteTourLog(log));
        }

        private List<TourLog> getToursFromReader(NpgsqlDataReader reader)
        {
            var tourLogs = new List<TourLog>();

            try
            {

                using (reader)
                {
                    while (reader.Read())
                    {
                        var tourLog = new TourLog
                        {
                            Id = reader.GetInt32(0),
                            LogDate = DateOnly.FromDateTime(reader.GetDateTime(1)),
                            Comment = reader.GetString(2),
                            Difficulty = reader.GetInt32(3),
                            TotalTime = reader.GetTimeSpan(4),
                            Rating = reader.GetInt32(5),
                            TourId = reader.GetInt32(6),
                        };

                        tourLogs.Add(tourLog);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Exception reading data: " + ex.Message);
            }
            return tourLogs;
        }
    }
}
