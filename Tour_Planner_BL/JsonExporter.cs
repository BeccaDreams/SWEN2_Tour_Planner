using Newtonsoft.Json;
using Shared.Models;
using System.Web;

namespace Tour_Planner_BL
{
    public class JsonExporter
    {
        private static readonly JsonSerializerSettings _options = new() { NullValueHandling = NullValueHandling.Ignore };
        private string _fileName = "export/tours.json";
        private string _folderName = "./export";

        public virtual void ExportTours(List<Tour> tours) {

            var jsonString = JsonConvert.SerializeObject(tours, Formatting.Indented, _options);
            if (!Directory.Exists(_folderName))
            {
                Directory.CreateDirectory(_folderName);
            }
            File.WriteAllText(_fileName, jsonString);
        }

       
    }
}
