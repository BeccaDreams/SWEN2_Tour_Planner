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

        //private SearchBarViewModel searchBar;
        //private TourDetailsViewModel tourDetailsView;
        //  private TourListViewModel tourListView;
        // private TourLogsViewModel tourLogsView;
        // private Tour currentTour;
        private SearchBarViewModel searchBar;
        public ObservableCollection<Tour> TourItems { get; set; }
            = new ObservableCollection<Tour>();

        //public ObservableCollection<TourList> Data { get; }
        //  = new ObservableCollection<TourList>();
        //public string TourName { get; set; }
        public MainViewModel()
        {
            TourItems.Add(new Tour("hey"));
            TourItems.Add(new Tour("test"));
            searchBar = new SearchBarViewModel();
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


            //this.searchBar = new SearchBarViewModel();
            //this.tourDetailsView = new TourDetailsViewModel();
            //this.tourListView = new TourListViewModel();
            //this.tourDetailsView = new TourDetailsViewModel();
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
