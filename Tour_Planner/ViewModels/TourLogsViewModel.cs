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

        private ObservableCollection<TourLog> _dataLogs;
        public ObservableCollection<TourLog> DataLogs {
            get { return _dataLogs; }
            set 
            {
                _dataLogs = value;
                OnPropertyChanged(nameof(DataLogs));
            }
        }

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

        private int _selectedTourId;
        public int SelectedTourId
        {
            get { return _selectedTourId; }
            set
            {
                _selectedTourId = value;
                OnPropertyChanged(nameof(SelectedTourId));
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
        public ICommand DeleteSelectedLog { get; set; }

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

        public void ClearLogs()
        {
            if(DataLogs != null)
            DataLogs.Clear();
        }

        public void EnableAddWindow()
        {
            if(IsEnabled != true)
            IsEnabled = true;
        }

        public void DisableAddWindow()
        {
            if(IsEnabled != false)
            IsEnabled = false;
        }

        public void Open_AddLogWindow()
        {
            this.win1 = new AddLogWindow(SelectedTourId);
            win1.Show();
        }

        public void Open_EditLogWindow()
        {
            this.win2 = new LogEditView(SelectedLog);
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

            DeleteSelectedLog = new DeleteLogCommand(this);
        }



    }
}
