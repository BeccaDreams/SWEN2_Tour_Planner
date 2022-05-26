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
        public String Title { get; set; }

        public TourDetailsViewModel()
        {
            Title = "Testtitle";
            OnPropertyChanged();
        }
    }
}
