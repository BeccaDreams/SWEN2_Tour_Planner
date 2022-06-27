using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner.Models
{
    public class TourDetail : INotifyPropertyChanged
    {
        private string Title
        {
            get => this.Title;
            set
            {
                this.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public TourDetail(string title)
        {
            Title = title;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
