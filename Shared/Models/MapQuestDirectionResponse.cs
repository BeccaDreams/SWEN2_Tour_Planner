namespace Shared.Models
{
    public class MapQuestDirectionResponse 
    { 
        public Route Route { get; set; }
    }

    public class Route 
    { 
        public RouteError RouteError { get; set; }

        public BoundingBox BoundingBox { get; set; }
        
        public float Distance { get; set; }

        public TimeSpan FormattedTime { get; set; }

        public string SessionId { get; set; }
    }

    public class BoundingBox
    {
        public Coordinat Lr { get; set; }
        
        public Coordinat Ul { get; set; }
    }

    public class Coordinat 
    {
        public float Lng { get; set; }
        
        public float Lat { get; set; }
    }  

    public class RouteError
    {
        public int ErrorCode { get; set; }

        public string Message { get; set; }
    }
    

}
