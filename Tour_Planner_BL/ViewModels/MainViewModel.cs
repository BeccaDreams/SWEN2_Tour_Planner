using System;
using System.Collections.Generic;
using System.IO;
using Tour_Planner.Logging;
using Tour_Planner.Views;
using log4net;

namespace Tour_Planner
{
    public class MainViewModel : BaseViewModel
    {
        //private static ILoggerWrapper logger = log4net.LogManager.GetLogger("MainViewModel");
        private static ILoggerWrapper logger;

        private SearchBarViewModel searchBar;
        private TourDetailsViewModel tourDetailsView;
        private TourListViewModel tourListView;
        private TourLogsViewModel tourLogsView;

        public MainViewModel()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("./log4net.config"));
            logger.Debug("created()");
            //logger.Debug($"OnPropertyChanged() propertyName={propertyName}");
            //h ttps://logging.apache.org/log4net/release/manual/configuration.html
        }
    }
}
