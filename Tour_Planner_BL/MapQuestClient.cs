using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.Models;
using Shared.Logging;
using System.Globalization;

namespace Tour_Planner_BL
{
    public class MapQuestClient
    {
        private BLConfig _config;
        private ILoggerWrapper _logger;
        private HttpClient _client = new HttpClient();
        private string _baseUrl = "http://www.mapquestapi.com/";

        public MapQuestClient() 
        {
            _config = new BLConfig();
            _logger = LoggerFactory.GetLogger("Business Layer - MapQuestClient");
        }

        
        public async Task<String> GetMapQuestStaticMap(MapQuestDirectionResponse direction)
        {
            if ( direction == null )
            {
                _logger.Error("GetMapQuestStaticMap - ArgumentException");
                throw new ArgumentException();
            }

            var mapPath = "";
            
            try 
            {
                
                var boundingBox = direction.Route.BoundingBox;
                var url = _baseUrl + string.Format("staticmap/v5/map?key={0}&boundingBox={1},{2},{3},{4}&session={5}",
                    _config.MapQuestKey,
                    boundingBox.Ul.Lat.ToString(CultureInfo.InvariantCulture),
                    boundingBox.Ul.Lng.ToString(CultureInfo.InvariantCulture),
                    boundingBox.Lr.Lat.ToString(CultureInfo.InvariantCulture),
                    boundingBox.Lr.Lng.ToString(CultureInfo.InvariantCulture),
                    direction.Route.SessionId
                );

                var response = await _client.GetStreamAsync(url);
                var mapId = Guid.NewGuid().ToString("N");
                mapPath = string.Format("maps/{0}.png", mapId);

                await using var fileStream = new FileStream(mapPath, FileMode.Create, FileAccess.Write);
                response.CopyTo(fileStream);
            } 
            catch (Exception ex) 
            {
                _logger.Error("GetMapQuestStaticMap - Exception getting Map: " + ex.Message);
            }

            return mapPath;
        }

        public async Task<MapQuestDirectionResponse> GetMapQuestDirection(string fromCity, string toCity, string routeType)
        {
            if (
                string.IsNullOrEmpty(fromCity)
                || string.IsNullOrEmpty(toCity)
                || string.IsNullOrEmpty(routeType)
            )
            {
                _logger.Error("GetMapQuestDirection - ArgumentException");
                throw new ArgumentException();
            }

            var url = _baseUrl + string.Format("directions/v2/route?from={0}&to={1}&routeType={2}&key={3}",
                fromCity,
                toCity,
                routeType,
                _config.MapQuestKey);

            var response = await _client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<MapQuestDirectionResponse>(response);

            if (result?.Route.RouteError.ErrorCode > 0)
            {
                _logger.Error("Failed to load directions. Error code: " + result.Route.RouteError.ErrorCode);
            }
            return result;
        }

       
    }
}
