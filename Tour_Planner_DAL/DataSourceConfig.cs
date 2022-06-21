using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner_DAL
{
    public class DataSourceConfig
    {
        
        public string DataSourceAddress
        {
            get
            {
                IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
                return config["DataSourceAddress"];
            }
        }

    }
}
