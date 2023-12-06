namespace IJ_homeWork_zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int snakesCount = 3;
            int owlsCount = 1;

            Random random = new();
            List<Aviary> aviaries = new();
            List<Animal> snakes = new();
            List<Animal> owls = new();

            for (int i = 0; i < snakesCount; i++)
            {
                snakes.Add(new Snake((Gender)random.Next((int)Gender.Male, (int)Gender.Female + 1)));
            }
            
            for (int i = 0; i < owlsCount; i++)
            {
                owls.Add(new Owl((Gender)random.Next((int)Gender.Male, (int)Gender.Female + 1)));
            }

            aviaries.Add(new Aviary(snakes));
            aviaries.Add(new Aviary(owls));
            Zoo zoo = new(aviaries);
            zoo.Open();
        }
    }

    static class Utilits
    {
        public static bool TryGetNumberFromUser(string input, out int number )
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
            if (Utilits.TryGetNumberFromUser(input, out int aviaryNumber))
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
        private List<Animal> _animals = new List<Animal>();

        public Aviary(List<Animal> animals)
        {
            _animals = GetAnimalsCopy(animals);
        }

        public List<Animal> Animals 
        {
            get => GetAnimalsCopy(_animals);
        }

        private List<Animal> GetAnimalsCopy(List<Animal> OriginalList)
        {
            List<Animal> newList = new();

            foreach (var animal in OriginalList)
            {
                switch (animal)
                {
                    case Snake:
                        newList.Add(new Snake(animal.Gender));
                        break;

                    case Owl:
                        newList.Add(new Owl(animal.Gender));
                        break;
                }
            }

            return newList;
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
    } 

    class Snake : Animal
    {
        public Snake(Gender gender) : base("змея", gender){}

        public override void MakeSound()
        {
            Console.Write("Ш-ш-ш-ш");
        }
    }

    class Owl : Animal
    {
        public Owl(Gender gender) : base("сова", gender){}

        public override void MakeSound()
        {
            Console.Write("ух - ух");
        }
    }
    
    enum Gender
    {
        Male,
        Female
    }
}