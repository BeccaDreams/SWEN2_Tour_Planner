using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models 
{
    public class Tour : BaseModel
    {
        private int? _id;
        private string _name;
        private string _description;
        private string _from;
        private string _to;
        private string _transportType;
        private double _distance;
        private TimeSpan _time;
        private string _routeInformation;

        public Tour()
        {
        }

        public Tour(string name, string description, string from, string to, string transportType, double distance, TimeSpan time, string routeInfo) {
            Name = name;
            Description = description;
            From = from;
            To = to;
            TransportType = transportType;
            Distance = distance;
            Time = time;
            RouteInformation = routeInfo;

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
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
                
            }
        }
        
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
        
        public string Description
        {
            get { return _description; }
            set
            {
                try
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
                
            }
        }  
        
        
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
        
        public string TransportType
        {
            get { return _transportType; }
            set
            {
                try
                {
                    _transportType = value;
                    OnPropertyChanged("TransportType");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
                
            }
        }
        
        public double Distance
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
        
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                try
                {
                    _time = value;
                    OnPropertyChanged("Time");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
                
            }
        }  
        
        public string RouteInformation
        {
            get { return _routeInformation; }
            set
            {
                try
                {
                    _routeInformation = value;
                    OnPropertyChanged("RouteInformation");
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
                
            }
        }

        
    }
}
