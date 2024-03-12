using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Loggers
{
    public class ErrorLogger
    {
        private readonly string _logFilePath;

        public ErrorLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void LogError(string errorMessage)
        {
            string logMessage = $"{DateTime.Now} - {errorMessage}";
            using StreamWriter sw = new(_logFilePath, true);
            sw.WriteLine(logMessage);
        }
    }
}
