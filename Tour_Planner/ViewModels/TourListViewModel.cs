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
        private Tour _deleteTour;
        ReportController _reportController;
        TourController _tourController;
        Window win1, win2;
        EditTourViewModel _editTourViewModel;

        public Tour SelectedTour
        {
            get { return _selectedTour; }
            set
            {
                _selectedTour = value;
                OnPropertyChanged(nameof(SelectedTour));
            }
        }

        public Tour DeleteTour
        {
            get { return _deleteTour; }
            set
            {
                _deleteTour = value;
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
            //DeleteTourCommand = new DeleteSelectedTourCommand(this);

            //var tour = new Tour { Name = "Vienna to Graz", Description = "Descrition 28.06.2022", From = "Vienna", To = "Graz", TransportType = "fastest" };
            // var tourController = new TourController();
            // tourController.Controller_addTour(tour);

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

        public void DisplaySearchResult(string searchText)
        {
            
        }

        public void Delete_Tour()
        {

        }


        public void LoadTours()
        {
            _tourList = _tourController.Controller_getTours();
            TourNames = new ObservableCollection<Tour>(_tourList);
           
        }

        public void SetCommands()
        {
            OpenAddTourWindow = new RelayCommand((_) =>
            {
                Open_AddTourWindow();

            });

            OpenEditTourCommand = new RelayCommand((_) =>
            {
                _editTourViewModel = new EditTourViewModel(SelectedTour);
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

            DeleteTourCommand = new RelayCommand((_) =>
            {
                TestCommand = new DeleteSelectedTourCommand(this);
               
                //try
                //{
                //    if(SelectedTour != null)
                //    RemoveItem();
                //    OnPropertyChanged(nameof(TourNames));
                //}
                //catch (Exception e)
                //{
                //    _logger.Error("Failed removing Tour from Tournames: " + e.Message);
                //}
             
            });

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
            this.win1 = new AddTourWindow();
            win1.Show();
        }

        public void Open_EditTourWindow()
        {
            this.win2 = new TourEditView();
            win2.Show();
        }



    }
}
