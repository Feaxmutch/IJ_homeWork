namespace IJ_homeWork_healthBar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float health = 40;
            float mana = 23;
            int healthBarLenght = 15;
            int manaBarLenght = 10;

            DrawBar(health, 0, 0, healthBarLenght, ConsoleColor.Green, ConsoleColor.Red);
            DrawBar(mana, 0, 1, manaBarLenght, ConsoleColor.Blue, ConsoleColor.Red);

            Console.ReadKey(true);
        }

        static void DrawBar(float present, int X, int Y, float lenght, ConsoleColor barColor = ConsoleColor.Red, ConsoleColor frameColor = ConsoleColor.White)
        {
            char leftSide = '[';
            char rightSide = ']';
            char downSide = '_';
            char bar = '#';
            float maxPresent = 100;
            ConsoleColor defaltForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = frameColor;
            Console.SetCursorPosition(X,Y);
            Console.Write(leftSide);
            Console.ForegroundColor = barColor;

            for (int i = 1; i <= lenght; i++)
            {
                if (i <= present * (lenght / maxPresent))
                {
                    Console.Write(bar);
                }
                else
                {
                    Console.Write(downSide);
                }
            }

            Console.ForegroundColor = frameColor;
            Console.Write(rightSide);
            Console.ForegroundColor = defaltForegroundColor;
        }
    }
}