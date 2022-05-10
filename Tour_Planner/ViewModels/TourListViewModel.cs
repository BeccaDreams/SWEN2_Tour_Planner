using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;
using Tour_Planner.Models;

namespace Tour_Planner.ViewModels
{
    public class TourListViewModel : MainViewModel
    {
        private List<Tour> _list;

           
        public TourListViewModel()
        {
            _list = new List<Tour>();
            _list.Add(new Tour("Tourname"));
            _list.Add(new Tour("Tourname2"));
            
        }
    }
}
