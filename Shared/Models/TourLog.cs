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

       
        public TourLog()
        { 
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

        public TourLog(DateOnly date, string comment, int difficulty, TimeSpan totalTime, int rating, int tourId)
        {
            LogDate = date;
            Comment = comment;
            Difficulty = difficulty;
            TotalTime = totalTime;
            Rating = rating;
            TourId = tourId;
        }


    }
}
