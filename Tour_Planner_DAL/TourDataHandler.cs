using Npgsql;
using Shared.Models;

namespace Tour_Planner_DAL
{
    public class TourDataHandler
    {
        private Database _db;
        private TourSqlCommands _sqlCommands;

        public TourDataHandler() 
        { 
            _db = Database.Instance();
            var connection = _db.Connection;
            _sqlCommands = new TourSqlCommands(connection);
        }

        public List<Tour> getTours() 
        {
            var reader = _db.executeReader(_sqlCommands.getTours());
            return getToursFromReader(reader);
        }

        public List<Tour> searchTour(string searchTerm)
        {
            var reader = _db.executeReader(_sqlCommands.searchTour(searchTerm));
            return getToursFromReader(reader);
        }

        public List<Tour> getTourById(int id)
        {
            var reader = _db.executeReader(_sqlCommands.getTourById(id));
            return getToursFromReader(reader);
        }

        public bool addTour(Tour tour) 
        {
            return _db.executeNonQuery(_sqlCommands.addTour(tour));
        }

        public bool updateTour(Tour tour) 
        { 
            return _db.executeNonQuery(_sqlCommands.updateTour(tour));
        }

        public bool deleteTour(Tour tour) 
        {
            return _db.executeNonQuery(_sqlCommands.deleteTour(tour));
        } 
        

        private List<Tour> getToursFromReader(NpgsqlDataReader reader)
        {
            
            var tours = new List<Tour>();

            try
            {

                using (reader)
                {
                    while (reader.Read())
                    {
                        var tour = new Tour
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            From = reader.GetString(3),
                            To = reader.GetString(4),
                            TransportType = reader.GetString(5),
                            Distance = reader.GetDouble(6),
                            Time = reader.GetTimeSpan(7),
                            RouteInformation = reader.GetString(8)
                        };

                        tours.Add(tour);
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Log ex
                Console.WriteLine("Error getting cards");
            }
            return tours;
        }
    }
}
