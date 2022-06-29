using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tour_Planner.ViewModels;

namespace Tour_Planner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var tourList = new TourListViewModel(); 
            var tourLogs = new TourLogsViewModel();
            var tourDetails = new TourDetailsViewModel();
            var searchBar = new SearchBarViewModel();
            var toolBar = new ToolBarViewModel();


            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(tourList, tourLogs, tourDetails, searchBar),
                TourList = { DataContext = tourList },
                SearchBar = { DataContext = searchBar },
                TourLogs = { DataContext = tourLogs },
                TourDetails = { DataContext = tourDetails },
                ToolBar = { DataContext = toolBar }
            };
            MainWindow.Show();
        }
    }
}
