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
    public class TourListViewModel : BaseModel
    {
        //public Tour Tour
        //{
        //    get { return Tour; }
        //    set
        //    {
        //        if(value != Tour)
        //        {
        //            this.Tour = value;
        //            this.OnPropertyChanged("Tour");
        //        }
        //    }
        //}
      
        //public ObservableCollection<Tour> TourCollection
        //{
        //    get { return TourCollection; }
        //    set
        //    {
        //        if (value != this.TourCollection)
        //            TourCollection = value;
        //        this.OnPropertyChanged("TourCollection");
        //    }
        //}


        public TourListViewModel()
        {
           
            //this.TourItems.Add(new Tour("hellop"));
        }

        


    }
}
