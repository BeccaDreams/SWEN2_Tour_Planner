using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Tour_Planner.Views;
using Shared.Models;

namespace Tour_Planner.ViewModels
{
    public class SearchBarViewModel : BaseModel
    {

        public event EventHandler<string> SearchTextChanged;

        public ICommand SearchCommand { get; }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
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
