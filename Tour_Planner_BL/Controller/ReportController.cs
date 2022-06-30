using Shared.Models;
using Tour_Planner_DAL;

namespace Tour_Planner_BL.Controller
{
    public class ReportController
    {
        ReportGenerator _reportGenerator;

        public ReportController()
        {
            _reportGenerator = new ReportGenerator();
        }

        public void GenerateTourReport(Tour tour)
        {
            var tourLogDataHandler = new TourLogDataHandler();
            var logs = tourLogDataHandler.getTourLogsByTourId(tour.Id);

            _reportGenerator.GenerateTourReport(tour, logs);
        }

        public void GenerateSummarizeReport()
        {
            var tourDataHandler = new TourDataHandler();
            var tours = tourDataHandler.getTours();

            _reportGenerator.GenerateSummarizeReport(tours);
        }
    }
}
