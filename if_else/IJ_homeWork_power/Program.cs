namespace IJ_homeWork_power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minRandom = 1;
            int maxRandom = 100;
            int firstNumber = 2;
            int firstNumberInPower = firstNumber;
            int powerCount = 1;
            int secondNumber = random.Next(minRandom, maxRandom + 1);

            while (firstNumberInPower <= secondNumber)
            {
                firstNumberInPower *= firstNumber;
                powerCount++;
            }

            Console.WriteLine($"число {secondNumber} меньше числа {firstNumber} в {powerCount} степени, что равняется: {firstNumberInPower}");
            Console.ReadKey();
        }
    }
}