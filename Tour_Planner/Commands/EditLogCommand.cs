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
        bool edited;

        public EditLogCommand(EditLogViewModel changedLog)
        {
            _logController = new LogController();
            _logger = LoggerFactory.GetLogger("EditLogCommand");
            _logChanges = changedLog;
        }
        public override void Execute(object parameter)
        {
            //_log = new TourLog(_logChanges.LogDate, _logChanges.Comment, _logChanges.Difficulty, _logChanges.TotalTime, _logChanges.Rating, _logChanges.TourId);
            _log = new TourLog
            {
                Id = _logChanges.Id,
                LogDate = _logChanges.LogDate,
                Comment = _logChanges.Comment,
                Difficulty = _logChanges.Difficulty,
                TotalTime = _logChanges.TotalTime,
                TourId = _logChanges.TourId,
                Rating = _logChanges.Rating
            };

            try
            {
                edited = _logController.Controller_updateTourLog(_log);
                if (edited)
                {
                    _logger.Debug("Log was edited.");
                }
                else
                {
                    _logger.Debug("Failed editing log.");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Exception editing Log: " + ex.Message);
            }
        }
    }
}
