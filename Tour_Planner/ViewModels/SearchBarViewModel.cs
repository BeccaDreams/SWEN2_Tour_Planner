using System;
using System.Windows.Input;
using Tour_Planner.Views;

namespace Tour_Planner
{
    public class SearchBarViewModel : BaseViewModel
    {
        private string _searchText;
        public ICommand SearchCommand { get; }

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
            //SearchCommand = new SearchCommand((_) =>
            //{
            //    this.SearchTextChanged?.Invoke(this, SearchText);
            //});
        }
    }
}
