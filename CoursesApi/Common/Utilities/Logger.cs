using System;
using System.IO;

namespace CoursesApi.Common.Utilities
{
    public class Logger
    {
        public Logger()
        {
            writer = File.AppendText("log.txt");
        }

        private StreamWriter writer;
        // To be implemented
        public Logger(string logFilePath)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(String message, params object[] args)
        {
            writer.Write($"{DateTime.UtcNow} - INFO: {String.Format(message, args)}");
            writer.Close();
        }

        public void LogError(String message, params object[] args)
        {
            writer.Write($"{DateTime.UtcNow} - ERROR: {String.Format(message, args)}");
            writer.Close();
        }
    }
}
