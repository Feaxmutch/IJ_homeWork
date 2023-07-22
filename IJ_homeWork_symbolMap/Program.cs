namespace IJ_homeWork_symbolMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            char character = Convert.ToChar(File.ReadAllText("character.txt"));
            int[] characterCordinates = new int[2];
            characterCordinates[0] = 5;
            characterCordinates[1] = 5;
            char[,] map = CreateMapFromFile("map.txt");

            Console.CursorVisible = false;

            while (isWorking)
            {
                UpdateMap(map, character, characterCordinates);
            }
        }

        static void UpdateMap(char[,] map, char character, int[] characterCordinates)
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

        static int[] MoveCharacter(int[] cordinates, int moveDeractionX, int moveDeractionY)
        {
            return cordinates;
        }
    }
}