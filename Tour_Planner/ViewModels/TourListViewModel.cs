using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;
using Shared.Models;
using System.Collections.ObjectModel;
using System.Windows;
using Tour_Planner_BL;

namespace Tour_Planner.ViewModels
{
    public class TourListViewModel : BaseModel
    {

        public ObservableCollection<Tour> TourNames { get; }
          = new ObservableCollection<Tour>();
        private void AddTourWin(object sender, RoutedEventArgs e)
        {
            AddTourWindow win2 = new AddTourWindow();
            win2.Show();
        }
        public RelayCommand AddTourCommand;
        public string NewTourName = "bla";

        public TourListViewModel()
        {
            
            LoadData();

            AddTourCommand = new RelayCommand((_) =>
            {
                TourNames.Add(new Tour(this.NewTourName));
                NewTourName = string.Empty;
                OnPropertyChanged(nameof(NewTourName));
            });
            
        }

        private void LoadData()
        {
            TourNames.Clear();
            TourNames.Add(new Tour("Testtour"));
            TourNames.Add(new Tour("Testtour2"));
            TourNames.Add(new Tour("Testtour3"));
            TourNames.Add(new Tour("Testtour4"));

            var client = new MapQuestClient();
            client.GetDistance("Vienna, AT", "Salzburg, AT");
        }


    }
}
