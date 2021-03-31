using System;

namespace Logger.Implementation
{
    public class ConsoleLogger : ILogger
    {
        private const string ERROR_LABEL = "[ERROR]";
        private const string WARNING_LABEL = "[WARNING]";
        private const string INFO_LABEL = "[INFO]";

        public void Error(string message)
        {
            Console.WriteLine($"{ERROR_LABEL}: {message}");
        }

        public void Error(Exception ex)
        {
            string message = ex.ToString();
            Console.WriteLine($"{ERROR_LABEL}: {message}");
        }

        public void Info(string message)
        {
            Console.WriteLine($"{INFO_LABEL}: {message}");
        }

        public void Warning(string message)
        {
            Console.WriteLine($"{WARNING_LABEL}: {message}");
        }
    }
}
