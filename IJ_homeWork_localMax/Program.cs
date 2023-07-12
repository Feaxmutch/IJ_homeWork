namespace IJ_homeWork_localMax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minNumber = 0;
            int maxNumber = 9;
            int[] numbers = new int[30];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minNumber, maxNumber + 1);
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine("\n\nВсе локальные максимумы:");

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }
                else if (i == numbers.Length - 1)
                {
                    if (numbers[i] > numbers[i - 1])
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }
                else
                {
                    if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }
            }
        }
    }
}