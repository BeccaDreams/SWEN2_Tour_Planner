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
    public class AddNewLog : BaseCommand
    {
        private ILoggerWrapper _logger;

        private readonly AddLogToTourViewModel _newLog;
        public TourLog _log;
        LogController _logController;
        bool addedLog;

        public AddNewLog(AddLogToTourViewModel newLog)
        {
            _newLog = newLog;
            _logger = LoggerFactory.GetLogger("AddNewLogCommand");
            _logController = new LogController();

            _newLog.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override async void Execute(object parameter)
        {
            try
            {
                _log = new TourLog(_newLog.LogDate, _newLog.Comment, _newLog.Difficulty, _newLog.TotalTime, _newLog.Rating, _newLog.TourId);

                addedLog = _logController.Controller_addTourLog(_log.TourId, _log);
                if (addedLog)
                {
                    _logger.Debug("Added new Log");
                }
                else
                {
                    _logger.Debug("Failed adding new Log");
                }
            }
            catch(Exception ex)
            {
                _logger.Error("Exception from AddNewLogCommand: " + ex.Message);
            }
           
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
          
                OnCanExecutedChanged();
            
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }
    }
}
