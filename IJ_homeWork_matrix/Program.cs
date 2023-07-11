using System.Runtime.ExceptionServices;

namespace IJ_homeWork_matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minNumber = 0;
            int maxNumber = 9;
            int[,] numbers = new int[10, 10];
            int highestNumber = minNumber;

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = random.Next(minNumber, maxNumber + 1);
                    Console.Write(numbers[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            foreach (int number in numbers)
            {
                if (number > highestNumber)
                {
                    highestNumber = number;
                }
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (numbers[i,j] == highestNumber)
                    {
                        numbers[i, j] = 0;
                    }

                    Console.Write(numbers[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\n Наибольшее число в матрице: {highestNumber}");
        }
    }
}