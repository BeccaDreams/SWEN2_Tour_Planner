using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;
using Tour_Planner.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Tour_Planner.ViewModels
{
    public class TourListViewModel : BaseModel
    {
        
        public ObservableCollection<Tour> TourNames { get; set; }
          = new ObservableCollection<Tour>();
        
        public RelayCommand AddTourCommand;
        

      //  public event EventHandler<Tour> AddTourNameEvent;

        public TourListViewModel()
        {
            
            LoadData();

            AddTourCommand = new RelayCommand((_) =>
            {
               
            });
            
        }

        private void LoadData()
        {
            TourNames.Clear();
            TourNames.Add(new Tour("Testtour", "testfrom", "testto"));
            TourNames.Add(new Tour("Testtour2", "testfrom", "testto"));
            TourNames.Add(new Tour("Testtour3", "testfrom", "testto"));
            TourNames.Add(new Tour("Testtour4", "testfrom", "testto"));
        }

        private void AddNewTour()
        {

        }


       


    }
}
