namespace IJ_homeWork_numberSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minNumber = 0;
            int maxNumber = 9;
            int[] numbers = new int[20];
            int numberBuffer = 0;

            Console.WriteLine("Числа без сортировки:");

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minNumber, maxNumber + 1);
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine("\n\n" + "Числа отсортированые по возрастанию:");

            for (int i = 0; i < numbers.Length / 2; i++)
            {
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        numberBuffer = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = numberBuffer;
                    }
                }

                for (int j = numbers.Length - 1; j > 0; j--)
                {
                    if (numbers[j] < numbers[j - 1])
                    {
                        numberBuffer = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = numberBuffer;
                    }
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.ReadKey();
        }
    }
}