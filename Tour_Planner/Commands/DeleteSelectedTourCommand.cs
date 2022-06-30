using Shared.Logging;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.ViewModels;
using Tour_Planner_BL.Controller;

namespace Tour_Planner.Commands
{
    public class DeleteSelectedTourCommand : BaseCommand
    {
        private ILoggerWrapper _logger;

        private readonly TourListViewModel _deleteTour;
        public Tour _tour;
        TourController _tourController;
        bool isDeleted;

        public DeleteSelectedTourCommand(TourListViewModel selectedTour)
        {
            _deleteTour = selectedTour;
            _logger = LoggerFactory.GetLogger("DeleteSelectedTourCommand");
            _tourController = new TourController();

        }

        public override void Execute(object parameter)
        {
            _tour = _deleteTour.SelectedTour;
            isDeleted = _tourController.Controller_deleteTour(_tour);
            if (isDeleted)
            {
                _logger.Debug("Tour was deleted.");
            }
            else
            {
                _logger.Debug("Failed deleting tour.");
            }

        }
    }
}
