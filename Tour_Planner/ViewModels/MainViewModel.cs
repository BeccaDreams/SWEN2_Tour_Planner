using System;
using System.Collections.Generic;
using System.IO;
using Tour_Planner.Logging;
using Tour_Planner.Views;
using log4net;
using System.Collections.ObjectModel;
using Tour_Planner.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        public ObservableCollection<Tour> TourItems { get; set; }
            = new ObservableCollection<Tour>();

        public ObservableCollection<TourLog> Logs { get; set; }
            = new ObservableCollection<TourLog>();


        //public string TourName { get; set; }
        public MainViewModel(TourListViewModel tourList, TourLogsViewModel tourLogs, TourDetailsViewModel tourDetails, SearchBarViewModel searchBar)
        {
           
            //searchBar = new SearchBarViewModel();

            TourList = tourList;
            TourLogs = tourLogs;
            TourDetails = tourDetails;
            SearchBar = searchBar;

            TourItems = TourList.TourNames;
            Logs = TourLogs.DataLogs;

           

            //searchBar.SearchTextChanged += (_, searchText) =>
            //{
            //    //SearchTours(searchText);
            //};
            //TourItems = new ObservableCollection<Tour>();
            //FillTourList();
            //log4net.Config.XmlConfigurator.Configure(new FileInfo("./log4net.config"));
            //logger.Debug("created()");
            //logger.Debug($"OnPropertyChanged() propertyName={propertyName}");
            //h ttps://logging.apache.org/log4net/release/manual/configuration.html 


        }

        public MainViewModel()
        {
            TourList = new TourListViewModel();
            TourLogs = new TourLogsViewModel();
            TourDetails = new TourDetailsViewModel();
            SearchBar = new SearchBarViewModel();

            TourItems = TourList.TourNames;
            Logs = TourLogs.DataLogs;

            TourItems.Add(new Tour("Ttest"));
        }

        private void FillTourList()
        {
            //foreach(Tour tour in TourItems)
            //{
            //mit DB Liste füllen
            //
           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
