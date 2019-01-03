using TextDedup.Pipeline;

namespace TextDedup.Console
{
    public class Program
    {
        static int Main(string[] args)
        {
            Deduplicate d = new Deduplicate(args, new ConsoleLogger());
            d.Execute();

            return 0;
        }
    }
}
