namespace IJ_homeWork_exit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = string.Empty;
            string wordForExit = "exit";
            
            while (userInput != wordForExit)
            {
                userInput = string.Empty;
                Console.Clear();
                Console.WriteLine($"Напишите \"{wordForExit}\", для того чтобы закрыть программу");
                userInput = Console.ReadLine();
            }
        }
    }
}