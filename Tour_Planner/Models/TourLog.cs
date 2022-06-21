using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner.Models
{
    public class TourLog : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
