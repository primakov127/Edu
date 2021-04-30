using Logger.Implementation;
using System;

namespace Logger
{
    public class Logger : ILogger
    {
        private readonly ILogger _logger;

        public Logger()
        {
            _logger = new ConsoleLogger();
        }

        public Logger(ILogger logger)
        {
            _logger = logger;
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(Exception ex)
        {
            _logger.Error(ex);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warning(string message)
        {
            _logger.Warning(message);
        }
    }
}
