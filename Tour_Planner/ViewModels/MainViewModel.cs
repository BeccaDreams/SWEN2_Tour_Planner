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
using Tour_Planner.Commands;

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
        public EditLogViewModel EditLog;
        public EditTourViewModel EditTour;

     

        // Commands die funktionieren!
        public ICommand Search_Command { get; set;}

        //--------------------------------------------
        //TestCommands
       // public ICommand AddNewTourCommand { get; set; }
        public ICommand Add_Tour_Command { get; set; }
        public ICommand Delete_Tour_Command { get; set; }


    
        public MainViewModel(TourListViewModel tourList, TourLogsViewModel tourLogs, TourDetailsViewModel tourDetails, SearchBarViewModel searchBar, ToolBarViewModel toolbar)    
        {

            TourList = tourList;
            TourLogs = tourLogs;
            TourDetails = tourDetails;
            SearchBar = searchBar;
            ToolBar = toolbar;
            AddTourToList = new AddTourToListViewModel();
            AddLogToTourList = new AddLogToTourViewModel();
            EditLog = new EditLogViewModel();
            EditTour = new EditTourViewModel();

            Search_Command = new RelayCommand((_) =>
            {
                SearchBar.SearchFilter();
                UpdateList_SearchTourNames(SearchBar.SearchTourList);
                UpdateList_SearchDataLogs(SearchBar.SearchLogList);
            });

            //Add_Tour_Command = new RelayCommand((_) =>
            //{
            //    AddTourToList.AddNewTour();
            //    UpdateList_TourNames();
            //});

            Delete_Tour_Command = new RelayCommand((_) =>
            {
                TourList.DeleteSelectedTour();
                UpdateList_TourNames();
            });

            SearchBar.SearchCommand = Search_Command; //funktioniert
           // AddTourToList.SubmitCommand = Add_Tour_Command;
            TourList.DeleteTourCommand = Delete_Tour_Command;





            TourList.PropertyChanged += SelectedItem_PropertyChanged;

        }


       
        private void UpdateList_SearchTourNames(List<Tour> _tourList)
        {
            if(_tourList != null)
            {
                TourList.TourNames.Clear();
                if(_tourList.Count > 0)
                {
                    foreach (Tour tour in _tourList)
                    {
                        TourList.TourNames.Add(tour);
                    }
                }
                else
                {
                    TourList.ReloadTours();
                }
            }
        }

        public void UpdateList_SearchDataLogs(List<TourLog> _logList)
        {
            if(_logList != null && TourLogs.DataLogs != null && TourLogs.DataLogs.Count > 0)
            {
                TourLogs.DataLogs.Clear();
                foreach (TourLog log in _logList)
                {
                    TourLogs.DataLogs.Add(log);
                }
            }
        }

        public void UpdateList_TourNames()
        {
            if(TourList.TourNames.Count > 0)
            {
                TourList.TourNames.Clear();
            }
            TourList.ReloadTours();
        }

        public void UpdateList_DataLogs()
        {
            if (TourLogs.DataLogs.Count > 0)
            {
                TourLogs.DataLogs.Clear();
            }
            TourLogs.LoadLogs(TourList.SelectedTour.Id);
        }


        private void SelectedItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SelectedTour")
            {
                showDetails();
            }
            
           
        }

        private void SearchText_PrpopertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SearchText")
            {
                //Update TourNames & Logs
                SearchBar.SearchCommand.Execute(SearchBar.SearchText);
            }
        }

        public void showDetails()
        {
            EditTour.SetParameter(TourList.SelectedTour);
            TourList.EnableEditAndDeleteWindow();
            TourDetails.Title = TourList.SelectedTour.Name;
            TourDetails.DetailDescription = TourList.SelectedTour.Description;
            TourDetails.RouteInformation = TourList.SelectedTour.RouteInformation;
            TourLogs.LoadLogs(TourList.SelectedTour.Id);
            TourLogs.PropertyChanged += DataLogs_PropertyChanged;
            TourLogs.EnableAddWindow();
            TourLogs.SelectedTourId = TourList.SelectedTour.Id;
               
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
