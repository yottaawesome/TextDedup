using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TextDedup.Library.Error;

namespace TextDedup.Library.Command
{
    /// <summary>
    /// Commands object for deduplicating string data with a specified delimiter.
    /// </summary>
    class DedupString
    {
        protected readonly string _stringToDedup;
        protected readonly string _delimiter;

        /// <summary>
        /// All parameters are required for this constructor.
        /// </summary>
        /// <param name="stringToDedup">Required. String to deduplicate.</param>
        /// <param name="delimiter">Required. The delimiter to use.</param>
        /// <exception cref="TextDedup.Library.Error.CommandException">When an exception occurs, it will be wrapped by this exception type and thrown.</exception>
        public DedupString(string stringToDedup, string delimiter)
        {
            if (string.IsNullOrWhiteSpace(stringToDedup) || string.IsNullOrWhiteSpace(delimiter))
                throw new CommandException("Parameters stringToDedup and delimiter are required");

            _stringToDedup = stringToDedup;
            _delimiter = delimiter;
        }

        /// <summary>
        /// Executes this command object.
        /// </summary>
        /// <returns>The deduplicated string. Empty strings are removed.</returns>
        /// <exception cref="TextDedup.Library.Error.CommandException">When an exception occurs, it will be wrapped by this exception type and thrown.</exception>
        public string Execute()
        {
            try
            {
                string[] split = _stringToDedup.Split(_delimiter, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length == 1)
                    return split[0];

                // TODO: Not sure of the performance of Distinct() with very large string arrays;
                // may need to investigate a more precisely engineered algorithm for very large arrays.
                string retVal = string.Join(_delimiter, split.Distinct(new StrEquals()));
                return retVal;
            }
            catch(Exception ex)
            {
                throw new CommandException(ex);
            }
        }

        private class StrEquals : IEqualityComparer<string>
        {
            bool IEqualityComparer<string>.Equals(string x, string y)
            {
                return string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
            }

            int IEqualityComparer<string>.GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }

    }
}
