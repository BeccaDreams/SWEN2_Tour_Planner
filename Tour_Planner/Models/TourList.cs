using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner.Models
{
    public class TourList 
    {
        //private Dictionary<string, Tour> tourDictionary { get; set; }
        private List<Tour> _list;
        
        public TourList()
        {
            _list = new List<Tour>();
            _list.Add(new Tour("Tourname"));
            _list.Add(new Tour("Tourname2"));
        }
    }
}
