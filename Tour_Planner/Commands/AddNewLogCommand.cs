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
            _logger = LoggerFactory.GetLogger("AddNewTourCommand");

            _newLogData.PropertyChanged += OnViewModelPropertyChanged;
        }

        //Wenn Name, From und To vorhanden sind, dann wird der Button aktiv
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(AddLogToTourViewModel.LogDate)) || (e.PropertyName == nameof(AddLogToTourViewModel.Difficulty)) || (e.PropertyName == nameof(AddLogToTourViewModel.Rating)))
            {
                OnCanExecutedChanged();
            }
        }


        public override async void Execute(object parameter)
        {


            _log = new TourLog(_newLogData.LogDate, _newLogData.Comment, _newLogData.Difficulty, _newLogData.TotalTime, _newLogData.Rating, _newLogData.TourId);
            try
            {
                _logController.Controller_addTourLog(_log.TourId, _log);

            }
            catch (Exception ex)
            {
                _logger.Error("Exception adding Tour: " + ex.Message);
            }
        }



        //public override bool CanExecute(object parameter)
        //{
        //   // return !(_newLogData.LogDate) && !string.IsNullOrEmpty(_newLogData.Difficulty) && !string.IsNullOrEmpty(_newLogData.Rating) && base.CanExecute(parameter);
        //}
    }
}
