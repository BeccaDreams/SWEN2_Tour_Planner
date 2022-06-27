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
        public TourController()
        {
            handler = new TourDataHandler();
        }

        private List<Tour> Controller_getTours()
        {
            var TourList = handler.getTours();
            return TourList;
        }

        private void Controller_addTour( Tour newTour )
        {
            handler.addTour(newTour);
        }

        private void Controller_editTour(Tour tour)
        {
            handler.updateTour(tour);
        }

        private void Controller_deleteTour(/* Tour delTour */)
        {
            //db.deleteTour(delTour);
        }





    }
}
