using System;
using System.Linq;

namespace TextDedup.Library.Command
{
    class DedupString
    {
        public enum StatusEnum
        {
            Success,
            NotYetRun,
            Failed
        }
        public StatusEnum Status { get; protected set; }
        protected readonly string _stringToDedup;
        protected readonly string _delimiter;

        public DedupString(string stringToDedup, string delimiter)
        {
            if (string.IsNullOrWhiteSpace(stringToDedup) || string.IsNullOrWhiteSpace(delimiter))
                throw new ArgumentNullException("Parameters stringToDedup and delimiter are required");

            _stringToDedup = stringToDedup.ToUpper();
            _delimiter = delimiter;
            Status = StatusEnum.NotYetRun;
        }

        public string Execute()
        {
            try
            {
                Status = StatusEnum.Success;
                string[] split = _stringToDedup.Split(_delimiter, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length == 1)
                    return split[0];

                // TODO: Not sure of the performance of Distinct() with very large string arrays;
                // may need to investigate a more precisely engineered algorithm for very large arrays.
                string retVal = string.Join(_delimiter, split.Distinct());
                return retVal;
            }
            catch(Exception)
            {
                Status = StatusEnum.Failed;
                throw;
            }
        }
    }
}
