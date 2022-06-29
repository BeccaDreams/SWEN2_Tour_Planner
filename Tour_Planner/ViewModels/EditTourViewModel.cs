using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tour_Planner.Commands;

namespace Tour_Planner.ViewModels
{
    public class EditTourViewModel : BaseModel
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _from;
        public string From
        {
            get { return _from; }
            set
            {
                _from = value;
                OnPropertyChanged(nameof(From));
            }
        }

        private string _to;
        public string To
        {
            get { return _to; }
            set
            {
                _to = value;
                OnPropertyChanged(nameof(To));
            }
        }

        private string _transportType;
        public string TransportType
        {
            get { return _transportType; }
            set
            {
                _transportType = value;
                OnPropertyChanged(nameof(TransportType));
            }
        }

        private double _distance;
        public double Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                OnPropertyChanged(nameof(Distance));
            }
        }

        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        private string _routeInformation;
        public string RouteInformation
        {
            get { return _routeInformation; }
            set
            {
                _routeInformation = value;
                OnPropertyChanged(nameof(RouteInformation));
            }
        }

        public ICommand Edit_TourCommand { get; set; }

        public EditTourViewModel()
        {
            Edit_TourCommand = new EditTourCommand(this);
        }



    }
}
