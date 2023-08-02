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
                    Console.WriteLine($"Добавлено число: {AddNumber(numbers, newNumber)}");
                }
                else if (userInput == CommandSum)
                {
                    Console.WriteLine($"Сумма введенных ранее чисел: {SumNumbers(numbers)}");
                }
                else if (userInput == CommandExit)
                {
                    isWorking = false;
                }

                Console.ReadKey();
            }
        }

        static int AddNumber(List<int> numbers, int newNumber)
        {
            numbers.Add(newNumber);
            return newNumber;
        }

        static int SumNumbers(List<int> numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }
    }
}