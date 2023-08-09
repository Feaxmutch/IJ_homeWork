namespace IJ_homeWork_numberTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minNumber = 0;
            int maxNumber = 2;
            int[] numbers = new int[30];
            int repeatsCount = 1;
            int maxRepeatsCount = 1;
            int repeatableNumber = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minNumber, maxNumber + 1);
            }

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    repeatsCount++;
                }
                else
                {
                    repeatsCount = 1;
                }

                if (repeatsCount > maxRepeatsCount)
                {
                    maxRepeatsCount = repeatsCount;
                    repeatableNumber = numbers[i];
                }
            }

            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
            Console.WriteLine($"число {repeatableNumber} повторилось {maxRepeatsCount} раз, что является наибольшим числом повторений.");
        }
    }
}