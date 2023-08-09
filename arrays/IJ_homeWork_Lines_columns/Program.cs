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
            int selectedLine = 2;
            int selectedColumn = 1;
            int lineSum = 0;
            int columnProduct = 1;

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
                columnProduct *= numbers[i, selectedColumn - 1];
            }

            Console.WriteLine($"Произведение столбца {selectedColumn}: {columnProduct}");

            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                lineSum += numbers[selectedLine - 1, i];
            }

            Console.WriteLine($"Cумма строки {selectedLine}: {lineSum}");
        }
    }
}