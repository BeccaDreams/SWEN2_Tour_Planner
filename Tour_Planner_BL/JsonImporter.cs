using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner_BL
{
    public class JsonImporter
    {
        public JsonImporter() 
        {
        }

        public virtual List<Tour> ImportTours(string filePath)
        {
            var tours = new List<Tour>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                tours = JsonConvert.DeserializeObject<List<Tour>>(json);
            }
            return tours;
        }
    }
}