﻿namespace IJ_homeWork_zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animalTypes = new()
            {
                new Snake(Gender.Male),
                new Owl(Gender.Male),
                new Tiger(Gender.Male),
                new Goose(Gender.Male)
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

        public static bool TryGetNumberFromUse(string input, out int number)
        {
            number = 0;
            bool parseIsSuccessfull = false;

            if (input == string.Empty)
            {
                Console.WriteLine("Вы ничего не ввели");
            }
            else if (int.TryParse(input, out number) == false)
            {
                Console.WriteLine($"Не получилось конвертировать \"{input}\" в число");
            }
            else
            {
                parseIsSuccessfull = true;
            }

            return parseIsSuccessfull;
        }

        public static Gender GetRandomGender()
        {
            int maleIndex = (int)Gender.Male;
            int femaleIndex = (int)Gender.Female;
            return (Gender)s_random.Next(maleIndex, femaleIndex + 1);
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
        private IReadOnlyList<Animal> _animals;

        public Aviary(IReadOnlyList<Animal> animals)
        {
            _animals = animals;
        }

        public IReadOnlyList<Animal> Animals
        {
            get => _animals;
        }
    }

    abstract class Animal
    {
        public Animal(string name, Gender gender)
        {
            Name = name;
            Gender = gender;
        }

        public string Name { get; }

        public Gender Gender { get; }

        public abstract void MakeSound();

        public abstract Animal Clone(bool randomGender = false);
    }

    class Snake : Animal
    {
        public Snake(Gender gender) : base("змея", gender) { }

        public override void MakeSound()
        {
            Console.Write("Ш-ш-ш-ш");
        }

        public override Animal Clone(bool randomGender = false)
        {
            if (randomGender)
            {
                return new Snake(Utilits.GetRandomGender());
            }
            else
            {
                return new Snake(Gender);
            }
        }
    }

    class Owl : Animal
    {
        public Owl(Gender gender) : base("сова", gender) { }

        public override void MakeSound()
        {
            Console.Write("ух - ух");
        }

        public override Animal Clone(bool randomGender = false)
        {
            if (randomGender)
            {
                return new Owl(Utilits.GetRandomGender());
            }
            else
            {
                return new Owl(Gender);
            }
        }
    }

    class Tiger : Animal
    {
        public Tiger(Gender gender) : base("тигр", gender) { }

        public override void MakeSound()
        {
            Console.Write("РРРР");
        }

        public override Animal Clone(bool randomGender = false)
        {
            if (randomGender)
            {
                return new Tiger(Utilits.GetRandomGender());
            }
            else
            {
                return new Tiger(Gender);
            }
        }
    }

    class Goose : Animal
    {
        public Goose(Gender gender) : base("гусь", gender) { }

        public override void MakeSound()
        {
            Console.Write("га-га-га");
        }

        public override Animal Clone(bool randomGender = false)
        {
            if (randomGender)
            {
                return new Goose(Utilits.GetRandomGender());
            }
            else
            {
                return new Goose(Gender);
            }
        }
    }

    enum Gender
    {
        Male,
        Female
    }
}