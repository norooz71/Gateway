using System;
using System.Threading.Tasks;
using NLog;
using SAPP.Test.Contracts.Utilities.Logger;

namespace SAPP.Test.Services.Utilities.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILogger _logger=LogManager.GetCurrentClassLogger();
        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);  
        }
    }
}
