using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner_DAL;
using Shared.Models;

namespace Tour_Planner_BL
{
    public class TourController
    {
        private TourDataHandler handler;
        private JsonExporter exporter;
        private JsonImporter importer;

        public TourController()
        {
            handler = new TourDataHandler();
            exporter = new JsonExporter();
            importer = new JsonImporter();
        }

        public List<Tour> Controller_getTours()
        {
            var TourList = handler.getTours();
            return TourList;
        }

        public void Controller_addTour( Tour newTour )
        {
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
