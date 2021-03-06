using Shared.Logging;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.ViewModels;
using Tour_Planner_BL.Controller;

namespace Tour_Planner.Commands
{
    public class AddNewLogCommand : BaseCommand
    {

        private ILoggerWrapper _logger;

        private readonly AddLogToTourViewModel _newLogData;
        public TourLog _log;
        LogController _logController;
        bool added;

        public AddNewLogCommand(AddLogToTourViewModel newLogData)
        {
            _newLogData = newLogData;
            _logController = new LogController();
            _logger = LoggerFactory.GetLogger("AddNewLogCommand");

        }

      

        public override void Execute(object parameter)
        {
            try
            {
                TimeSpan duration;
                TimeSpan.TryParse(_newLogData.Duration, null, out duration);
                _newLogData.TotalTime = duration;
                var logDate = DateOnly.FromDateTime(_newLogData.LogDate);

                _log = new TourLog(logDate, _newLogData.Comment, _newLogData.Difficulty, _newLogData.TotalTime, _newLogData.Rating, _newLogData.TourId);

                added = _logController.Controller_addTourLog(_log.TourId, _log);
                if (added)
                {
                    _logger.Debug("Added new log.");
                }
                else
                {
                    _logger.Debug("Failed adding log.");
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Exception adding Tour: " + ex.Message);
            }
        }


   
    }
}
