namespace IJ_homeWork_symbolMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            char character = Convert.ToChar(File.ReadAllText("character.txt"));
            char wall = Convert.ToChar(File.ReadAllText("wall.txt"));
            int[] characterCordinates = new int[2] {5,5};
            char[,] map = CreateMapFromFile("map.txt");

            Console.CursorVisible = false;

            while (isWorking)
            {
                DrawLevel(map, character, characterCordinates);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey(true);

                    if (userInput.Key == ConsoleKey.Escape)
                    {
                        isWorking = false;
                    }
                    else
                    {
                        GetDirection(userInput, map, wall, characterCordinates);
                    }
                }
            }
        }

        static void DrawLevel(char[,] map, char character, int[] characterCordinates)
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (j == characterCordinates[0] && i == characterCordinates[1])
                    {
                        DrawSymbol(character, characterCordinates);
                    }
                    else
                    {
                        Console.Write(map[j, i]);
                    }
                }

                Console.WriteLine();
            }
        }

        static char[,] CreateMapFromFile(string filePath)
        {
            string[] file = File.ReadAllLines(filePath);
            char[,] map = new char[file[0].Length, file.Length];

            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    map[j, i] = file[i][j];
                }
            }

            return map;
        }

        static void DrawSymbol(char symbol, int[] cordinates)
        {
            Console.SetCursorPosition(cordinates[0], cordinates[1]);
            Console.Write(symbol);
        }

        static void MoveChar(char[,] map, int[] charCordinates, int charDirectionX, int charDirectionY, char wallChar)
        {
            if (map[charCordinates[0] + charDirectionX, charCordinates[1] + charDirectionY] != wallChar)
            {
                charCordinates[0] += charDirectionX;
                charCordinates[1] += charDirectionY;
            }
        }

        static void GetDirection(ConsoleKeyInfo userInput, char[,] map, char wallChar, int[] charCordinates)
        {
            const ConsoleKey UpArrow = ConsoleKey.UpArrow;
            const ConsoleKey DownArrow = ConsoleKey.DownArrow;
            const ConsoleKey LeftArrow = ConsoleKey.LeftArrow;
            const ConsoleKey RightArrow = ConsoleKey.RightArrow;

            int directionX = 0;
            int directionY = 0;

            switch (userInput.Key)
            {
                case UpArrow:
                    directionY = -1;
                    break;

                case DownArrow:
                    directionY = +1;
                    break;

                case LeftArrow:
                    directionX = -1;
                    break;

                case RightArrow:
                    directionX = +1;
                    break;
            }

            MoveChar(map, charCordinates, directionX, directionY, wallChar);
        }
    }
}