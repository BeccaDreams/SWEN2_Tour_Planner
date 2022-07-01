using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Shared.Models;
using Tour_Planner.Commands;

namespace Tour_Planner.ViewModels
{
    public class AddTourToListViewModel : BaseModel, IDataErrorInfo
    {
        public event Action SubmitCommandEvent;
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();


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

        public ICommand SubmitCommand { get; set; }


        public AddTourToListViewModel()
        {

            SubmitCommand = new AddNewTourCommand(this);


        }

        static bool typeCheckLong(string UserInput)
        {
            long num = 0;
            return long.TryParse(UserInput, out num);
        }

        public string this[string input]
        {

            get
            {
                string result = null;
                switch (input)
                {
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name))
                            result = "Tour name cannot be empty";
                        else if (Name.Length < 5)
                            result = "Tour name must be a mnimum of 5 characters";
                        else if (typeCheckLong(Name) == true)
                            result = "Tour name must consist of letters.";
                        break;

                    case "From":
                        if (string.IsNullOrWhiteSpace(From))
                            result = "Start point cannot be empty, please enter a valid city";
                        else if (typeCheckLong(From) == true)
                            result = "Start point must consist of letters, please enter a valid city";
                        break;

                    case "To":
                        if (string.IsNullOrWhiteSpace(To))
                            result = "Destination cannot be empty, please enter a valid city";
                        else if (typeCheckLong(To) == true)
                            result = "Destination must consist of letters, please enter a valid city.";
                        break;

                    case "TransportType":
                        if (string.IsNullOrWhiteSpace(TransportType))
                            result = "Transport Type cannot be empty";
                        break;

                    case "Description":
                        if (string.IsNullOrWhiteSpace(Description))
                            result = "Description cannot be empty";
                        else if (typeCheckLong(Description) == true)
                            result = "Description must consist of letters.";
                        break;
                }

                if (ErrorCollection.ContainsKey(input))
                    ErrorCollection[input] = result;
                else if (result != null)
                    ErrorCollection.Add(input, result);

                OnPropertyChanged("ErrorCollection");
                return result;

            }
        }

    }
}
