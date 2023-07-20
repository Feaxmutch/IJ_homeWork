namespace Ij_homeWork_readInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadNumber();
        }

        static void ReadNumber()
        {
            bool parseIsSuccessful = false;
            string userInput = string.Empty;
            int result;

            while (parseIsSuccessful == false)
            {
                Console.Clear();
                Console.Write("Введите число: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out result))
                {
                    parseIsSuccessful = true;
                    result = int.Parse(userInput);
                    Console.WriteLine(result);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Похоже вы ввели не число.");
                    Console.ReadKey();
                }
            }
        }
    }
}