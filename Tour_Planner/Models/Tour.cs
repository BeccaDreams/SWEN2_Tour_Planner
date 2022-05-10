using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner.Models
{
    public class Tour
    {
        //private int Id { get; set; }
        private string Name { get; set; }

        public Tour(string name)
        {
            Name = name;
        }
    }
}
