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
//using Tour_Planner.SearchEngine;

namespace Tour_Planner.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //private static ILoggerWrapper logger = log4net.LogManager.GetLogger("MainViewModel");
        //private static ILoggerWrapper logger;

        TourController tourController;
        MapQuestClient tourMapClient;

        public TourListViewModel TourList;
        public TourLogsViewModel TourLogs;
        public TourDetailsViewModel TourDetails;
        public SearchBarViewModel SearchBar;
        public AddTourToListViewModel AddTourToList;

        Tour tmpTour;

        Window win1, win2;

        public RelayCommand AddNewTourCommand { get; set; }
       
       
        public ObservableCollection<Tour> TourItems { get; set; }
            = new ObservableCollection<Tour>();

        public ObservableCollection<TourLog> Logs { get; set; }
            = new ObservableCollection<TourLog>();

        public RelayCommand OpenAddTourWindow { get; set; }
        public RelayCommand OpenAddLogWindow { get; set; }

        public Tour selectedTour;
    
        public MainViewModel(TourListViewModel tourList, TourLogsViewModel tourLogs, TourDetailsViewModel tourDetails, SearchBarViewModel searchBar)    
        {


            TourList = tourList;
            TourLogs = tourLogs;
            TourDetails = tourDetails;
            SearchBar = searchBar;
            AddTourToList = new AddTourToListViewModel();
            tourController = new TourController();

            this.selectedTour = TourList.SelectedTour;
   
           // Logs = TourLogs.DataLogs;
            tmpTour = new Tour();

            

        }

       


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
