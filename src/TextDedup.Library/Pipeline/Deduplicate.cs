using TextDedup.Library.Command;
using TextDedup.Library.Dto;
using TextDedup.Library.Interface;

namespace TextDedup.Pipeline
{
    public class Deduplicate
    {
        protected readonly string[] _args;
        protected readonly ILogger _logger;

        public Deduplicate(string[] args, ILogger logger)
        {
            _args = args;
            _logger = logger;
        }

        public void Execute()
        {
            ProcessArgs step1Command = new ProcessArgs(_args, _logger);
            Args step1Results = step1Command.Execute();
            if(step1Results == null)
            {
                _logger?.Write("The pipeline is aborting because step 1 did not complete successfully.");
                return;
            }

            FetchData step2Command = new FetchData(step1Results, _logger);
            string step2Results = step2Command.Execute();
            if (step1Results == null)
            {
                _logger?.Write("The pipeline is aborting because step 2 did not complete successfully.");
                return;
            }

            DedupString step3Command = new DedupString(step2Results, step1Results.Delimiter);
            string step3Results = step3Command.Execute();
            if (step3Results == null)
            {
                _logger?.Write("The pipeline is aborting because step 3 did not complete successfully.");
                return;
            }

            SaveDedupedData step4Command = new SaveDedupedData(step1Results.Destination, step3Results);
            step4Command.Execute();
        }
    }
}