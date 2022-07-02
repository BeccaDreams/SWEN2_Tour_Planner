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
    public class DeleteLogCommand : BaseCommand
    {

        private ILoggerWrapper _logger;

        private readonly AddLogToTourViewModel _newLogData;
        public TourLogsViewModel _viewModel;
        LogController _logController;
        bool deleted;

        public DeleteLogCommand(TourLogsViewModel tourLogViewModel)
        {
            _logController = new LogController();
            _viewModel = tourLogViewModel;
            _logger = LoggerFactory.GetLogger("DeleteLogCommand");
        }

        public override async void Execute(object parameter)
        {
           try
            {
                deleted = _logController.Controller_deleteTourLog(_viewModel.SelectedLog);
                if (deleted)
                {
                    _logger.Debug("Log was deleted.");
                }
                else
                {
                    _logger.Debug("Failed deleting Log.");
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Exception adding Tour: " + ex.Message);
            }
        }
    }
}
