using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Loggers
{
    public class LoginLogger
    {
        private readonly string _logFilePath;

        public LoginLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void LogLogin(string names)
        {
            string logMessage = $"{names} logged in at {DateTime.Now}";
            using StreamWriter sw = new(_logFilePath, true);
            sw.WriteLine(logMessage);
        }
    }
}
