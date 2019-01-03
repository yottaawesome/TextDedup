using System;
using System.Linq;
using TextDedup.Library.Dto;
using TextDedup.Library.Interface;

namespace TextDedup.Library.Command
{
    class ProcessArgs
    {
        protected readonly string[] _args;
        protected ILogger _logger;
        public static readonly string FileSwitch = "/source:";
        public static readonly string DestSwitch = "/dest:";
        public static readonly string DelimSwitch = "/delim:";

        public enum StatusEnum
        {
            Success,
            NotYetRun,
            NoFileArgFound,
            NoArgsFound,
            Failed
        }
        public StatusEnum Status { get; protected set; }

        public ProcessArgs(string[] args, ILogger logger)
        {
            _args = args;
            _logger = logger;
            Status = StatusEnum.NotYetRun;
        }

        public Args Execute()
        {
            try
            {
                Status = StatusEnum.Success;
                if (_args == null || _args.Length == 0)
                {
                    Status = StatusEnum.NoArgsFound;
                    return null;
                }

                string file = _args.FirstOrDefault(s => s.Contains(FileSwitch) && s.Trim().Length > FileSwitch.Length);
                if (file == null)
                {
                    Status = StatusEnum.NoFileArgFound;
                    return null;
                }
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
            catch(Exception)
            {
                Status = StatusEnum.Failed;
                throw;
            }
        }
    }
}
