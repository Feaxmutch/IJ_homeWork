namespace IJ_homeWork_customSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            int[] numbers = new int[0];
            int[] numbersBuffer;
            int sumOfNumbers;
            string userInput = string.Empty;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine($"Введите число или {CommandSum}, для суммирования введённых ранее чисел.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    default:
                        numbersBuffer = new int[numbers.Length];

                        for (int i = 0; i < numbersBuffer.Length; i++)
                        {
                            numbersBuffer[i] = numbers[i];
                        }

                        numbers = new int[numbers.Length + 1];
                        numbers[numbers.Length - 1] = Convert.ToInt32(userInput);

                        for (int i = 0; i < numbersBuffer.Length; i++)
                        {
                            numbers[i] = numbersBuffer[i];
                        }
                        break;

                    case CommandSum:
                        sumOfNumbers = 0;

                        for (int i = 0; i < numbers.Length; i++)
                        {
                            sumOfNumbers += numbers[i];
                        }

                        Console.WriteLine($"Сумма введенных ранее чисел: {sumOfNumbers}");
                        numbers = new int[0];
                        Console.ReadKey();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }
    }
}