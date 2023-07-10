namespace IJ_homeWork_3_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int result = 0;
            int numberMultiplicity1 = 3;
            int numberMultiplicity2 = 5;
            int minNimber = 0;
            int maxNumber = 101;
            int number = random.Next(minNimber, maxNumber);

            for (int i = 0; i <= number; i++)
            {
                if (i % numberMultiplicity1 == 0 || i % numberMultiplicity2 == 0)
                {
                    result += i;
                }
            }

            Console.WriteLine(result);
        }
    }
}