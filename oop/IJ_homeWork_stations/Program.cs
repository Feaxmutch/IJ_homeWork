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

        }
    }

    static class StaticRandom
    {
        public static Random S_Random { get; }
    }

    class Configurator
    {
        private List<Station> _stations;

        public Configurator(List<Station> stations)
        {
            _stations = stations;
        }
    }

    class Station
    {
        public Station(string name, int position)
        {
            Name = name;
            Position = position;
        }

        public string Name { get; }

        public int Position { get; }
    }

    class Train
    {
        private List<Wagon> _wagons = new();

        public Train(int minCapacity, int maxСapacity)
        {
            MinCapasity = Math.Max(1, minCapacity);
            MaxCapasity = Math.Max(minCapacity, maxСapacity);
        }

        public int Position { get; private set; }

        private int MinCapasity { get; }

        private int MaxCapasity { get; }

        public void TakePeoples(int quantity)
        {
            while (quantity > 0)
            {
                AddWagon(StaticRandom.S_Random.Next(MinCapasity, MaxCapasity));
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

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    Position--;
                    break;

                case Direction.Right:
                    Position++;
                    break;
            }
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

    enum Direction
    {
        Left,
        Right
    }
}