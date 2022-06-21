using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;
using Tour_Planner.Models;
using System.Collections.ObjectModel;

namespace Tour_Planner.ViewModels
{
    public class TourListViewModel : BaseModel
    {

        public ObservableCollection<Tour> TourNames { get; }
          = new ObservableCollection<Tour>();


        public TourListViewModel()
        {
            
            LoadData();
            
        }

        private void LoadData()
        {
            TourNames.Clear();
            TourNames.Add(new Tour("Testtour"));
            TourNames.Add(new Tour("Testtour2"));
            TourNames.Add(new Tour("Testtour3"));
            TourNames.Add(new Tour("Testtour4"));
        }


    }
}
