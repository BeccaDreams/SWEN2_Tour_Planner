using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner.Models
{
    public class TourLog
    {
        private string Date { get; set; }
        private string Duration { get; set; }
        private string Distance { get; set; }
        public TourLog(string date, string duration, string distance)
        {
            Date = date;
            Duration = duration;
            Distance = distance;
        }
    }
}
