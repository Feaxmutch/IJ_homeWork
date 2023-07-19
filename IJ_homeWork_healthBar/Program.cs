namespace IJ_homeWork_healthBar
{
    internal class Program
    {
        static void WriteBar(int value, int maxValue, int step = 1, ConsoleColor barColor = ConsoleColor.Red, ConsoleColor frameColor = ConsoleColor.White)
        {
            char leftSide = '[';
            char rightSide = ']';
            char upDownSide = '_';
            ConsoleColor defaltBackGroundColor = Console.BackgroundColor;
            ConsoleColor defaltForegroundColor = Console.ForegroundColor;


            Console.Write(" ");
            Console.ForegroundColor = frameColor;

            for (int i = step; i <= maxValue; i += step)
            {
                Console.Write(upDownSide);
            }

            Console.Write("\n" + leftSide);
            Console.BackgroundColor = barColor;

            for (int i = step; i <= value; i += step)
            {
                Console.Write(upDownSide);
            }

            Console.BackgroundColor = defaltBackGroundColor;

            for (int i = value; i < maxValue; i += step)
            {
                Console.Write(upDownSide);
            }

            Console.Write(rightSide);
            Console.ForegroundColor = defaltForegroundColor;
        }

        static void Main(string[] args)
        {
            int health = 40;
            int maxHealth = 100;
            int barStep = 10;

            WriteBar(health, maxHealth, barStep, ConsoleColor.Green, ConsoleColor.Red);

            Console.ReadKey(true);
        }
    }
}