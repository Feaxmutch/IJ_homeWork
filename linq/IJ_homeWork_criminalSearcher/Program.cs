namespace IJ_homeWork_criminalSearcher
{
    internal class Program
    {
        static void Main()
        {
            List<Criminal> criminals = new()
            {
                new("Носов Александр Тимурович", 161, 68, "Россия", true),
                new("Ковалев Гордей Иванович", 164, 67, "Россия", false),
                new("Поляков Владислав Дмитриевич", 176, 53, "Россия", false),
                new("Румянцев Евгений Богданович", 186, 60, "Россия", true),
                new("Ерофеева София Эмильевна", 180, 57, "Россия", false),
                new("Тихонова Екатерина Дмитриевна", 172, 79, "Россия", false),
                new("Денисов Макар Дмитриевич", 178, 61, "Россия", false),
                new("Власов Денис Михайлович", 173, 51, "Россия", true),
                new("Трофимова Елизавета Ильинична", 186, 60, "Россия", false),
                new("Одинцова Таисия Ярославовна", 161, 62, "Россия", false)
            };

            Searcher searcher = new(criminals);
            searcher.Start();
        }
    }

    class Searcher
    {
        private string _exitWord = "exit";
        private bool _isWorking;
        private List<Criminal> _criminals;

        public Searcher(List<Criminal> criminals)
        {
            _criminals = criminals;
        }

        public void Start()
        {
            _isWorking = true;

            while (_isWorking)
            {
                Console.Clear();
                Search();
            }
        }

        private void Search()
        {
            Console.WriteLine($"Введите рост, или \"{_exitWord}\" чтобы выйти:");
            string userCommand = Console.ReadLine();

            if (userCommand == _exitWord)
            {
                _isWorking = false;
                return;
            }
            else
            {
                if (int.TryParse(userCommand, out int height))
                {
                    Console.WriteLine("Введите вес:");

                    if (int.TryParse(Console.ReadLine(), out int weight))
                    {
                        Console.WriteLine("Введите национальность:");
                        string nationality = Console.ReadLine();

                        var searchResult = _criminals.Where(criminal => criminal.Height == height &&
                                                                         criminal.Weight == weight &&
                                                                         criminal.Nationality.ToUpper() == nationality.ToUpper() &&
                                                                         criminal.Arrested == false);

                        Console.WriteLine();
                        ShowResult(searchResult.ToList());
                    }
                }
            }
        }

        private void ShowResult(List<Criminal> result)
        {
            Console.WriteLine("Результаты поиска:");

            if (result.Count > 0)
            {
                foreach (var criminal in result)
                {
                    Console.WriteLine(criminal.FullName);
                }
            }
            else
            {
                Console.WriteLine("Ничего не найдено.");
            }

            Console.ReadKey();
        }
    }

    class Criminal
    {
        public Criminal(string fullName, int height, int weight, string nationality, bool arrested)
        {
            FullName = fullName;
            Height = height;
            Weight = weight;
            Nationality = nationality;
            Arrested = arrested;
        }

        public string FullName { get; }

        public int Height { get; }

        public int Weight { get; }

        public string Nationality { get; }

        public bool Arrested { get; }
    }
}