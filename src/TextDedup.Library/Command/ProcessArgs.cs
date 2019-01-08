using System;
using System.Linq;
using TextDedup.Library.Dto;
using TextDedup.Library.Error;

namespace TextDedup.Library.Command
{
    /// <summary>
    /// Processes the argument string into a Args object. Returns null if no args or file arg found.
    /// </summary>
    class ProcessArgs
    {
        protected readonly string[] _args;
        public static readonly string FileSwitch = "/src:";
        public static readonly string DestSwitch = "/dst:";
        public static readonly string DelimSwitch = "/del:";

        /// <param name="args">The array of string arguments to process.</param>
        public ProcessArgs(string[] args)
        {
            _args = args;
        }

        /// <summary>
        /// Executes this command object.
        /// </summary>
        /// <exception cref="TextDedup.Library.Error.CommandException">When an exception occurs, it will be wrapped by this exception type and thrown.</exception>
        /// <returns>The parsed args as an Args object, or null if args is empty, null, or no file switch was specified.</returns>
        public Args Execute()
        {
            try
            {
                if (_args == null || _args.Length == 0)
                    return null;

                string file = _args.FirstOrDefault(s => s.Contains(FileSwitch) && s.Trim().Length > FileSwitch.Length);
                if (file == null)
                    return null;
                file = file.Split(":")[1];

                string delimiter =
                    _args.FirstOrDefault(s => s.Contains(DelimSwitch) && s.Trim().Length > DelimSwitch.Length);
                delimiter = delimiter == null
                    ? delimiter = ";"
                    : delimiter = delimiter.Split(":")[1];

                string destination =
                    _args.FirstOrDefault(s => s.Contains(DestSwitch) && s.Trim().Length > DestSwitch.Length);
                if(destination == null)
                {
                    if(file.Contains("."))
                    {
                        string[] nameAndExtension = file.Split(".");
                        destination = nameAndExtension[0] + " [deduped]." + string.Join(".", nameAndExtension.Skip(1));
                    }
                    else
                    {
                        destination = file + " [deduped]";
                    }
                }
                else
                {
                    destination = destination.Split(":")[1];
                }

                return new Args(file, delimiter, destination);
            }
            catch(Exception ex)
            {
                throw new CommandException(ex);
            }
        }
    }
}
