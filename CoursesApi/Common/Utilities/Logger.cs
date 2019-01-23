using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Common.Utilities
{
    public class Logger
    {
        public Logger()
        {}

        // To be implemented
        public Logger(string logFilePath)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(String message, params object[] args)
        {
            Console.WriteLine($"{DateTime.UtcNow} - INFO: {String.Format(message, args)}");
        }

        public void LogError(String message, params object[] args)
        {
            Console.WriteLine($"{DateTime.UtcNow} - ERROR: {String.Format(message, args)}");
        }
    }
}
