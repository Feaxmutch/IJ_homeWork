namespace IJ_homeWork_dataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string MenuAddPlayer = "D1";
            const string MenuRemovePlayer = "D2";
            const string MenuWritePlayers = "D3";
            const string MenuBanPlayer = "D4";
            const string MenuUnBanPlayer = "D5";
            const string CommandExit = "Escape";

            DataBase dataBase = new DataBase();
            bool isWorking = true;
            string userInput = string.Empty;

            while (isWorking)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine($"{MenuAddPlayer.Remove(0,1)}) добавить профиль" +
                                  $"\n{MenuRemovePlayer.Remove(0, 1)}) удалить профиль" +
                                  $"\n{MenuWritePlayers.Remove(0, 1)}) отобразить все профиля" +
                                  $"\n{MenuBanPlayer.Remove(0, 1)}) забанить профиль" +
                                  $"\n{MenuUnBanPlayer.Remove(0, 1)}) разбанить профиль" +
                                  $"\n{CommandExit}) закрыть программу");
                userInput = Console.ReadKey(true).Key.ToString();

                switch (userInput)
                {
                    case MenuAddPlayer:
                        AddPlayer(dataBase);
                        break;

                    case MenuRemovePlayer:
                        RemovePlayer(dataBase);
                        break;

                    case MenuWritePlayers:
                        WritePlayers(dataBase);
                        break;

                    case MenuBanPlayer:
                        BanPlayer(dataBase);
                        break;

                    case MenuUnBanPlayer:
                        UnBanPlayer(dataBase);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }

        static void AddPlayer(DataBase dataBase)
        {
            string userInput = string.Empty;

            while (userInput == string.Empty)
            {
                Console.Clear();

                Console.Write("Введите имя будуещего профиля: ");
                userInput = Console.ReadLine();
            }

            dataBase.AddPlayer(userInput);
        }

        static void RemovePlayer(DataBase dataBase)
        {
            string userInput = string.Empty;

            Console.Clear();
            dataBase.WritePlayers();

            Console.Write("Введите id профиля, который хотите удалить: ");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                dataBase.RemovePlayer(id);
            }
            else
            {
                Console.WriteLine("Похоже вы ввели не число.");
            }
        }

        static void WritePlayers(DataBase dataBase)
        {
            Console.Clear();
            dataBase.WritePlayers();
            Console.ReadKey(true);
        }

        static void BanPlayer(DataBase dataBase)
        {
            string userInput = string.Empty;

            Console.Clear();
            dataBase.WritePlayers();

            Console.Write("Введите id профиля, который хотите заблокировать: ");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                dataBase.BanPlayer(id);
            }
            else
            {
                Console.WriteLine("Похоже вы ввели не число.");
            }
        }

        static void UnBanPlayer(DataBase dataBase)
        {
            string userInput = string.Empty;

            Console.Clear();
            dataBase.WritePlayers();

            Console.Write("Введите id профиля, который хотите разблокировать: ");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                dataBase.UnBanPlayer(id);
            }
            else
            {
                Console.WriteLine("Похоже вы ввели не число.");
            }
        }
    }

    class DataBase
    {
        private List<PlayerProfile> _playerProfiles = new List<PlayerProfile>();

        private bool Contains(int id)
        {
            for (int i = 0; i < _playerProfiles.Count; i++)
            {
                if (_playerProfiles[i].ID == id)
                {
                    return true;
                }
            }

            return false;
        }

        private int GetPlayerIndex(int id)
        {
            for (int i = 0; i < _playerProfiles.Count; i++)
            {
                if (_playerProfiles[i].ID == id)
                {
                    return i;
                }
            }

            return -1;
        }

        public void AddPlayer(string name)
        {
            Random random = new Random();
            int newID = random.Next(100000, 999999);

            while (Contains(newID))
            {
                newID = random.Next(100000, 999999);
            }

            _playerProfiles.Add(new PlayerProfile(newID, name));
        }

        public void RemovePlayer(int id)
        {
            if (Contains(id))
            {
                _playerProfiles.RemoveAt(GetPlayerIndex(id));
            }
            else
            {
                Console.WriteLine($"игрок с id {id} не найден.");
            }
        }

        public void BanPlayer(int id)
        {
            if (Contains(id))
            {
                if (_playerProfiles[GetPlayerIndex(id)].IsBanned == false)
                {
                    _playerProfiles[GetPlayerIndex(id)].Ban();
                }
                else
                {
                    Console.WriteLine($"игрок с id {id} уже забанен.");
                }
            }
            else
            {
                Console.WriteLine($"игрок с id {id} не найден.");
            }
        }

        public void UnBanPlayer(int id)
        {
            if (Contains(id))
            {
                if (_playerProfiles[GetPlayerIndex(id)].IsBanned == true)
                {
                    _playerProfiles[GetPlayerIndex(id)].UnBan();
                }
                else
                {
                    Console.WriteLine($"игрок с id {id} уже разбанен.");
                }
            }
            else
            {
                Console.WriteLine($"игрок с id {id} не найден.");
            }
        }

        public void WritePlayers()
        {
            ConsoleColor defaultForegroundColor = Console.ForegroundColor;
            ConsoleColor banColor = ConsoleColor.Red;

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

                Console.WriteLine($"ID: {_playerProfiles[i].ID} Name: {_playerProfiles[i].Name} Level: {_playerProfiles[i].Level}");
            }

            Console.ForegroundColor = defaultForegroundColor;
        }
    }

    class PlayerProfile
    {
        public PlayerProfile(int id, string name)
        {
            ID = id;
            Name = name;
            Level = 0;
            IsBanned = false;
        }

        public int ID { get; private set; }

        public string Name { get; private set; }

        public int Level { get; private set; }

        public bool IsBanned { get; private set; }

        public void Ban()
        {
            IsBanned = true;
        }

        public void UnBan()
        {
            IsBanned = false;
        }
    }
}