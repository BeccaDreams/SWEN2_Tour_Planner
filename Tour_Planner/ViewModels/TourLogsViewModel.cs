using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;
using System.Collections.ObjectModel;
using Shared.Models;

namespace Tour_Planner.ViewModels
{
    public class TourLogsViewModel : BaseModel 
    {
        public ObservableCollection<TourLog> DataLogs { get; }
          = new ObservableCollection<TourLog>();

        public TourLogsViewModel()
        {
            loadLogs();
        }

        private void loadLogs()
        {
            DataLogs.Clear();
            DataLogs.Add(new TourLog("13.12.22", "12min", "22km", "Bike"));
            DataLogs.Add(new TourLog("12.12.22", "12min", "22km", "Bike"));
            DataLogs.Add(new TourLog("11.12.22", "12min", "22km", "Bike"));
        }

       
        
    }
}
