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
        public Tour SelectedTour
        {
            get { return _selectedTour; }
            set
            {
                _selectedTour = value;
                OnPropertyChanged(nameof(SelectedTour));
            }
        }
            
        
        public ObservableCollection<Tour> TourNames { get; set; }

        TourController _tourController;
        Window win1;

        public ICommand OpenAddTourWindow { get; set; }

        public TourListViewModel()
        {
            //AddTourToListViewModel subscribe = new AddTourToListViewModel();
           // subscribe.AddNewTourEvent += LoadTours();
            _tourController = new TourController();
            _tourList = new List<Tour>();

            SetCommands();
            LoadTours();

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
        }

        public void Open_AddTourWindow()
        {
            this.win1 = new AddTourWindow();
            win1.Show();
        }

    }
}
