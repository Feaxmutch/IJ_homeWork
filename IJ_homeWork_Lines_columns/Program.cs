namespace IJ_homeWork_Lines_columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minNumber = 1;
            int maxNumber = 9;
            int[,] numbers = new int[3, 3];
            int selectedLine = 1;
            int selectedColum = 0;
            int lineSum = 0;
            int columnProduct = 0;

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

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                if (i == 0)
                {
                    columnProduct = numbers[i, selectedColum];
                }
                else
                {
                    columnProduct *= numbers[i, selectedColum];
                }
            }

            Console.WriteLine($"Произведение столбца под индексом {selectedColum}: {columnProduct}");

            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                if (i == 0)
                {
                    lineSum = numbers[selectedLine, i];
                }
                else
                {
                    lineSum += numbers[selectedLine, i];
                }
            }

            Console.WriteLine($"Cумма строки под индексом {selectedLine}: {lineSum}");
        }
    }
}