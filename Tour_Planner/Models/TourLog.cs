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

        private string _tourComment;
        public string TourComment
        {
            get { return _tourComment; }
            set
            {
                try
                {
                    _tourComment = value;
                    OnPropertyChanged("TourComment");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private int _difficulty;
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
        private int _rating;
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
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }



        public TourLog(string date, string comment, int difficulty, string duration, int rating)
        {
            Date = date;
            TourComment = comment;
            Difficulty = difficulty;
            Duration = duration;            
            Rating = rating;
        }

       
    }
}
