using Newtonsoft.Json;
using Shared.Models;
using System.Web;

namespace Tour_Planner_BL
{
    public class JsonExporter
    {
        private static readonly JsonSerializerSettings _options = new() { NullValueHandling = NullValueHandling.Ignore };
        private string _fileName = "export/tours.json";

        public void ExportTours(List<Tour> tours) {

            var jsonString = JsonConvert.SerializeObject(tours, Formatting.Indented, _options);
            
            File.WriteAllText(_fileName, jsonString);
        }

       
    }
}
