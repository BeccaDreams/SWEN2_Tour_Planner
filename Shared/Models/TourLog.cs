using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class TourLog : BaseModel
    {
        private int? _id;
        private DateOnly _logDate;
        private string _comment;
        private int _difficulty;
        private TimeSpan _totalTime;
        private int _rating;
        private int _tourId;

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

        public TourLog()
        { 
        }

        public TourLog(string date, string duration, int difficulty, string distance, /*string type,*/ int rating)
        {
            Date = date;
            Duration = duration;
            Difficulty = difficulty;
            Distance = distance;
           // Type = type;
            Rating = rating;
        }

        public int Id
        {
            get { return _id.HasValue ? _id.Value : 0; }
            set
            {
                try
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        } 
        
        public DateOnly LogDate
        {
            get { return _logDate; }
            set
            {
                try
                {
                    _logDate = value;
                    OnPropertyChanged("LogDate");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        
        public string Comment
        {
            get { return _comment; }
            set
            {
                try
                {
                    _comment = value;
                    OnPropertyChanged("Comment");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        
        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                try
                {
                    _difficulty = value;
                    OnPropertyChanged("Difficulty");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }  
        
        public TimeSpan TotalTime
        {
            get { return _totalTime; }
            set
            {
                try
                {
                    _totalTime = value;
                    OnPropertyChanged("TotalTime");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        
        public int Rating
        {
            get { return _rating; }
            set
            {
                try
                {
                    _rating = value;
                    OnPropertyChanged("Rating");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        } 
        
        public int TourId
        {
            get { return _tourId; }
            set
            {
                try
                {
                    _tourId = value;
                    OnPropertyChanged("TourId");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }


    }
}
