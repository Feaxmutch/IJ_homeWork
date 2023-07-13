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

            Console.WriteLine("Числа без сортировки:");

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minNumber, maxNumber + 1);
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine("\n\n" + "Числа отсортированые по возрастанию:");

            for (int i = minNumber; i <= maxNumber; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] == i)
                    {
                        Console.Write($"{numbers[j]} ");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}