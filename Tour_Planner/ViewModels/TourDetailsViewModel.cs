using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;
using Tour_Planner.Models;

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
                    OnPropertyChanged("Title");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
                }
        }

        public RelayCommand GetOnSelectedItem;

        public TourDetailsViewModel()
        {
           //RelayCommand
        }



    }
}
