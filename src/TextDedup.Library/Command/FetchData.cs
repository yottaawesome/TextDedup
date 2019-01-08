using System;
using System.IO;
using TextDedup.Library.Dto;
using TextDedup.Library.Error;

namespace TextDedup.Library.Command
{
    /// <summary>
    /// Fetches the string data to be deduplicated.
    /// </summary>
    class FetchData
    {
        protected readonly Args _args;

        /// <summary>
        /// All commands are required for this constructor, and must not be null.
        /// </summary>
        /// <param name="args">Required.</param>
        public FetchData(Args args)
        {
            _args = args ?? throw new CommandException("Args cannot be null");
        }

        /// <summary>
        /// Executes this command object.
        /// </summary>
        /// <returns>The string data read from the file</returns>
        /// <exception cref="TextDedup.Library.Error.CommandException">When an exception occurs, it will be wrapped by this exception type and thrown.</exception>
        public string Execute()
        {
            try
            {
                string concat = string.Concat(File.ReadAllLines(_args.FilePath));
                return concat;
            }
            catch(Exception ex)
            {
                throw new CommandException(ex);
            }
        }
    }
}
