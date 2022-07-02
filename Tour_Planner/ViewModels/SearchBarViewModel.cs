using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Tour_Planner.Views;
using Shared.Models;
using Tour_Planner.Commands;
using System.Collections.Generic;
using Tour_Planner_BL.Controller;

namespace Tour_Planner.ViewModels
{
    public class SearchBarViewModel : BaseModel
    {

        public event EventHandler<string> SearchTextChanged;
        private TourController _tourController;
        private LogController _logController;

        public ICommand SearchCommand { get; set; }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }
        private List<Tour> _searchTourList;
        public List<Tour> SearchTourList
        {
            get => _searchTourList;
            set
            {
                _searchTourList = value;
                OnPropertyChanged();
            }
        }
        private List<TourLog> _searchLogList;
        public List<TourLog> SearchLogList
        {
            get => _searchLogList;
            set
            {
                _searchLogList = value;
                OnPropertyChanged();
            }
        }


        public SearchBarViewModel()
        {
            _searchTourList = new List<Tour>();
            _searchLogList = new List<TourLog>();

            _tourController = new TourController();
            _logController = new LogController();
        }

        public void SearchFilter()
        {
            _searchTourList = _tourController.Controller_searchTour(SearchText);
            _searchLogList = _logController.Controller_searchTourLog(SearchText);
        }
    
    }

    
}
