using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Tour_Planner_BL
{
    public class MapQuestClient
    {
        private string _key = "u3H8AC3EFF0GLWj6o0U8E4wD6NMLdp2L";
        private static readonly HttpClient client = new HttpClient();

        public MapQuestClient() { }

        public async void GetDistance(string fromCity, string toCity) {
            var url = string.Format("http://www.mapquestapi.com/directions/v2/route?from={0}&to={1}&key={2}", fromCity, toCity, _key);

            string responseRoute = await client.GetStringAsync(url);
            if (responseRoute == null) { }
        }
    }
}
