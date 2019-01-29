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

        public Logger(string filePath)
        {
            writer = File.AppendText(filePath);
        }

        private StreamWriter writer;

        public void LogInfo(String message, params object[] args)
        {
            writer.WriteLine($"{DateTime.UtcNow} - INFO: {String.Format(message, args)}");
            writer.Close();
        }

        public void LogError(String message, params object[] args)
        {
            writer.WriteLine($"{DateTime.UtcNow} - ERROR: {String.Format(message, args)}");
            writer.Close();
        }

        public void LogJson(String json)
        {
            writer.WriteLine(json);
            writer.Close();
        }
    }
}
