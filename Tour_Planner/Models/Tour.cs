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
        private string _name;
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

        public Tour(string name)
        {
            Name=name;
        }

    }
}
