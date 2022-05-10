using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner.Models 
{
    public class Tour : INotifyPropertyChanged
    {
    
        //private int Id { get; set; }
        private string Name {
            get => this.Name;
            set
            {
                this.Name = value;
                this.OnPropertyChanged(nameof(Name));
            }
         }

        public Tour(string name)
        {
            Name = name;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
