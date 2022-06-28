using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;
using System.Collections.ObjectModel;
using Shared.Models;
using System.Windows;
using System.Windows.Input;
using Tour_Planner_BL.Controller;

namespace Tour_Planner.ViewModels
{
    public class TourLogsViewModel : BaseModel 
    {
        public List<TourLog> _logList;
        public ObservableCollection<TourLog> DataLogs { get; set; }

        public LogController _logController;
        Window win2;

        public ICommand OpenAddLogWindow { get; set; }

        public TourLogsViewModel()
        {
            _logController = new LogController();
            _logList = new List<TourLog>();
            LoadLogs();
            SetCommands();
        }

        private void LoadLogs()
        {
            //DataLogs.Clear();
            //DataLogs.Add(new TourLog("13.12.22", "12min", 2, "22km", 4));
            //DataLogs.Add(new TourLog("12.12.22", "12min", 3, "22km", 3));
            //DataLogs.Add(new TourLog("11.12.22", "12min", 1, "22km", 5));

            //hier selecteditem einfügen
            _logList = _logController.Controller_getTourLogsByTourId(1);
            DataLogs = new ObservableCollection<TourLog>(_logList);
        }

        public void Open_AddLogWindow()
        {
            this.win2 = new AddLogWindow();
            win2.Show();
        }

        public void SetCommands()
        {
            OpenAddLogWindow = new RelayCommand((_) =>
            {
                Open_AddLogWindow();

            });
        }



    }
}
