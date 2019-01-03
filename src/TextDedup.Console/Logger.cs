using System;
using TextDedup.Library.Interface;

namespace TextDedup.Console
{
    class ConsoleLogger : ILogger
    {
        public ConsoleLogger() { }

        void ILogger.Write(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg))
                return;

            System.Console.WriteLine(msg);
        }
    }
}
