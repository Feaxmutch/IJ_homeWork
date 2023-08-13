namespace IJ_homeWork_dataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string MenuAddPlayer = "1";
            const string MenuRemovePlayer = "2";
            const string MenuWritePlayers = "3";
            const string MenuBanPlayer = "4";
            const string MenuUnBanPlayer = "5";
            const string CommandExit = "exit";

            Database database = new Database();
            bool isWorking = true;
            string userInput = string.Empty;

            while (isWorking)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine($"{MenuAddPlayer}) добавить профиль" +
                                  $"\n{MenuRemovePlayer}) удалить профиль" +
                                  $"\n{MenuWritePlayers}) отобразить все профиля" +
                                  $"\n{MenuBanPlayer}) забанить профиль" +
                                  $"\n{MenuUnBanPlayer}) разбанить профиль" +
                                  $"\n{CommandExit}) закрыть программу");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case MenuAddPlayer:
                        database.AddPlayer();
                        break;

                    case MenuRemovePlayer:
                        database.RemovePlayer();
                        break;

                    case MenuWritePlayers:
                        database.WritePlayers();
                        break;

                    case MenuBanPlayer:
                        database.BanPlayer();
                        break;

                    case MenuUnBanPlayer:
                        database.UnbanPlayer();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }
    }

    class Database
    {
        private static Random _random = new Random();

        private List<PlayerProfile> _playerProfiles = new List<PlayerProfile>();

        public void AddPlayer()
        {
            int newId = _random.Next(100000, 999999);

            while (ContainsId(newId))
            {
                newId = _random.Next(100000, 999999);
            }

            Console.Clear();

            Console.Write("Введите имя игрока: ");
            string name = Console.ReadLine();

            Console.Write("Введите уровень игрока: ");
            string level  = Console.ReadLine();

            if (int.TryParse(level, out int parsedLevel))
            {
                _playerProfiles.Add(new PlayerProfile(newId, name, parsedLevel));
            }
            else
            {
                Console.WriteLine("Похоже вы ввели не число.");
            }
        }

        public void RemovePlayer()
        {
            WritePlayers();

            if (TryGetPlayer(out PlayerProfile player))
            {
                _playerProfiles.Remove(player);

                Console.WriteLine("Игрок успешно удалён.");
            }
            else
            {
                Console.WriteLine("Игрок не найден.");
            }
        }

        public void BanPlayer()
        {
            WritePlayers();

            if (TryGetPlayer(out PlayerProfile player))
            {
                player.Ban();

                Console.WriteLine("Игрок успешно заблокирован.");
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных.");
            }
        }

        public void UnbanPlayer()
        {
            WritePlayers();

            if (TryGetPlayer(out PlayerProfile player))
            {
                player.Unban();

                Console.WriteLine("Игрок успешно Разблокировн.");
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных.");
            }
        }

        public void WritePlayers()
        {
            ConsoleColor defaultForegroundColor = Console.ForegroundColor;
            ConsoleColor banColor = ConsoleColor.Red;

            Console.Clear();

            for (int i = 0; i < _playerProfiles.Count; i++)
            {
                if (_playerProfiles[i].IsBanned)
                {
                    Console.ForegroundColor = banColor;
                }
                else
                {
                    Console.ForegroundColor = defaultForegroundColor;
                }

                Console.WriteLine($"ID: {_playerProfiles[i].Id} Name: {_playerProfiles[i].Name} Level: {_playerProfiles[i].Level}");
            }

            Console.ForegroundColor = defaultForegroundColor;
            Console.ReadKey(true);
        }

        private bool ContainsId(int id)
        {
            for (int i = 0; i < _playerProfiles.Count; i++)
            {
                if (_playerProfiles[i].Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        private bool TryGetPlayer(out PlayerProfile player)
        {
            Console.Write("Введите id игрока: ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                for (int i = 0; i < _playerProfiles.Count; i++)
                {
                    if (_playerProfiles[i].Id == id)
                    {
                        player = _playerProfiles[i];
                        return true;
                    }
                }
            }

            player = null;
            return false;
        }
    }

    class PlayerProfile
    {
        public PlayerProfile(int id, string name, int level)
        {
            Id = id;
            Name = name;
            Level = level;
            IsBanned = false;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int Level { get; private set; }

        public bool IsBanned { get; private set; }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }
    }
}