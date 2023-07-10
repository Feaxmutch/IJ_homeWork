namespace IJ_homeWork_Multiplicity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minRandomValue = 1;
            int maxRandomValue = 27;
            int multiplicityNumber = random.Next(minRandomValue,maxRandomValue + 1);
            int multiplicityCount = 0;
            int minNumber = 100;
            int maxNumber = 999;

            for (int i = 0; i <= maxNumber; i+= multiplicityNumber)
            {
                if (i >= minNumber)
                {
                    multiplicityCount++;
                }
            }

            Console.WriteLine($"{multiplicityCount} трехзначных натуральных чисел кратны {multiplicityNumber}");
            Console.ReadKey();
        }
    }
}