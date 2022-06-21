using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner.Models
{
    public class TourLog : BaseModel
    {
        private string _date = "";
        public string Date
        {
            get { return _date; }
            set
            {
                try
                {
                    _date = value;
                    OnPropertyChanged("Date");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }



        private string _duration ;
        public string Duration
        {
            get { return _duration; }
            set
            {
                try
                {
                    _duration = value;
                    OnPropertyChanged("Duration");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        private string _distance = "";
        public string Distance
        {
            get { return _distance; }
            set
            {
                try
                {
                    _distance = value;
                    OnPropertyChanged("Distance");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }



        private string _type = "";
        public string Type
        {
            get { return _type; }
            set
            {
                try
                {
                    _type = value;
                    OnPropertyChanged("Type");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }


        public TourLog(string date, string duration, string distance, string type)
        {
            Date = date;
            Duration = duration;
            Distance = distance;
            Type = type;
        }

       
    }
}
