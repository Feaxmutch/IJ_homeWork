namespace IJ_homeWork_customSum_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            bool isWorking = true;
            List<int> numbers = new List<int>();

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine($"Введите число или {CommandSum}, для суммирования введённых ранее чисел.");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int newNumber))
                {
                    AddNumber(numbers, newNumber);
                }
                else if (userInput == CommandSum)
                {
                     SumNumbers(numbers);
                }
                else if (userInput == CommandExit)
                {
                    isWorking = false;
                }

                Console.ReadKey();
            }
        }

        static void AddNumber(List<int> numbers, int newNumber)
        {
            numbers.Add(newNumber);
        }

        static void SumNumbers(List<int> numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine($"Сумма введенных ранее чисел: {sum}");
        }
    }
}