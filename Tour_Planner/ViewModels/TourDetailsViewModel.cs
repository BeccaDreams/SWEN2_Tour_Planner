using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;

namespace Tour_Planner.ViewModels
{
    public class TourDetailsViewModel : BaseModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set 
            {
                try
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
                }
        }

        private string _detailDescription;
        public string DetailDescription
        {
            get { return _detailDescription; }
            set
            {
                try
                {
                    _title = value;
                    OnPropertyChanged(nameof(DetailDescription));
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
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

        public RelayCommand GetOnSelectedItem;

        public TourDetailsViewModel()
        {
           //RelayCommand
        }



    }
}
