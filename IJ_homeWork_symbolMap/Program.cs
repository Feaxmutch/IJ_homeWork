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

        static void MoveChar(int[] charCordinates, int[] charDirection)
        {
            charCordinates[0] += charDirection[0];
            charCordinates[1] += charDirection[1];
        }

        static void GetDirection(ConsoleKeyInfo userInput, char[,] map, char wallChar, int[] charCordinates)
        {
            switch (userInput.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[charCordinates[0], charCordinates[1] -1] != wallChar)
                    {
                        MoveChar(charCordinates, new int[] { 0, - 1 });
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (map[charCordinates[0], charCordinates[1] + 1] != wallChar)
                    {
                        MoveChar(charCordinates, new int[] { 0, + 1 });
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (map[charCordinates[0] - 1, charCordinates[1]] != wallChar)
                    {
                        MoveChar(charCordinates, new int[] { - 1, 0 });
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (map[charCordinates[0] + 1, charCordinates[1]] != wallChar)
                    {
                        MoveChar(charCordinates, new int[] { + 1, 0 });
                    }
                    break;
            }
        }
    }
}