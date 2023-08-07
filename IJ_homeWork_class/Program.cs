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
        private string _Name;
        private int _Level;

        public Player(string name)
        {
            _Name = name;
            _Level = 0;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {_Name}\nУровень: {_Level}");
        }

        public void UpLevel()
        {
            _Level++;
        }
    }
}