using System;
using System.IO;

namespace Logger.Implementation
{
    public class FileLogger : ILogger
    {
        private const string ERROR_LABEL = "[Error]";
        private const string WARNING_LABEL = "[Warning]";
        private const string INFO_LABEL = "[Info]";

        private readonly string _filePath;

        public string FilePath => _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Error(string message)
        {
            string formattedMsg = GetFormattedLine(ERROR_LABEL, message, DateTime.Now);
            WriteFileLine(formattedMsg);
        }

        public void Error(Exception ex)
        {
            string formattedMsg = GetFormattedLine(ERROR_LABEL, ex.ToString(), DateTime.Now);
            WriteFileLine(formattedMsg);
        }

        public void Info(string message)
        {
            string formattedMsg = GetFormattedLine(INFO_LABEL, message, DateTime.Now);
            WriteFileLine(formattedMsg);
        }

        public void Warning(string message)
        {
            string formattedMsg = GetFormattedLine(WARNING_LABEL, message, DateTime.Now);
            WriteFileLine(formattedMsg);
        }

        private string GetFormattedLine(string label, string message, DateTime time)
        {
            string formattedLabel = String.Format("{0, -10}", label);
            string formattedTime = time.ToString("yyyy/MM/dd HH:mm:ss:ff");

            string fullFormattedLine = $"{formattedLabel} | {formattedTime} | {message}";

            return fullFormattedLine;
        }

        private void WriteFileLine(string text)
        {
            string newLineText = $"{text}\n";
            using (var fStream = new FileStream(_filePath, FileMode.Append, FileAccess.Write))
            {
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(newLineText);
                fStream.Write(byteArray);
            }
        }
    }
}
