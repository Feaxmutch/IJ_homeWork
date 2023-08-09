namespace IJ_homeWork_class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandEscape = "Escape";

            bool isWorking = true;
            string userInput;
            Player player = new Player("Marakashka");

            while (isWorking)
            {
                Console.Clear();
                player.ShowInfo();

                Console.WriteLine($"Нажмите любую клавишу, чтобы поднять уровень, или {CommandEscape}, чтобы закрыть программу.");
                userInput = Console.ReadKey().Key.ToString();

                if (userInput == CommandEscape)
                {
                    isWorking = false;
                }

                player.UpLevel();
            }
        }
    }

    class Player
    {
        private string _name;
        private int _level;

        public Player(string name)
        {
            _name = name;
            _level = 0;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {_name}\nУровень: {_level}");
        }

        public void UpLevel()
        {
            _level++;
        }
    }
}