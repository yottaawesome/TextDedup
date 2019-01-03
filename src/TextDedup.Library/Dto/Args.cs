using System;

namespace TextDedup.Library.Dto
{
    class Args
    {
        public Args(string filePath, string delimiter, string destination)
        {
            if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(delimiter) || string.IsNullOrWhiteSpace(destination))
                throw new ArgumentNullException("Parameters filePath, delimiter and destination are required");

            FilePath = filePath;
            Delimiter = delimiter;
            Destination = destination;
        }

        public string FilePath { get; protected set; }
        public string Delimiter { get; protected set; }
        public string Destination { get; protected set; }
    }
}
