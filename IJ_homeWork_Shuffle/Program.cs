namespace IJ_homeWork_Shuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = GenerateArray(10, 0, 9);

            Console.WriteLine("Сгенерированый массив:");

            foreach (int number in array)
            {
                Console.Write($"{number} ");
            }

            array = Shuffle(array, 20);
            Console.WriteLine("\n\n" + "Перемешанный массив:");

            foreach (int number in array)
            {
                Console.Write($"{number} ");
            }

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

        static int[] Shuffle(int[] array, int swipeTimes)
        {
            Random random = new Random();

            for (int i = 0; i < swipeTimes; i++)
            {
                array = SwipeElements(array, random.Next(0, array.Length), random.Next(0, array.Length));
            }

            return array;
        }

        static int[] SwipeElements(int[] array, int firstIndex, int secondIndex)
        {
            int numberBuffer;

            if (firstIndex == secondIndex)
            {
                if (secondIndex < array.Length - 1)
                {
                    secondIndex = firstIndex + 1;
                }
                else
                {
                    secondIndex = firstIndex - 1;
                }
            }

            numberBuffer = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = numberBuffer;

            return array;
        }
    }
}