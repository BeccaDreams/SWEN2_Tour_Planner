using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tour_Planner.Commands;

namespace Tour_Planner.ViewModels
{
    public class AddLogToTourViewModel : BaseModel, IDataErrorInfo
    {
        public event Action SubmitLogCommandEvent;
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();


        private int? _id;
        private DateOnly _logDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        private string _comment;
        private int _difficulty;
        private string _duration;
        private TimeSpan _totalTime;
        private int _rating;
        private int _tourId;


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

        public string Duration
        {
            get { return _duration; }
            set
            {
                try
                {
                    _duration = value;
                    OnPropertyChanged(nameof(Duration));

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
                    //OnPropertyChanged("TourId");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }


        public ICommand SubmitLogCommand { get; set; }

        public AddLogToTourViewModel()
        {
            SubmitLogCommand = new AddNewLogCommand(this);


        }

        // log data Validation
        static bool typeCheckLong(string UserInput)
        {
            long num = 0;
            return long.TryParse(UserInput, out num);
        }

        public string this[string input]
        {

            get
            {
                string result = null;
                switch (input)
                {
                    case "Comment":
                        if (typeCheckLong(Comment) == true)
                            result = "Comment must consist of letters";
                        break;
                }

                if (ErrorCollection.ContainsKey(input))
                    ErrorCollection[input] = result;
                else if (result != null)
                    ErrorCollection.Add(input, result);

                OnPropertyChanged("ErrorCollection");
                return result;

            }
        }


    }
}
