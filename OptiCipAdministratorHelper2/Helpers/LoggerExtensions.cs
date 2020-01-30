using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCipAdministratorHelper2.Helpers
{
    public static class LoggerExtensions
    {

        public static void Json(this ILogger logger, NLog.LogLevel logLevel, object objectToLog)
        {
            logger.Log(logLevel, JsonConvert.SerializeObject(objectToLog));
        }
        public static void Json(this ILogger logger, NLog.LogLevel logLevel, object objectToLog, string message)
        {
            logger.Log(logLevel, message);
            logger.Log(logLevel, JsonConvert.SerializeObject(objectToLog));
        }
    }
}
