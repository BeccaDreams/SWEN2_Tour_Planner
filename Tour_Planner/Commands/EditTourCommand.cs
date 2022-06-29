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
        LogController _logController;

        public EditTourCommand(EditTourViewModel _changedTour)
        {
            _logger = LoggerFactory.GetLogger("EditTourCommand");
            _tourChanges = _changedTour;
        }
        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
