namespace IJ_homeWork_stations
{
    internal class Program
    {
        static void Main()
        {
            List<Station> stations = new();

            stations.Add(new Station("Малинкино", 1));
            stations.Add(new Station("житейская", 2));
            stations.Add(new Station("карамовая", 3));
            stations.Add(new Station("рыбкино", 4));
            stations.Add(new Station("часовская", 5));
            stations.Add(new Station("челябенская", 6));

            Configurator configurator = new(stations);
            configurator.Work();
        }
    }

    static class OtherMethods
    {
        public static bool TryGetNumberFromUser(string massage, out int parsedNumber)
        {
            Console.Write(massage);
            string userInput = Console.ReadLine();

            if (userInput != string.Empty)
            {
                if (int.TryParse(userInput, out int number))
                {
                    parsedNumber = number;
                    return true;
                }
                else
                {
                    Console.WriteLine("Пожалуйста вводите только цифры.");
                }
            }
            else
            {
                Console.WriteLine("Вы ничего не ввели.");
            }

            parsedNumber = 0;
            return false;
        }
    }

    static class StaticRandom
    {
        private static Random s_random = new();
        public static Random Random { get => s_random;  }
    }

    class Configurator
    {
        private List<Station> _stations = new();
        private List<Train> _trains = new();

        public Configurator(List<Station> stations)
        {
            foreach (var station in stations)
            {
                _stations.Add(new Station(station.Name, station.Position));
            }

            for (int i = _stations.Count - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (_stations[i].Position == _stations[j].Position)
                    {
                        _stations.RemoveAt(i);
                    }
                }
            }

            MinPeoples = 0;
            MaxPeoples = 1080;
        }

        private int MinPeoples { get; }

        private int MaxPeoples { get; }

        public void Work()
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();

                for (int i = _trains.Count - 1; i >= 0; i--)
                {
                    if (_trains[i].InDestination)
                    {
                        _trains.RemoveAt(i);
                    }
                }

                ShowRoutes();
                Console.WriteLine();

                foreach (var train in _trains)
                {
                    train.Move();
                }

                AddRoute();
            }
        }

        private void ShowRoutes()
        {
            int distance;
            int peoplesCount;
            string name;

            Console.WriteLine("Активные Маршруты:");

            foreach (var train in _trains)
            {
                if (train.Destination.Position > train.Position)
                {
                    distance = train.Destination.Position - train.Position;
                }
                else
                {
                    distance = train.Position - train.Destination.Position;
                }

                peoplesCount = train.GetAllPeoplesCount();
                name = train.Destination.Name;
                Console.WriteLine($"До прибытия в \"{name}\" осталось {distance} шагов. Едет {peoplesCount} пассажиров");
            }
        }

        private void ShowStations()
        {
            for (int i = 0; i < _stations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. \"{_stations[i].Name}\" позиция {_stations[i].Position}");
            }
        }

        private void AddRoute()
        {
            bool isComplete = false;

            Console.WriteLine("Станции:");
            ShowStations();
            if (OtherMethods.TryGetNumberFromUser("Введите номер стартовой станции: ", out int number))
            {
                if (number > 0 && number <= _stations.Count)
                {
                    int startNumber = number;

                    if (OtherMethods.TryGetNumberFromUser("Введите номер конечной станции: ", out number))
                    {
                        if (number > 0 && number <= _stations.Count)
                        {
                            if (number != startNumber)
                            {
                                int endNumber = number;
                                _trains.Add(new Train(_stations[startNumber - 1].Position, new Station(_stations[endNumber - 1].Name, _stations[endNumber - 1].Position)));
                                _trains[_trains.Count - 1].TakePeoples(StaticRandom.Random.Next(MinPeoples, MaxPeoples));
                                isComplete = true;
                            }
                            else
                            {
                                Console.WriteLine($"Номер стартовой и конечной станции не должны совпадать.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Номера {number} нет в списке станций");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Номера {number} нет в списке станций");
                }
            }

            if (isComplete)
            {
                Console.WriteLine($"Маршрут создан. На данный маршрут было продано {_trains[_trains.Count - 1].GetAllPeoplesCount()} билетов");
            }
            else
            {
                Console.WriteLine("Маршрут не создан.");
            }

            Console.ReadKey();
        }
    }

    class Station
    {
        public Station(string name, int position)
        {
            Name = name;
            Position = Math.Abs(position);
        }

        public string Name { get; }

        public int Position { get; }
    }

    class Train
    {
        private List<Wagon> _wagons = new();

        public Train(int position, Station destination)
        {
            Position = Math.Abs(position);
            Destination = new Station(destination.Name, destination.Position);
            MinCapasity = 1;
            MaxCapasity = 54;
        }

        public int Position { get; private set; }

        public Station Destination { get; }

        public bool InDestination { get => Position == Destination.Position; }

        private int MinCapasity { get; }

        private int MaxCapasity { get; }

        public void TakePeoples(int quantity)
        {
            while (quantity > 0)
            {
                AddWagon(StaticRandom.Random.Next(MinCapasity, MaxCapasity));
                Wagon currentWagon = _wagons[_wagons.Count - 1];

                if (quantity > currentWagon.Сapacity)
                {
                    _wagons[_wagons.Count - 1].AddPeoples(currentWagon.Сapacity);
                    quantity -= currentWagon.Сapacity;
                }
                else
                {
                    _wagons[_wagons.Count - 1].AddPeoples(quantity);
                    quantity = 0;
                }
            }
        }

        public void Move()
        {
            if (Position < Destination.Position)
            {
                Position++;
            }
            else if(Position > Destination.Position)
            {
                Position--;
            }
        }

        public int GetAllPeoplesCount()
        {
            int peoples = 0;

            foreach (var wagon in _wagons)
            {
                peoples += wagon.Peoples;
            }

            return peoples;
        }

        private void AddWagon(int capasity)
        {
            _wagons.Add(new Wagon(capasity));
        }
    }

    class Wagon
    {
        public Wagon(int Capacity)
        {
            Сapacity = Capacity;
            Peoples = 0;
        }

        public int Peoples { get; private set; }

        public int Сapacity { get; }

        public void AddPeoples(int quantity)
        {
            Peoples += Math.Min(Сapacity - Peoples, Math.Max(0, quantity));
        }
    }
}