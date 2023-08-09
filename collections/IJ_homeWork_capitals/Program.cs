namespace IJ_homeWork_capitals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> capitals = new Dictionary<string, string> 
            { 
                { "Россия", "Москва" },
                { "Англия", "Лондон" },
                { "Германия", "Берлин"},
                { "Франция", "Париж"},
                { "Италия", "Рим"},
                { "Испания", "Мадрид"}
            };

            Console.WriteLine($"Столица: {GetCapital(capitals)}");
            Console.ReadKey();
        }

        static string GetCapital(Dictionary<string, string> capitalsCollection)
        {
            string userInput = string.Empty;
            bool isCorrectKey = false;

            while (isCorrectKey == false)
            {
                Console.Clear();
                Console.WriteLine("Введите страну");
                userInput = Console.ReadLine();

                if (capitalsCollection.ContainsKey(userInput))
                {
                    isCorrectKey = true;
                }
                else
                {
                    Console.WriteLine("Я не знаю такую страну");
                    Console.ReadKey();
                }
            }

            return capitalsCollection[userInput];
        }
    }
}