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
    public class AddNewTourCommand : BaseCommand
    {
        private ILoggerWrapper _logger;

        private readonly AddTourToListViewModel _newTourData;
        public Tour _tour;
        TourController _tourController;


        public AddNewTourCommand(AddTourToListViewModel newTourData)
        {

            _newTourData = newTourData;
            _tourController = new TourController();
            _logger = LoggerFactory.GetLogger("AddNewTourCommand");

            _newTourData.PropertyChanged += OnViewModelPropertyChanged;
        }


        public override async void Execute(object parameter)
        {
            string routeType = SetTransportType(_newTourData.TransportType);
            _tour = new Tour(_newTourData.Name, _newTourData.Description, _newTourData.From, _newTourData.To, routeType, _newTourData.Distance, _newTourData.Time, _newTourData.RouteInformation);
            try
            {
                _tourController.Controller_addTour(_tour, false);
                _newTourData.FireDataChanged();
            }
            catch (Exception ex)
            {
                _logger.Error("Exception adding Tour: " + ex.Message);
            }
        }

        public string SetTransportType(string transportType)
        {
            string result;
            switch (transportType)
            {
                case "Walking":
                    result = "pedestrian";
                    break;
                case "Bicycle":
                    result = "bicycle";
                    break;
                default:
                    result = "fastest";
                    break;
            }
            return result;
        }


        //enable submit button only after all tour data are provided
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(AddTourToListViewModel.Name)) || (e.PropertyName == nameof(AddTourToListViewModel.From)) || (e.PropertyName == nameof(AddTourToListViewModel.To)) || (e.PropertyName == nameof(AddTourToListViewModel.TransportType)) || (e.PropertyName == nameof(AddTourToListViewModel.Description)))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_newTourData.Name) && !string.IsNullOrEmpty(_newTourData.From) && !string.IsNullOrEmpty(_newTourData.To) && !string.IsNullOrEmpty(_newTourData.TransportType) && !string.IsNullOrEmpty(_newTourData.Description) && base.CanExecute(parameter);
        }
    }
}
