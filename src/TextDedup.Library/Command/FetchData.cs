using System;
using System.IO;
using TextDedup.Library.Dto;
using TextDedup.Library.Interface;

namespace TextDedup.Library.Command
{
    class FetchData
    {
        protected readonly Args _args;
        protected readonly ILogger _logger;
        public enum StatusEnum
        {
            Success,
            NotYetRun,
            FileNotFound,
            Failed
        }
        public StatusEnum Status { get; protected set; }

        public FetchData(Args args, ILogger logger)
        {
            _args = args ?? throw new ArgumentNullException("Args cannot be null");
            _logger = logger;
            Status = StatusEnum.NotYetRun;
        }

        public string Execute()
        {
            try
            {
                string concat = string.Concat(File.ReadAllLines(_args.FilePath));
                Status = StatusEnum.Success;
                return concat;
            }
            catch (DirectoryNotFoundException)
            {
                _logger?.Write($"A directory in the path {_args.FilePath} was not found.");
                Status = StatusEnum.FileNotFound;
                return null;
            }
            catch (FileNotFoundException)
            {
                _logger?.Write($"The file or path {_args.FilePath} was not found.");
                Status = StatusEnum.FileNotFound;
                return null;
            }
            catch(Exception)
            {
                Status = StatusEnum.Failed;
                throw;
            }
        }
    }
}
