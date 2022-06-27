using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;
using Tour_Planner.Models;
using System.Collections.ObjectModel;

namespace Tour_Planner.ViewModels
{
    public class TourLogsViewModel : BaseModel 
    {
        public ObservableCollection<TourLog> DataLogs { get; set; }
          = new ObservableCollection<TourLog>();

        public TourLogsViewModel()
        {
            loadLogs();
        }

        private void loadLogs()
        {
            DataLogs.Clear();
            DataLogs.Add(new TourLog("13.12.22", "12min", 2, "22km", 4));
            DataLogs.Add(new TourLog("12.12.22", "12min", 3, "22km", 3));
            DataLogs.Add(new TourLog("11.12.22", "12min", 1, "22km", 5));
        }

       
        
    }
}
