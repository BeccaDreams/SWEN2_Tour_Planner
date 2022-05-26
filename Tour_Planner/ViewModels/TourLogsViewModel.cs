using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;
using Tour_Planner.Models;

namespace Tour_Planner.ViewModels
{
    public class TourLogsViewModel : BaseModel 
    {
        private List<TourLog> _logs;
        public TourLogsViewModel()
        {
            _logs = new List<TourLog>();
            loadLogs();
        }

        private void loadLogs()
        {
            _logs.Clear();
            _logs.Add(new TourLog("13.12.22", "12min", "22km"));
            _logs.Add(new TourLog("12.12.22", "12min", "22km"));
            _logs.Add(new TourLog("11.12.22", "12min", "22km"));
        }

        public List<TourLog> getLogs()
        {
            return _logs;
        }
        
    }
}
