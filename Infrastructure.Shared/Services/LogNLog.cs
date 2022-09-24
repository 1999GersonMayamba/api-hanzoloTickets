using Application.Interfaces.NLog;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Shared.Services
{
    public class LogNLog : ILog
    {
        //private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LogNLog()
        {
        }

        public void Information(string message)
        {
            Log.Information(message);
           // logger.Info(message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
            //logger.Warn(message);
        }

        public void Debug(string message)
        {
            Log.Debug(message);
          //  logger.Debug(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
            //logger.Error(message);
        }
    }

}
