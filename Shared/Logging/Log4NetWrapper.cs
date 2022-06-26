using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Logging
{
    public class Log4NetWrapper : ILoggerWrapper
    {
        private log4net.ILog logger;

        private Log4NetWrapper(log4net.ILog logger)
        {
            this.logger = logger;
        }

        public static Log4NetWrapper CreateLogger(string filename, string creator)
        {
            if (!File.Exists(filename))
                throw new ArgumentException("Logger Config-File does not exist", nameof(filename));

            log4net.Config.XmlConfigurator.Configure(new FileInfo(filename));
            var logger = log4net.LogManager.GetLogger(creator.ToString());
            return new Log4NetWrapper(logger);
        }

        public void Debug(string message)
        {
            this.logger.Debug(message);
        }

        public void Warning(string message)
        {
            this.logger.Warn(message);
        }

        public void Error(string message)
        {
            this.logger.Error(message);
        }

        public void Fatal(string message)
        {
            this.logger.Fatal(message);
        }
    }
}
