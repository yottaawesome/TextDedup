using System;

namespace TextDedup.Library.Error
{
    public class CommandException : Exception
    {
        public CommandException(string msg) : base(msg) { }
        public CommandException(Exception ex) : base(ex.Message, ex) { }
        public CommandException(string msg, Exception ex) : base(msg, ex) { }
    }
}
