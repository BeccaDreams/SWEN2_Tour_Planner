using Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Tour_Planner.Views;

namespace Tour_Planner.ViewModels
{
    public class TourDetailsViewModel : BaseModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set 
            {
                try
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
                }
        }

        private string _detailDescription;
        public string DetailDescription
        {
            get { return _detailDescription; }
            set
            {
                try
                {
                    _detailDescription = value;
                    OnPropertyChanged(nameof(DetailDescription));
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private string _detailTime;
        public string DetailTime
        {
            get { return _detailTime; }
            set
            {
                try
                {
                    _detailTime = value;
                    OnPropertyChanged(nameof(DetailTime));
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private string _detailDistance;
        public string DetailDistance
        {
            get { return _detailDistance; }
            set
            {
                try
                {
                    _detailDistance = value;
                    OnPropertyChanged(nameof(DetailDistance));
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }


        public string folderPath = Directory.GetCurrentDirectory();

        private string _routeInformation;
        public string RouteInformation
        {
            get { return _routeInformation; }
            set
            {
                try
                {
                    _routeInformation = SetRoute(value);
                    OnPropertyChanged("RouteInformation");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }

            }
        }


        public TourDetailsViewModel()
        {
            
            
        }

        public string SetRoute(string file)
        {
            string result = folderPath;
            string newFile = file.Substring(1, file.Length - 1);
            return result + newFile;
        }
       







    }
}
