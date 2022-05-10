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

        public SearchBarViewModel searchBar;
        public TourDetailsViewModel tourDetailsView;
        public TourListViewModel tourListView;
        public TourLogsViewModel tourLogsView;

        public ObservableCollection<TourList> Data { get; }
            = new ObservableCollection<TourList>();
        public string TourName { get; set; }
        public MainViewModel()
        {
            //log4net.Config.XmlConfigurator.Configure(new FileInfo("./log4net.config"));
            //logger.Debug("created()");
            //logger.Debug($"OnPropertyChanged() propertyName={propertyName}");
            //h ttps://logging.apache.org/log4net/release/manual/configuration.html

            
            this.searchBar = new SearchBarViewModel();
            this.tourDetailsView = new TourDetailsViewModel();
            this.tourListView = new TourListViewModel();
            this.tourDetailsView = new TourDetailsViewModel();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
