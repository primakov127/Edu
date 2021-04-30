using Logger.Implementation;
using System;

namespace Logger
{
    class Program
    {
        static void Main()
        {
            Logger consoleLog = new Logger();
            Logger fileLog = new Logger(new FileLogger(".log"));

            var errorMessage = "Critical Error";
            var er = new Exception(errorMessage);
            var warningMessage = "Warning smth";
            var infoMessage = "Info smth";

            consoleLog.Error(errorMessage);
            consoleLog.Error(er);
            consoleLog.Warning(warningMessage);
            consoleLog.Info(infoMessage);

            fileLog.Error(errorMessage);
            fileLog.Error(er);
            fileLog.Warning(warningMessage);
            fileLog.Info(infoMessage);
        }
    }
}
