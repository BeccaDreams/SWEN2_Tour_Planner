using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Tour_Planner.Views;
using Tour_Planner.Models;

namespace Tour_Planner.ViewModels
{
    public class SearchBarViewModel : BaseModel
    {

        public event EventHandler<string> SearchTextChanged;
        //public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand SearchCommand { get; }

        public string SearchText
        {
            get => SearchText;
            set
            {
                SearchText = value;
                OnPropertyChanged();
            }
        }

        public SearchBarViewModel()
        {
            //Button verknüpfen
            SearchCommand = new SearchCommand((_) =>
            {
                this.SearchTextChanged?.Invoke(this, SearchText);
            
            });
        }

        public void ButtonClick_Clicked(object sender, EventArgs e)
        {
            //nach tour suchen, Liste filtern?
        }

        
    }
}
