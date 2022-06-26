using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner.Models 
{
    public class Tour : BaseModel
    {
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set
            {
                try
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
                
            }
        }

        //private string _tourDescription = "";
        //public string TourDescription
        //{
        //    get { return _tourDescription; }
        //    set
        //    {
        //        try
        //        {
        //            _tourDescription = value;
        //            OnPropertyChanged("TourDescription");
        //        }
        //        catch (StackOverflowException e)
        //        {
        //            Console.WriteLine(e);
        //        }
        //    }
        //}

        private string _from = "";
        public string From
        {
            get { return _from; }
            set
            {
                try
                {
                    _from = value;
                    OnPropertyChanged("From");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }


        private string _to = "";
        public string To
        {
            get { return _to; }
            set
            {
                try
                {
                    _to = value;
                    OnPropertyChanged("To");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        //private string _transportType = "";
        //public string TransportType
        //{
        //    get { return _transportType; }
        //    set
        //    {
        //        try
        //        {
        //            _transportType = value;
        //            OnPropertyChanged("TransportType");
        //        }
        //        catch (StackOverflowException e)
        //        {
        //            Console.WriteLine(e);
        //        }
        //    }
        //}



        public Tour(string name/*,string description, */, string from, string to /*, string transporttype */)
        {
            Name=name;
            //TourDescription = description;
            From=from; 
            To=to;
            //TransportType = transporttype;
        }

     

    }
}


    