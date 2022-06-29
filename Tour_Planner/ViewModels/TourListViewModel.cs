using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;
using Shared.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Tour_Planner_BL.Controller;

namespace Tour_Planner.ViewModels
{
    public class TourListViewModel : BaseModel
    {
        private List<Tour> _tourList;
        private Tour _selectedTour;
        Tour_Planner_BL.ReportController _reportController;
        TourController _tourController;
        Window win1;

        public Tour SelectedTour
        {
            get { return _selectedTour; }
            set
            {
                _selectedTour = value;
                OnPropertyChanged(nameof(SelectedTour));
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        public ObservableCollection<Tour> TourNames { get; set; }

        public ICommand OpenAddTourWindow { get; set; }
        public ICommand TourReport{ get; set; }
        public ICommand SummarizeReport { get; set; }
        public ICommand EditTourCommand { get; set; }
        

        public TourListViewModel()
        {
            //AddTourToListViewModel subscribe = new AddTourToListViewModel();
           // subscribe.AddNewTourEvent += LoadTours();
            _tourController = new TourController();
            _tourList = new List<Tour>();
            _reportController = new Tour_Planner_BL.ReportController();


            var tour = new Tour { Name = "Vienna to Graz", Description = "Descrition 28.06.2022", From = "Vienna", To = "Graz", TransportType = "fastest" };
            var tourController = new TourController();
            tourController.Controller_addTour(tour);

            SetCommands();
            LoadTours();

        }

        public void EnableEditAndDeleteWindow()
        {
            IsEnabled = true;
        }

        public void DisplaySearchResult(string searchText)
        {
            
        }


        public void LoadTours()
        {
            _tourList = _tourController.Controller_getTours();
            TourNames = new ObservableCollection<Tour>(_tourList);
           
        }

        public void SetCommands()
        {
            OpenAddTourWindow = new RelayCommand((_) =>
            {
                Open_AddTourWindow();

            });


            TourReport = new RelayCommand((_) =>
            {
                GenerateTourReport();
            });

            SummarizeReport = new RelayCommand((_) =>
            {
                GenerateSummarizeReport();
            });

        }

        public void GenerateTourReport()
        {
            _reportController.GenerateTourReport(SelectedTour);
        }

        public void GenerateSummarizeReport()
        {
            _reportController.GenerateSummarizeReport();

        }

        public void Open_AddTourWindow()
        {
            this.win1 = new AddTourWindow();
            win1.Show();
        }

    }
}
