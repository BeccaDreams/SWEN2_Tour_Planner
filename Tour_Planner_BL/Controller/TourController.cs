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


        //public bool Controller_addTour( Tour newTour )
        // {
        //     var added = handler.addTour(newTour);
        //     return added;
        //}

        public List<Tour> Controller_searchTour(string searchTerm)
        {
            return handler.searchTour(searchTerm);
        }

        public async void Controller_addTour(Tour newTour)
        {
            var distance = await mapQuestClient.GetDistance(newTour.From, newTour.To, newTour.TransportType);
            var map = await mapQuestClient.GetMapQuestStaticMap(newTour.From, newTour.To, newTour.TransportType);

            newTour.Distance = distance;
            newTour.RouteInformation = map;
            handler.addTour(newTour);

        }

        public void Controller_editTour(Tour tour)
        {
            handler.updateTour(tour);
        }

        public void Controller_deleteTour(/* Tour delTour */)
        {
            //db.deleteTour(delTour);
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
