namespace IJ_homeWork_zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animalTypes = new()
            {
                new Animal("змея", "Ш-ш-ш-ш", Gender.Male),
                new Animal("сова", "ух - ух", Gender.Male),
                new Animal("тигр", "РРРР", Gender.Male),
                new Animal("гусь", "га-га-га", Gender.Male),
            };

            List<int> animalCounts = new()
            {
                4,
                2,
                3,
                5
            };

            AnimalsCreator animalsCreator = new(animalTypes);
            var animalGrops = animalsCreator.Create(animalCounts);
            List<Aviary> aviaries = new();

            for (int i = 0; i < animalGrops.Count; i++)
            {
                aviaries.Add(new Aviary(animalGrops[i]));
            }

            Zoo zoo = new(aviaries);
            zoo.Open();
        }
    }

    static class Utilits
    {
        private static Random s_random = new();

        public static Gender GetRandomGender()
        {
            int maleIndex = (int)Gender.Male;
            int femaleIndex = (int)Gender.Female;
            return (Gender)s_random.Next(maleIndex, femaleIndex + 1);
        }

        public static List<Animal> CopyList(List<Animal> originalList)
        {
            List<Animal> newList = new();

            foreach (var animal in originalList)
            {
                newList.Add(animal.Clone());
            }

            return newList;
        }
    }

    class AnimalsCreator
    {
        private List<Animal> _animalTypes = new();

        public AnimalsCreator(List<Animal> animalTypes)
        {
            foreach (var animal in animalTypes)
            {
                _animalTypes.Add(animal.Clone());
            }
        }

        public List<List<Animal>> Create(List<int> animalCounts)
        {
            List<List<Animal>> animalGrops = new();

            for (int i = 0; i < _animalTypes.Count; i++)
            {
                animalGrops.Add(new List<Animal>());

                for (int j = 0; j < animalCounts[i]; j++)
                {
                    animalGrops[i].Add(_animalTypes[i].Clone(true));
                }
            }

            return animalGrops;
        }
    }

    class Zoo
    {
        private const string CommandEscape = "escape";

        private List<Aviary> _aviaries = new List<Aviary>();

        public Zoo(List<Aviary> aviaries)
        {
            List<Aviary> newList = new();

            foreach (var aviary in aviaries)
            {
                newList.Add(new Aviary(aviary.Animals));
            }

            _aviaries = newList;
        }

        public void Open()
        {
            bool isOpened = true;

            while (isOpened)
            {
                Console.Clear();
                ShowAviarys();
                Console.WriteLine($"Выберите вольер, к которому хотите подойти, или {CommandEscape}, чтобы закрыть программу.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandEscape:
                        isOpened = false;
                        break;

                    default:
                        TrySelectAviary(userInput);
                        break;
                }
            }
        }

        private void ShowAviarys()
        {
            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"Вольер {i + 1}");
            }
        }

        private void ShowAnimals(int aviaryNumber)
        {
            Aviary aviary = _aviaries[aviaryNumber - 1];
            Console.WriteLine($"Обитатели вольера {aviaryNumber}");

            foreach (var animal in aviary.Animals)
            {
                Console.Write($"{animal.Name}. Пол - ");

                switch (animal.Gender)
                {
                    case Gender.Male:
                        Console.Write("мужской");
                        break;

                    case Gender.Female:
                        Console.Write("женский");
                        break;
                }

                Console.Write(". Издаёт звук - ");
                animal.MakeSound();
                Console.WriteLine();
            }
        }

        private void TrySelectAviary(string input)
        {
            if (input == string.Empty)
            {
                Console.WriteLine("Вы ничего не ввели");
            }
            else if (int.TryParse(input, out int aviaryNumber) == false)
            {
                Console.WriteLine($"Не получилось конвертировать \"{input}\" в число");
            }
            else
            {
                if (aviaryNumber > 0 && aviaryNumber <= _aviaries.Count)
                {
                    Console.Clear();
                    ShowAnimals(aviaryNumber);
                }
                else
                {
                    Console.WriteLine($"Номера \"{aviaryNumber}\" не существует");
                }
            }

            Console.ReadKey(true);
        }
    }

    class Aviary
    {
        private List<Animal> _animals;

        public Aviary(List<Animal> animals)
        {
            _animals = animals;
        }

        public List<Animal> Animals
        {
            get => Utilits.CopyList(_animals);
        }
    }

    class Animal
    {
        private string _sound;

        public Animal(string name, string sound, Gender gender)
        {
            Name = name;
            _sound = sound;
            Gender = gender;
        }

        public string Name { get; }

        public Gender Gender { get; }

        public void MakeSound()
        {
            Console.Write(_sound);
        }

        public Animal Clone(bool randomGender = false)
        {
            if (randomGender)
            {
                return new Animal(Name, _sound, Utilits.GetRandomGender());
            }
            else
            {
                return new Animal(Name, _sound, Gender);
            }
        }
    }

    enum Gender
    {
        Male,
        Female
    }
}