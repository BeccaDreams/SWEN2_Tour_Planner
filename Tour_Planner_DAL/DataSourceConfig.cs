using Microsoft.Extensions.Configuration;

namespace Tour_Planner_DAL
{
    public class DataSourceConfig
    {
        
        public string DataSourceAddress
        {
            get
            {
                var configRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
                var configSection = configRoot.GetSection("ConnectionStrings:local_tour_planner"); ;
                return configSection.Value;
            }
        }

    }
}
