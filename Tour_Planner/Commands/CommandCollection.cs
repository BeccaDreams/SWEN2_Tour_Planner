using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.ViewModels;
using Shared.Models;
using Tour_Planner_BL;
using System.Windows;
using Shared.Logging;
using System.ComponentModel;

namespace Tour_Planner.Commands
{
    public class AddNewTourCommand : BaseCommand
    {
        private ILoggerWrapper _logger;

        private readonly AddTourToListViewModel _newTourData;
        public Tour _tour;
        TourController _tourController;
        MapQuestClient _client;
        bool added;

        
        public AddNewTourCommand(AddTourToListViewModel newTourData)
        {
            
            _newTourData = newTourData;
            _tourController = new TourController();
            _client = new MapQuestClient();
            _logger = LoggerFactory.GetLogger("AddNewTourCommand");

            _newTourData.PropertyChanged += OnViewModelPropertyChanged;
        }


        public override async void Execute(object parameter)
        {
            string routeType = SetTransportType(_newTourData.TransportType);
            _newTourData.ImgLocation = await _client.GetMapQuestStaticMap(_newTourData.From, _newTourData.To, routeType);
            //    _newTourData.Distance = _client.GetDistance();
            _tour = new Tour(_newTourData.Name, _newTourData.Description, _newTourData.From, _newTourData.To, _newTourData.TransportType, _newTourData.Distance, _newTourData.Time, _newTourData.RouteInformation);
            try
            {
                added = _tourController.Controller_addTour(_tour);
                if (added)
                {
                    _logger.Debug("New Tour added");
                }
                else
                {
                    _logger.Error("Exception adding Tour!");
                }

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


        //Wenn Name, From und To vorhanden sind, dann wird der Button aktiv
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        { 
            if((e.PropertyName == nameof(AddTourToListViewModel.Name)) || (e.PropertyName == nameof(AddTourToListViewModel.From)) || (e.PropertyName == nameof(AddTourToListViewModel.To)))
            {
                OnCanExecutedChanged();
            } 
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_newTourData.Name) && !string.IsNullOrEmpty(_newTourData.From) && !string.IsNullOrEmpty(_newTourData.To) && base.CanExecute(parameter);
        }
    }

  
}
