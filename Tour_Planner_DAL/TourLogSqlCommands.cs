using Npgsql;
using Shared.Models;

namespace Tour_Planner_DAL
{
    public class TourLogSqlCommands
    {
        private NpgsqlConnection _connection;

        public TourLogSqlCommands(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public NpgsqlCommand getTourLogsByTourId(int id) 
        {
            var command = new NpgsqlCommand("SELECT * FROM tour_log WHERE tour_id = $1", _connection)
            {
                Parameters = { new() { Value = id } }
            };

            return command;
        }

        public NpgsqlCommand searchTourLog(string searchTerm)
        {
            var command = new NpgsqlCommand("SELECT * FROM tour_log WHERE to_tsquery($1) @@ to_tsvector(comment)", _connection)
            {
                Parameters = { new() { Value = searchTerm.Replace(' ', '|') } }
            };

            return command;
        }

        public NpgsqlCommand addTourLog(int tourId, TourLog log) 
        {
            var command = new NpgsqlCommand("INSERT INTO tour_log (tour_date, comment, difficulty, total_time, rating, tour_id) VALUES ($1, $2, $3, $4, $5, $6)", _connection)
            {
                Parameters =
                    {
                        new() { Value = log.LogDate },
                        new() { Value = log.Comment },
                        new() { Value = log.Difficulty },
                        new() { Value = log.TotalTime },
                        new() { Value = log.Rating },
                        new() { Value = tourId }
                    }
            };
            return command;
        }  
        
        public NpgsqlCommand updateTourLog(TourLog log) 
        {
            var command = new NpgsqlCommand("UPDATE tour_log SET tour_date = $1, comment = $2, difficulty = $3, total_time = $4, rating = $5", _connection)
            {
                Parameters =
                    {
                        new() { Value = log.LogDate },
                        new() { Value = log.Comment },
                        new() { Value = log.Difficulty },
                        new() { Value = log.TotalTime },
                        new() { Value = log.Rating }
                    }
            };
            return command;

        }  
        
        public NpgsqlCommand deleteTourLog(TourLog log) {
            var command = new NpgsqlCommand("DELETE FROM tour_log WHERE id = $1", _connection)
            {
                Parameters = { new() { Value = log.Id } }
            };

            return command;
        }
    }
}
