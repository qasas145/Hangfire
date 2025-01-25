namespace Hangfire.Services
{
    public class DataService
    {
        public static void SayHello(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
