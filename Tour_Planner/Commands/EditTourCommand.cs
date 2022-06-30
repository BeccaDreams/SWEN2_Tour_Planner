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
    public class EditTourCommand : BaseCommand
    {
        private ILoggerWrapper _logger;

        private readonly EditTourViewModel _tourChanges;
        public Tour _tour;
        TourController _tourController;

        public EditTourCommand(EditTourViewModel _changedTour)
        {
            _logger = LoggerFactory.GetLogger("EditTourCommand");
            _tourController = new TourController();
            _tourChanges = _changedTour;
        }
        public override void Execute(object parameter)
        {
            _tour = new Tour(_tourChanges.Name, _tourChanges.Description, _tourChanges.From, _tourChanges.To, _tourChanges.TransportType, _tourChanges.Distance, _tourChanges.Time, _tourChanges.RouteInformation);
            try
            {
                _tourController.Controller_addTour(_tour);
                _logger.Debug("Tour was edited.");

            }
            catch (Exception ex)
            {
                _logger.Error("Exception editing Tour: " + ex.Message);
            }
        }
    }
}
