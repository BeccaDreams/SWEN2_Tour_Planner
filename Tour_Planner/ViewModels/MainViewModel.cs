﻿using System;
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
//using Tour_Planner.SearchEngine;

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
       // public readonly ISearchEngine searchEngine;

        /* --------------------------------------------------------------------------------*/
        //sollte ausgebessert werden, das gehört hier nicht her.
        private string _addtourName;
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

        private string _addfrom;
        public string AddNewFrom
        {
            get { return _addfrom; }
            set
            {
                try
                {
                    _addfrom = value;
                    OnPropertyChanged("AddNewFrom");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private string _addto;
        public string AddNewTo
        {
            get { return _addto; }
            set
            {
                try
                {
                    _addto = value;
                    OnPropertyChanged("AddNewTo");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        /* --------------------------------------------------------------------------------*/
        public ObservableCollection<Tour> TourItems { get; set; }
            = new ObservableCollection<Tour>();

        public ObservableCollection<TourLog> Logs { get; set; }
            = new ObservableCollection<TourLog>();

        public RelayCommand OpenAddWindow { get; set; }


        public MainViewModel()
        {
            TourList = new TourListViewModel();
            TourLogs = new TourLogsViewModel();
            TourDetails = new TourDetailsViewModel();
            SearchBar = new SearchBarViewModel();
            AddTourToList = new AddTourToListViewModel();
            tourController = new TourController();

          
            TourItems = TourList.TourNames;
            Logs = TourLogs.DataLogs;

            SetAllCommands();


            OpenAddWindow = new RelayCommand((_) =>
            {
                Open_AddWindow();
                
            });

            AddNewTourCommand = new RelayCommand((_) =>
            {
               TourItems.Add(new Tour("was anderes", "from", "to"));
                Console.WriteLine(TourItems.Count);
                //if (AddNewTourName != null)
                //{
                //    Tour newAddedTour = new Tour(AddNewTourName, AddNewFrom, AddNewTo);

                //    TourItems.Add(newAddedTour);
                //}
                //else
                //{

                //    TourItems.Add(new Tour("was anderes","from","to"));

                //}
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

        public void SetAllCommands()
        {
            OpenAddWindow = new RelayCommand((_) =>
            {
                Open_AddWindow();

            });

            AddNewTourCommand = new RelayCommand((_) =>
            {
                TourItems.Add(new Tour("was anderes", "from", "to"));
                Console.WriteLine(TourItems.Count);
                //if (AddNewTourName != null)
                //{
                //    Tour newAddedTour = new Tour(AddNewTourName, AddNewFrom, AddNewTo);

                //    TourItems.Add(newAddedTour);
                //}
                //else
                //{

                //    TourItems.Add(new Tour("was anderes","from","to"));

                //}
                // Close_AddWindow();


            });

            //SearchBar.SearchTextChanged += (_, searchText) =>
            //{
            //    SearchTours(searchText);
            //    SearchLogs(searchText);
            //};
          //  this.resultToursView = result
           // this.resultLogsView = resultView;
           // this.searchEngine = searchEngine;

        }

        //public void SearchTours(string text)
        //{
        //    var results = this.searchEngine.SearchFor(text);
        //}

        //public void SearchLogs(string text)
        //{
        //    var results = this.searchEngine.SearchFor(text);
        //}


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
