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
    public class EditLogCommand : BaseCommand
    {
        private ILoggerWrapper _logger;

        private readonly EditLogViewModel _logChanges;
        public TourLog _log;
        LogController _logController;

        public EditLogCommand(EditLogViewModel changedLog)
        {
            _logController = new LogController();
            _logger = LoggerFactory.GetLogger("EditLogCommand");
            _logChanges = changedLog;
        }
        public override async void Execute(object parameter)
        {
            _log = new TourLog(_logChanges.LogDate, _logChanges.Comment, _logChanges.Difficulty, _logChanges.TotalTime, _logChanges.Rating, _logChanges.TourId);
            try
            {
                _logController.Controller_addTourLog(_log.TourId, _log);

            }
            catch (Exception ex)
            {
                _logger.Error("Exception adding Tour: " + ex.Message);
            }
        }
    }
}
