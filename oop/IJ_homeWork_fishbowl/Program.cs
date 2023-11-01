namespace IJ_homeWork_fishbowl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startOld = 2;
            int maxOld = 10;
            Fishbowl fishbowl = new(startOld, maxOld);
            fishbowl.Live();
        }
    }

    class Fishbowl
    {
        private List<Fish> _fish = new List<Fish>();
        private int _startOld;
        private int _maxOld;

        public Fishbowl(int startOld, int maxOld)
        {
            startOld = Math.Max(0, startOld);
            maxOld = Math.Max(0, maxOld);
            _maxOld = Math.Max(maxOld, startOld);
            _startOld = startOld;
        }

        public void Live()
        {
            const ConsoleKey CommandAdd = ConsoleKey.A;
            const ConsoleKey CommandRemove = ConsoleKey.R;
            const ConsoleKey CommandExit = ConsoleKey.Escape;

            bool isLiving = true;

            while (isLiving)
            {
                for (int i = 0; i < _fish.Count; i++)
                {
                    _fish[i].Live();

                    if (_fish[i].IsAlive == false)
                    {
                        _fish.Remove(_fish[i]);
                    }
                }

                Console.Clear();
                ShowInfo();
                Console.WriteLine();
                Console.WriteLine($"{CommandAdd}) Добавить рыбу\n" +
                                  $"{CommandRemove}) Достать рыбу");
                ConsoleKey userInput = Console.ReadKey(true).Key;

                switch (userInput)
                {
                    case CommandAdd:
                        AddFish();
                        break;

                    case CommandRemove:
                        RemoveFish();
                        break;

                    case CommandExit:
                        isLiving = false;
                        break;
                }
            }
        }

        private void AddFish()
        {
            _fish.Add(new Fish(_maxOld, _startOld));
        }

        private void RemoveFish()
        {
            Console.Clear();
            ShowInfo();
            Console.WriteLine("Введите номер рыбы: ");
            string enteredNumber = Console.ReadLine();

            if (int.TryParse(enteredNumber, out int fishNumber))
            {
                if (fishNumber > 0 && fishNumber <= _fish.Count)
                {
                    _fish.RemoveAt(fishNumber - 1);
                }
                else
                {
                    Console.WriteLine($"Рыбы под номером {fishNumber} не существует");
                }
            }
            else
            {
                Console.WriteLine($"\"{enteredNumber}\" не является числом");
            }

            Console.ReadKey(true);
        }

        private void ShowInfo()
        {
            for (int i = 0; i < _fish.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Возраст: {_fish[i].Old}");
            }
        }
    }

    class Fish
    {
        private int _maxOld;

        public Fish(int maxOld, int startOld)
        {
            startOld = Math.Max(0, startOld);
            maxOld = Math.Max(0, maxOld);
            _maxOld = Math.Max(maxOld, startOld);
            Old = startOld;
        }

        public int Old { get; private set; }

        public bool IsAlive { get => Old <= _maxOld; }

        public void Live()
        {
            Old++;
        }
    }
}