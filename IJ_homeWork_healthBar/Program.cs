namespace IJ_homeWork_healthBar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 60;
            int maxHealth = 150;
            int barLenght = 10;

            DrawBar(health, maxHealth, barLenght, ConsoleColor.Green, ConsoleColor.Red);

            Console.ReadKey(true);
        }

        static void DrawBar(int value, int maxValue, int lenght = 10, ConsoleColor barColor = ConsoleColor.Red, ConsoleColor frameColor = ConsoleColor.White)
        {
            char leftSide = '[';
            char rightSide = ']';
            char downSide = '_';
            char bar = '#';
            ConsoleColor defaltForegroundColor = Console.ForegroundColor;

            if (value < 0)
            {
                value = 0;
            }

            if (maxValue < value)
            {
                maxValue = value;
            }

            Console.ForegroundColor = frameColor;
            Console.Write("\n" + leftSide);
            Console.ForegroundColor = barColor;

            for (int i = 1; i <= value / (maxValue / lenght); i++)
            {
                Console.Write(bar);
            }

            Console.ForegroundColor = frameColor;

            for (int i = value / (maxValue / lenght); i < lenght; i++)
            {
                Console.Write(downSide);
            }

            Console.ForegroundColor = frameColor;
            Console.Write(rightSide);
            Console.ForegroundColor = defaltForegroundColor;
        }
    }
}