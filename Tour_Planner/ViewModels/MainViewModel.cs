using System;
using System.Collections.Generic;
using System.IO;
using Shared.Logging;
using Tour_Planner.Views;
using log4net;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

using Tour_Planner_BL;
using System.Windows.Input;
using Shared.Models;
using Tour_Planner_BL.Controller;
using System.Windows.Data;

namespace Tour_Planner.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //private static ILoggerWrapper logger = log4net.LogManager.GetLogger("MainViewModel");
        //private static ILoggerWrapper logger;


        public TourListViewModel TourList;
        public TourLogsViewModel TourLogs;
        public TourDetailsViewModel TourDetails;
        public SearchBarViewModel SearchBar;
        public AddTourToListViewModel AddTourToList;
        public AddLogToTourViewModel AddLogToTourList;
        public ToolBarViewModel ToolBar;


        public RelayCommand AddNewTourCommand { get; set; }
        public RelayCommand AddNewLogCommand { get; set; }

        public ObservableCollection<Tour> TourItems { get; set; }
            = new ObservableCollection<Tour>();

        public ObservableCollection<TourLog> Logs { get; set; }
            = new ObservableCollection<TourLog>();

        public RelayCommand OpenAddTourWindow { get; set; }
        public RelayCommand OpenAddLogWindow { get; set; }

        public Tour selectedTour;
       
        
    
        public MainViewModel(TourListViewModel tourList, TourLogsViewModel tourLogs, TourDetailsViewModel tourDetails, SearchBarViewModel searchBar, ToolBarViewModel toolbar)    
        {


            TourList = tourList;
            TourLogs = tourLogs;
            TourDetails = tourDetails;
            SearchBar = searchBar;
            ToolBar = toolbar;
            AddTourToList = new AddTourToListViewModel();

          //  TourLogs.LoadLogs(1);
           
            this.selectedTour = TourList.SelectedTour;
            TourList.PropertyChanged += SelectedItem_PropertyChanged;

            TourList.PropertyChanged += TourNames_PropertyChanged;

        }

       
        private void SelectedItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SelectedTour")
            {
                showDetails();
            }
        }

        public void showDetails()
        {
            TourList.EnableEditAndDeleteWindow();
            TourDetails.Title = TourList.SelectedTour.Name;
            TourDetails.DetailDescription = TourList.SelectedTour.Description;
            TourDetails.RouteInformation = TourList.SelectedTour.RouteInformation;
            TourLogs.LoadLogs(TourList.SelectedTour.Id);
            TourLogs.PropertyChanged += DataLogs_PropertyChanged;
            TourLogs.EnableAddWindow();
            AddLogToTourList = new AddLogToTourViewModel();
            AddLogToTourList.TourId = TourList.SelectedTour.Id;
            TourList.LoadTours();
        }

        public void TourNames_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "TourNames")
            {
                TourList.LoadTours();
            }
        }

        public void DataLogs_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "DataLogs")
            {
                CollectionViewSource.GetDefaultView(TourLogs.DataLogs).Refresh();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
