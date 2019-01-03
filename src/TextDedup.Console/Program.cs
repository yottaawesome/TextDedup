using TextDedup.Pipeline;

namespace TextDedup.Console
{
    public class Program
    {
        static int Main(string[] args)
        {
            if (args != null)
            {
                foreach(string s in args)
                    System.Console.WriteLine(s);
            }

            Deduplicate d = new Deduplicate(args, new ConsoleLogger());
            d.Execute();

            return 0;
        }
    }
}
