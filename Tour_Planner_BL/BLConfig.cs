using Microsoft.Extensions.Configuration;

namespace Tour_Planner_BL
{
    public class BLConfig
    {
        
        public string MapQuestKey
        {
            get
            {
                var configRoot = new ConfigurationBuilder().AddJsonFile("businesslayersettings.json", false, true).Build();
                var configSection = configRoot.GetSection("MapQuestKey"); ;
                return configSection.Value;
            }
        }

    }
}
