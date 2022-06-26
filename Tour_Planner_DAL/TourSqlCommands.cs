using Npgsql;
using Shared.Logging;
using Shared.Models;

namespace Tour_Planner_DAL
{
    public class TourSqlCommands
    {
        private NpgsqlConnection _connection;
        private ILoggerWrapper _logger;

        public TourSqlCommands(NpgsqlConnection connection)
        {
            _connection = connection;
            _logger = LoggerFactory.GetLogger("Data Access Layer");

            _logger.Debug("TourCommands initialized.");
        }

        public NpgsqlCommand getTours()
        {
            return new NpgsqlCommand("SELECT * FROM tour", _connection);
        }

        public NpgsqlCommand addTour(Tour tour)
        {
            var command = new NpgsqlCommand("INSERT INTO tour (name, description, from_city, to_city, transport_type, distance, planned_time, route_information) VALUES ($1, $2, $3, $4, $5, $6, $7, $8)", _connection)
            {
                Parameters =
                    {
                        new() { Value = tour.Name },
                        new() { Value = tour.Description },
                        new() { Value = tour.From },
                        new() { Value = tour.To },
                        new() { Value = tour.TransportType },
                        new() { Value = tour.Distance },
                        new() { Value = tour.Time },
                        new() { Value = tour.RouteInformation }
                    }
            };
            return command;
        }

        public NpgsqlCommand updateTour(Tour tour)
        {
            var command = new NpgsqlCommand("UPDATE tour SET name = $1, description= $2, from_city = $3, to_city = $4, transport_type = $5, distance = $6, planned_time = $7, route_information = $8 WHERE id = $9", _connection)
            {
                Parameters =
                    {
                        new() { Value = tour.Name },
                        new() { Value = tour.Description },
                        new() { Value = tour.From },
                        new() { Value = tour.To },
                        new() { Value = tour.TransportType },
                        new() { Value = tour.Distance },
                        new() { Value = tour.Time },
                        new() { Value = tour.RouteInformation },
                        new() { Value = tour.Id }
                    }
            };
            return command;
        }

        public NpgsqlCommand deleteTour(Tour tour)
        {
            var command = new NpgsqlCommand("DELETE FROM tour WHERE id = $1", _connection)
            {
                Parameters = { new() { Value = tour.Id } }
            };

            return command;
        }  
        
        public NpgsqlCommand searchTour(string searchTerm)
        {
            var command = new NpgsqlCommand("SELECT * FROM tour WHERE " +
                "to_tsquery($1) @@ to_tsvector(name) OR " +
                "to_tsquery($1) @@ to_tsvector(description) OR " +
                "to_tsquery($1) @@ to_tsvector(transport_type) OR " +
                "to_tsquery($1) @@ to_tsvector(route_information) OR " +
                "to_tsquery($1) @@ to_tsvector(from_city) OR " +
                "to_tsquery($1) @@ to_tsvector(to_city)", _connection)
            {
                Parameters = { new() { Value = searchTerm.Trim().Replace(' ', '|') } }
            };

            return command;
        }  
        
        public NpgsqlCommand getTourById(int id)
        {
            var command = new NpgsqlCommand("SELECT * FROM tour WHERE id = $1", _connection)
            {
                Parameters = { new() { Value = id } }
            };

            return command;
        }

    }
}
