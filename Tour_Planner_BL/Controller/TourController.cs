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
        private TourDataHandler handler;
        private JsonExporter exporter;
        private JsonImporter importer;
        private MapQuestClient mapQuestClient;

        public TourController()
        {
            handler = new TourDataHandler();
            exporter = new JsonExporter();
            importer = new JsonImporter();
            mapQuestClient = new MapQuestClient();
        }

        public List<Tour> Controller_getTours()
        {
            var TourList = handler.getTours();
            return TourList;
        }


        public List<Tour> Controller_searchTour(string searchTerm)
        {
            return handler.searchTour(searchTerm);
        }

        public async void Controller_addTour(Tour newTour)
        {
            var direction = await mapQuestClient.GetMapQuestDirection(newTour.From, newTour.To, newTour.TransportType);
            var map = await mapQuestClient.GetMapQuestStaticMap(direction);

            newTour.Distance = direction.Route.Distance;
            newTour.Time = direction.Route.FormattedTime;
            newTour.RouteInformation = map;
            handler.addTour(newTour);

        }

        public async void Controller_editTour(Tour tour)
        {
            var direction = await mapQuestClient.GetMapQuestDirection(tour.From, tour.To, tour.TransportType);
            var map = await mapQuestClient.GetMapQuestStaticMap(direction);

            tour.Distance = direction.Route.Distance;
            tour.Time = direction.Route.FormattedTime;
            tour.RouteInformation = map;
            handler.updateTour(tour);
        }

        public bool Controller_deleteTour(Tour delTour)
        {
            return handler.deleteTour(delTour);
        }

        public void Controller_export()
        {
            var tours = Controller_getTours();
            exporter.ExportTours(tours);
        }

        public void Controller_import()
        {
            var tours = importer.ImportTours("import/tours.json");

            foreach (var tour in tours)
            {
                Controller_addTour(tour);
            }
        }







    }
}
