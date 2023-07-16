namespace IJ_homeWork_moveNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minNumber = 0;
            int maxNumber = 9;
            int[] numbers = new int[4];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minNumber, maxNumber);
            }

            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
            Console.WriteLine("\nНа сколько позиций влево вы хотите сдвинуть эти числа?");

            int numberMoves = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= numberMoves; i++)
            {
                int numberBuffer = numbers[0];

                for (int j = 1; j < numbers.Length; j++)
                {
                    numbers[j - 1] = numbers[j];
                }

                numbers[numbers.Length - 1] = numberBuffer;
            }

            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }

            Console.ReadKey();
        }
    }
}