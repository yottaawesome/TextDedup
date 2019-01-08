using System;
using System.IO;
using TextDedup.Library.Error;

namespace TextDedup.Library.Command
{
    /// <summary>
    /// Saves the data parameter to a specified filename represented by the fileName parameter.
    /// </summary>
    class SaveDedupedData
    {
        public readonly string _fileName;
        public readonly string _data;
        
        /// <summary>
        /// All arguments are required, and must not be empty, whitespace, or null strings.
        /// </summary>
        /// <param name="fileName">A path to a file to receive the data.</param>
        /// <param name="data">The data to save.</param>
        /// <exception cref="TextDedup.Library.Error.CommandException">When fileName or data is null, whitespace or empty.</exception>
        public SaveDedupedData(string fileName, string data)
        {
            _fileName = string.IsNullOrWhiteSpace(fileName) 
                ? throw new CommandException("Parameter file is required")
                : fileName;
            _data = string.IsNullOrWhiteSpace(data)
                ? throw new CommandException("Parameter data is required")
                : data;
        }

        /// <summary>
        /// Executes this command object.
        /// </summary>
        /// <exception cref="TextDedup.Library.Error.CommandException">When an exception occurs, it will be wrapped by this exception type and thrown.</exception>
        public void Execute()
        {
            try
            {
                File.WriteAllLines(_fileName, new string[] { _data });
            }
            catch (Exception ex)
            {
                throw new CommandException(ex);
            }
        }
    }
}
