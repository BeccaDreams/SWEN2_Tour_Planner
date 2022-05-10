using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;

namespace Tour_Planner.ViewModels
{
    public class TourDetailsViewModel : BaseViewModel
    {
        public String Title { get; set; }

        public TourDetailsViewModel()
        {
            Title = "Testtitle";
            OnPropertyChanged();
        }
    }
}
