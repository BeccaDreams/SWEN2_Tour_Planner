using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;
using Shared.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Tour_Planner_BL.Controller;
using Tour_Planner.Commands;
using System.Windows.Data;
using Shared.Logging;

namespace Tour_Planner.ViewModels
{
    public class TourListViewModel : BaseModel
    {
        private ILoggerWrapper _logger;
        private List<Tour> _tourList;
        private Tour _selectedTour;
        ReportController _reportController;
        TourController _tourController;
        Window win1;
        Window win2;

        public Tour SelectedTour
        {
            get { return _selectedTour; }
            set
            {
                _selectedTour = value;
                OnPropertyChanged(nameof(SelectedTour));
            }
        }


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

        public ObservableCollection<Tour> TourNames { get; set; }

        public ICommand OpenAddTourWindow { get; set; }
        public ICommand TourReport{ get; set; }
        public ICommand SummarizeReport { get; set; }
        public ICommand TestCommand { get; set; }
        public ICommand DeleteTourCommand { get; set; }
        public ICommand OpenEditTourCommand { get; set; }

        public TourListViewModel()
        {
           
            _tourController = new TourController();
            _tourList = new List<Tour>();
            _reportController = new ReportController();
            _logger = LoggerFactory.GetLogger("TourListViewModel");

            SetCommands();
            LoadTours();

        }

        public void EnableEditAndDeleteWindow()
        {
            IsEnabled = true;
        }

        public void DisableEditAndDeleteWindow()
        {
            IsEnabled= false;
        }

       

        public void LoadTours()
        {
            _tourList = _tourController.Controller_getTours();
            TourNames = new ObservableCollection<Tour>(_tourList);
        }

        public void ReloadTours()
        {
            _tourList = _tourController.Controller_getTours();
            foreach(Tour tour in _tourList)
            {
                TourNames.Add(tour);
            }
        }

        public void List_DataChanged(object sender, EventArgs e)
        {
            Task.Delay(3000).ContinueWith(t => 
            {
                Application.Current.Dispatcher.Invoke(new Action(() => { TourNames.Clear(); }));

                _tourList = _tourController.Controller_getTours();
                foreach (Tour tour in _tourList)
                {
                    Application.Current.Dispatcher.Invoke(new Action(() => { TourNames.Add(tour); }));
                };

            });
        }

        public void SetCommands()
        {
            OpenAddTourWindow = new RelayCommand((_) =>
            {
                Open_AddTourWindow();

            });

            OpenEditTourCommand = new RelayCommand((_) =>
            {
                Open_EditTourWindow();
            });


            TourReport = new RelayCommand((_) =>
            {
                GenerateTourReport();
            });

            SummarizeReport = new RelayCommand((_) =>
            {
                GenerateSummarizeReport();
            });

          

        }

        

        public void DeleteSelectedTour()
        {
            bool isDeleted;
            _logger = LoggerFactory.GetLogger("DeleteSelectedTourCommand");

      
            isDeleted = _tourController.Controller_deleteTour(SelectedTour);
            if (isDeleted)
            {
                _logger.Debug("Tour was deleted.");
            }
            else
            {
                _logger.Debug("Failed deleting tour.");
            }

        }

        public void RemoveItem()
        {
            if(TourNames.Remove(TourNames.SingleOrDefault(i => i.Id == SelectedTour.Id)))
            {
                _logger.Debug("Tour has been removed.");
            }
            else
            {
                _logger.Debug("Failed removing Tour from Tournames");
            }
          
        }

        public void GenerateTourReport()
        {
            _reportController.GenerateTourReport(SelectedTour);
        }

        public void GenerateSummarizeReport()
        {
            _reportController.GenerateSummarizeReport();

        }

        public void Open_AddTourWindow()
        {
            this.win1 = new AddTourWindow(this);
            win1.Show();
        }

        public void Open_EditTourWindow()
        {
            this.win2 = new TourEditView(SelectedTour);
            win2.Show();
        }



    }
}
