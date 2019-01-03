using System;
using TextDedup.Library.Interface;

namespace TextDedup.Library.Misc
{
    class DefaultLogger : ILogger
    {
        public DefaultLogger() { }

        void ILogger.Write(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg))
                return;

            Console.WriteLine(msg);
        }
    }
}
