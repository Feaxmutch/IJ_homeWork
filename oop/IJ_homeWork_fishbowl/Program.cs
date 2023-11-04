namespace IJ_homeWork_fishbowl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fishbowl fishbowl = new();
            fishbowl.Live();
        }
    }

    class Fishbowl
    {
        private List<Fish> _fishes = new List<Fish>();

        public void Live()
        {
            const ConsoleKey CommandAdd = ConsoleKey.A;
            const ConsoleKey CommandRemove = ConsoleKey.R;
            const ConsoleKey CommandExit = ConsoleKey.Escape;

            bool isLiving = true;

            while (isLiving)
            {
                for (int i = _fishes.Count - 1; i >= 0; i--)
                {
                    _fishes[i].AddOld();

                    if (_fishes[i].IsAlive == false)
                    {
                        _fishes.Remove(_fishes[i]);
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
            bool isCreating = true;

            while (isCreating)
            {
                Console.Clear();

                Console.Write("Введите стартовый возраст: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int startOld))
                {
                    Console.Write("Введите максимальный возраст: ");
                    userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out int maxOld))
                    {
                        _fishes.Add(new Fish(maxOld, startOld));
                        isCreating = false;
                    }
                    else
                    {
                        Console.WriteLine("максимальный возраст должен быть числом.");
                    }
                }
                else 
                {
                    Console.WriteLine("стартовый возраст должен быть числом.");
                }

                Console.ReadKey();
            }
        }

        private void RemoveFish()
        {
            Console.Clear();
            ShowInfo();
            Console.WriteLine("Введите номер рыбы: ");
            string enteredNumber = Console.ReadLine();

            if (int.TryParse(enteredNumber, out int fishNumber))
            {
                if (fishNumber > 0 && fishNumber <= _fishes.Count)
                {
                    _fishes.RemoveAt(fishNumber - 1);
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
            for (int i = 0; i < _fishes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Возраст: {_fishes[i].Old}");
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

        public void AddOld()
        {
            Old++;
        }
    }
}