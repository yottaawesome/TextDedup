using System;
using System.IO;

namespace TextDedup.Library.Command
{
    class SaveDedupedData
    {
        public readonly string _fileName;
        public readonly string _data;
        public enum StatusEnum
        {
            Success,
            NotYetRun,
            Failed
        }
        public StatusEnum Status { get; protected set; }

        public SaveDedupedData(string fileName, string data)
        {
            if (string.IsNullOrWhiteSpace(fileName) || string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException("Parameters file and data are required");

            _fileName = fileName;
            _data = data;
            Status = StatusEnum.NotYetRun;
        }

        public void Execute()
        {
            try
            {
                Status = StatusEnum.Success;
                File.WriteAllLines(_fileName, new string[] { _data });
            }
            catch (Exception)
            {
                Status = StatusEnum.Failed;
                throw;
            }
        }
    }
}
