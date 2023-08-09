using System;

namespace IJ_homeWork_Shuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = GenerateArray(10, 0, 9);

            Console.WriteLine("Сгенерированый массив:");
            WriteNumbers(array);

            Shuffle(array);

            Console.WriteLine("\n\n" + "Перемешанный массив:");
            WriteNumbers(array);

            Console.ReadKey();
        }

        static int[] GenerateArray(int lenght, int minNumber, int maxNumber)
        {
            int[] array = new int[lenght];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minNumber, maxNumber + 1);
            }

            return array;
        }

        static void Shuffle(int[] array)
        {
            Random random = new Random();
            int leftIndex = -1;
            int rightIndex = 1;

            for (int i = 1; i < array.Length - 1; i++)
            {
                int numberBuffer;
                int adjacentIndex = random.Next(leftIndex, rightIndex + 1);

                numberBuffer = array[i];
                array[i] = array[i + adjacentIndex];
                array[i + adjacentIndex] = numberBuffer;
            }
        }

        static void WriteNumbers(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
    }
}