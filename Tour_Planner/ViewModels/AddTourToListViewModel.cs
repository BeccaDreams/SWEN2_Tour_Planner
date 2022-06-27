using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Shared.Models;

namespace Tour_Planner.ViewModels
{
    public class AddTourToListViewModel : BaseModel
    {
        private string _addtourName;
        public string AddNewTourName
        {
            get { return _addtourName; }
            set
            {
                try
                {
                    _addtourName = value;
                    OnPropertyChanged("AddNewTourName");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private string _addfrom;
        public string AddNewFrom
        {
            get { return _addfrom; }
            set
            {
                try
                {
                    _addfrom = value;
                    OnPropertyChanged("AddNewFrom");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private string _addto;
        public string AddNewTo
        {
            get { return _addto; }
            set
            {
                try
                {
                    _addto = value;
                    OnPropertyChanged("AddNewTo");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public RelayCommand AddNewTourCommand { get; set; }


        public AddTourToListViewModel()
        {

            if (AddNewTourName != null)
            {
                Tour newAddedTour = new Tour(AddNewTourName, AddNewFrom, AddNewTo);

                //TourItems.Add(newAddedTour);
            }
            else
            {

                //TourItems.Add(new Tour("was anderes", "from", "to"));

            }


        }


       


    }
}
