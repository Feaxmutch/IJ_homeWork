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
            ConsoleKeyInfo userInput;

            Console.CursorVisible = false;

            while (isWorking)
            {
                DrawLevel(map, character, characterCordinates);
                userInput = Console.ReadKey();

                switch (userInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveUp(map, wall, characterCordinates);
                        break;

                    case ConsoleKey.DownArrow:
                        MoveDown(map, wall, characterCordinates);
                        break;

                    case ConsoleKey.LeftArrow:
                        MoveLeft(map, wall, characterCordinates);
                        break;

                    case ConsoleKey.RightArrow:
                        MoveRight(map, wall, characterCordinates);
                        break;

                    case ConsoleKey.Escape:
                        isWorking = false;
                        break;
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
                        DrawCharacter(character, characterCordinates);
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

        static void DrawCharacter(char symbol, int[] cordinates)
        {
            Console.SetCursorPosition(cordinates[0], cordinates[1]);
            Console.Write(symbol);
        }

        static void MoveRight(char[,] map, char wallChar, int[] characterCordinates)
        {
            if (map[characterCordinates[0] + 1, characterCordinates[1]] != wallChar)
            {
                characterCordinates[0]++;
            }
        }

        static void MoveLeft(char[,] map, char wallChar, int[] characterCordinates)
        {
            if (map[characterCordinates[0] - 1, characterCordinates[1]] != wallChar)
            {
                characterCordinates[0]--;
            }
        }

        static void MoveUp(char[,] map, char wallChar, int[] characterCordinates)
        {
            if (map[characterCordinates[0], characterCordinates[1] - 1] != wallChar)
            {
                characterCordinates[1]--;
            }
        }

        static void MoveDown(char[,] map, char wallChar, int[] characterCordinates)
        {
            if (map[characterCordinates[0], characterCordinates[1] + 1] != wallChar)
            {
                characterCordinates[1]++;
            }
        }
    }
}