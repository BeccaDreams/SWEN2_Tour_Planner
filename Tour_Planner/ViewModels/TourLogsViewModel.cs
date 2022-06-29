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
using Tour_Planner.Commands;

namespace Tour_Planner.ViewModels
{
    public class TourLogsViewModel : BaseModel 
    {
        public List<TourLog> _logList;
        public ObservableCollection<TourLog> DataLogs { get; set; }

        public LogController _logController;
        Window win1, win2;

        private TourLog _selectedLog;
        public TourLog SelectedLog
        {
            get { return _selectedLog; }
            set
            {
                _selectedLog = value;
                OnPropertyChanged(nameof(SelectedLog));
            }
        }

        public int tourID;

        private bool _isEnabled;
        public bool IsEnabled 
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        public ICommand OpenAddLogWindow { get; set; }
        public ICommand OpenEditLogWindow { get; set; }
        public ICommand DeleteSelectedItem { get; set; }

        public TourLogsViewModel()
        {
            _logController = new LogController();
            _logList = new List<TourLog>();
            IsEnabled = false;
            SetCommands();
        }

        public void LoadLogs(int id)
        {
            _logList = _logController.Controller_getTourLogsByTourId(id);
            DataLogs = new ObservableCollection<TourLog>(_logList);
        }

        public void EnableAddWindow()
        {
            IsEnabled = true;
        }

        public void Open_AddLogWindow()
        {
            this.win1 = new AddLogWindow();
            win1.Show();
        }

        public void Open_EditLogWindow()
        {
            this.win2 = new LogEditView();
            win2.Show();
        }

        public void SetCommands()
        {
            OpenAddLogWindow = new RelayCommand((_) =>
            {
                Open_AddLogWindow();

            });

            OpenEditLogWindow = new RelayCommand((_) =>
            {
                Open_EditLogWindow();
            });

            DeleteSelectedItem = new DeleteLogCommand(this.SelectedLog);
        }



    }
}
