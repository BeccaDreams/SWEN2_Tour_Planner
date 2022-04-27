using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner.Logging
{
    public class LoggerFactory
    {
        public static ILoggerWrapper GetLogger(string creator)
        {
            return Log4NetWrapper.CreateLogger("./log4net.config", creator);
        }
    }
}
