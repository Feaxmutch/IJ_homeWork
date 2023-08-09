namespace Ij_homeWork_readInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int parsedNumber = ReadNumber();
            Console.WriteLine(parsedNumber);
        }

        static int ReadNumber()
        {
            string userInput = string.Empty;
            int result;

            while (int.TryParse(userInput, out result) == false)
            {
                Console.Clear();
                Console.Write("Введите число: ");
                userInput = Console.ReadLine();
            }
            
            return result;
        }
    }
}