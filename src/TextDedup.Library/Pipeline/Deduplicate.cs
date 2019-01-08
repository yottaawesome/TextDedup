using TextDedup.Library.Command;
using TextDedup.Library.Dto;
using TextDedup.Library.Interface;

namespace TextDedup.Pipeline
{
    /// <summary>
    /// Command pipeline for deduplicating a string array.
    /// </summary>
    public class Deduplicate
    {
        protected readonly string[] _args;
        protected readonly ILogger _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="logger"></param>
        public Deduplicate(string[] args, ILogger logger)
        {
            _args = args;
            _logger = logger;
        }

        /// <summary>
        /// Executes this command pipeline.
        /// </summary>
        /// <exception cref="TextDedup.Library.Error.CommandException">When an exception occurs, it will be wrapped by this exception type and thrown.</exception>
        public void Execute()
        {
            ProcessArgs step1Command = new ProcessArgs(_args);
            Args step1Results = step1Command.Execute();
            if(step1Results == null)
            {
                _logger?.Write("The pipeline is aborting because step 1 did not complete successfully.");
                return;
            }

            FetchData step2Command = new FetchData(step1Results);
            string step2Results = step2Command.Execute();

            DedupString step3Command = new DedupString(step2Results, step1Results.Delimiter);
            string step3Results = step3Command.Execute();

            SaveDedupedData step4Command = new SaveDedupedData(step1Results.Destination, step3Results);
            step4Command.Execute();
        }
    }
}