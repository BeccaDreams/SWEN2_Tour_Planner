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
using System.Windows;
using Tour_Planner_BL;
using System.Windows.Input;

namespace Tour_Planner.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //private static ILoggerWrapper logger = log4net.LogManager.GetLogger("MainViewModel");
        //private static ILoggerWrapper logger;

        TourController tourController;

        public TourListViewModel TourList;
        public TourLogsViewModel TourLogs;
        public TourDetailsViewModel TourDetails;
        public SearchBarViewModel SearchBar;
        public AddTourToListViewModel AddTourToList;

        Window win2;

        public RelayCommand AddNewTourCommand { get; set; }

        //public string AddNewTourName;

        private string _addtourName = "";
        public string AddNewTourName
        {
            get { return _addtourName; }
            set
            {
                try
                {
                    _addtourName = value;
                    OnPropertyChanged("AddNewTourName");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }


        public string AddNewFrom;
        public string AddNewTo;
        public ObservableCollection<Tour> TourItems { get; set; }
            = new ObservableCollection<Tour>();

        public ObservableCollection<TourLog> Logs { get; set; }
            = new ObservableCollection<TourLog>();

        public RelayCommand OpenAddWindow { get; set; }

        //public string TourName { get; set; }

        public MainViewModel()
        {
            TourList = new TourListViewModel();
            TourLogs = new TourLogsViewModel();
            TourDetails = new TourDetailsViewModel();
            SearchBar = new SearchBarViewModel();
            AddTourToList = new AddTourToListViewModel();

            AddNewTourName = AddTourToList.AddTourName;
            AddNewFrom = AddTourToList.AddFrom;
            AddNewTo = AddTourToList.AddTo;

            TourItems = TourList.TourNames;
            Logs = TourLogs.DataLogs;

            OpenAddWindow = new RelayCommand((_) =>
            {
                Open_AddWindow();
                
            });

            AddNewTourCommand = new RelayCommand((_) =>
            {
               
                if (AddNewTourName != null)
                {
                    Tour newAddedTour = new Tour(AddNewTourName, AddNewFrom, AddNewTo);
                   
                    TourItems.Add(newAddedTour);
                }
                if (AddTourToList.AddTourName != null)
                {
                    Tour newTour = new Tour(AddTourToList.AddTourName, AddNewFrom, AddNewTo);
                    
                    TourItems.Add(newTour);
                }
                else
                {
                    
                    TourItems.Add(new Tour("was anderes","from","to"));

                }
               // Close_AddWindow();


            });
            
        }

        public void Open_AddWindow()
        {
            this.win2 = new AddTourWindow();
            win2.Show();
        }

        public void Close_AddWindow()
        {
            if(this.win2 != null)
            win2.Close();
        }
   
            
        public MainViewModel(TourListViewModel tourList, TourLogsViewModel tourLogs, TourDetailsViewModel tourDetails, SearchBarViewModel searchBar)    
        {
           
            //searchBar = new SearchBarViewModel();

            TourList = tourList;
            TourLogs = tourLogs;
            TourDetails = tourDetails;
            SearchBar = searchBar;

            TourItems = TourList.TourNames;


            Logs = TourLogs.DataLogs;

            tourController = new TourController();

            
            

            //searchBar.SearchTextChanged += (_, searchText) =>
            //{
            //    //SearchTours(searchText);
            //};

           

            //log4net.Config.XmlConfigurator.Configure(new FileInfo("./log4net.config"));
            //logger.Debug("created()");
            //logger.Debug($"OnPropertyChanged() propertyName={propertyName}");
            //h ttps://logging.apache.org/log4net/release/manual/configuration.html 


        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
