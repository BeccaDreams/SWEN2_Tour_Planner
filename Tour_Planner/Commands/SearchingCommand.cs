using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.ViewModels;
using Tour_Planner_BL.Controller;

namespace Tour_Planner.Commands
{
    public class SearchingCommand : BaseCommand
    {
        private readonly SearchBarViewModel _searchbar;
        private TourController _tourController;
        private LogController _logController;
        public List<Tour> _tourList;
        public List<TourLog> _logList;

        public SearchingCommand(SearchBarViewModel Searchbar)
        {
            _searchbar = Searchbar;
            _tourController = new TourController();
            _logController = new LogController();
        }
        public override void Execute(object parameter)
        {
            _tourList = _tourController.Controller_searchTour(_searchbar.SearchText);
            _logList = _logController.Controller_searchTourLog(_searchbar.SearchText);
        }


    }
}
