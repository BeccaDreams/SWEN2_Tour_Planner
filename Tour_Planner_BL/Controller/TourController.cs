using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner_DAL;
using Shared.Models;

namespace Tour_Planner_BL.Controller
{
    public class TourController
    {
        private TourDataHandler _handler;
        private JsonExporter _exporter;
        private JsonImporter _importer;
        private MapQuestClient _mapQuestClient;

        public TourController()
        {
            _handler = new TourDataHandler();
            _exporter = new JsonExporter();
            _importer = new JsonImporter();
            _mapQuestClient = new MapQuestClient();
        }

        public TourDataHandler Handler { 
            get { return _handler; }
            set { _handler = value; }
        }
        public JsonExporter Exporter { 
            get { return _exporter; }
            set { _exporter = value; }
        }

        public JsonImporter Importer { 
            get { return _importer; }
            set { _importer = value; }
        }

        public MapQuestClient MapQuestClient { 
            get { return _mapQuestClient; }
            set { _mapQuestClient = value; }
        }

        public List<Tour> Controller_getTours()
        {
            var TourList = _handler.getTours();
            return TourList;
        }


        public List<Tour> Controller_searchTour(string searchTerm)
        {
            return _handler.searchTour(searchTerm);
        }

        public async void Controller_addTour(Tour newTour, bool ignoreDirectionApi)
        {
            if(ignoreDirectionApi == false)
            {
                var direction = await _mapQuestClient.GetMapQuestDirection(newTour.From, newTour.To, newTour.TransportType);
                var map = await _mapQuestClient.GetMapQuestStaticMap(direction);

                newTour.Distance = direction.Route.Distance;
                newTour.Time = direction.Route.FormattedTime;
                newTour.RouteInformation = map;
            }
            
            _handler.addTour(newTour);

        }

        public async void Controller_editTour(Tour tour)
        {
            var direction = await _mapQuestClient.GetMapQuestDirection(tour.From, tour.To, tour.TransportType);
            var map = await _mapQuestClient.GetMapQuestStaticMap(direction);

            tour.Distance = direction.Route.Distance;
            tour.Time = direction.Route.FormattedTime;
            tour.RouteInformation = map;
            _handler.updateTour(tour);
        }

        public bool Controller_deleteTour(Tour delTour)
        {
            return _handler.deleteTour(delTour);
        }

        public void Controller_export()
        {
            var tours = Controller_getTours();
            _exporter.ExportTours(tours);
        }

        public void Controller_import()
        {
            var tours = _importer.ImportTours("import/tours.json");

            foreach (var tour in tours)
            {
                Controller_addTour(tour, true);
            }
        }







    }
}
