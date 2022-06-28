using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;
using Tour_Planner_DAL;

namespace Tour_Planner_BL.Controller
{
    public class LogController
    {
        private TourLogDataHandler handler;
        public LogController()
        {
            handler = new TourLogDataHandler();
        }

        public List<TourLog> Controller_getTourLogsByTourId(int tourId)
        {
            var tourLogs = handler.getTourLogsByTourId(tourId);
            return tourLogs;
        }

        public List<TourLog> Controller_searchTourLog(string searchTerm)
        {
            var tourLog = handler.searchTourLog(searchTerm);
            return tourLog;
        }

        public bool Controller_addTourLog(int tourId, TourLog log)
        {
            return handler.addTourLog(tourId, log);
        }

        public bool Controller_updateTourLog(TourLog log)
        {
            return handler.updateTourLog(log);
        }

        public bool Controller_deleteTourLog(TourLog log)
        {
            return handler.deleteTourLog(log);
        }

    }
}
