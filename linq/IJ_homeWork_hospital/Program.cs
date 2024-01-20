namespace IJ_homeWork_hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<People> peoples = new()
            {
                new("Еремин Александр Михайлович", 32, "Сахарный диабет"),
                new("Климов Павел Дмитриевич", 39, "Депрессия"),
                new("Емельянов Алексей Максимович", 43, "Депрессия"),
                new("Яшина Дарья Тимофеевна", 55, "Болезнь Паркинсона"),
                new("Егорова Вероника Михайловна", 30, "Сахарный диабет"),
                new("Алексеев Алексей Даниилович", 54, "Болезнь Паркинсона"),
                new("Овсянников Александр Иванович", 46, "Артрит"),
                new("Александров Ярослав Алексеевич", 22, "Пневмония"),
                new("Трошин Матвей Максимович", 32, "Сахарный диабет"),
                new("Алексеева Кира Данииловна", 58, "Болезнь Паркинсона"),
                new("Кочеткова Оливия Егоровна", 27, "Пневмония"),
                new("Терентьев Егор Маркович", 44, "Артрит"),
                new("Козлова Варвара Ярославовна", 50, "Болезнь Паркинсона"),
                new("Жукова Софья Ильинична", 56, "Болезнь Паркинсона"),
                new("Завьялов Мирон Ильич", 54, "Пневмония"),
                new("Гордеева Полина Алексеевна", 22, "Сахарный диабет"),
                new("Тимофеева Алиса Ярославовна", 29, "Сахарный диабет"),
                new("Денисова Дарья Данииловна", 33, "Артрит"),
                new("Демин Михаил Львович", 49, "Депрессия"),
                new("Шубин Алексей Ярославович", 43, "Болезнь Паркинсона")
            };

            Searcher searcher = new(peoples);
            searcher.Start();
        }
    }

    class Searcher
    {
        private List<People> _peoples;
        private bool _isWorking;

        public Searcher(List<People> peoples)
        {
            _peoples = peoples;
        }

        public void Start()
        {
            _isWorking = true;

            while (_isWorking)
            {
                Menu();
            }
        }

        private void Menu()
        {
            const string CommandFullNameSort = "1";
            const string CommandOldSort = "2";
            const string CommandSicknessFiltering = "3";
            const string CommandExit = "4";

            Console.Clear();
            Console.WriteLine($"{CommandFullNameSort})Отсортировать всех больных по фио\n" +
                              $"{CommandOldSort})Отсортировать всех больных по возрасту\n" +
                              $"{CommandSicknessFiltering})Вывести больных с определенным заболеванием\n" +
                              $"{CommandExit})Закрыть программу");

            switch (Console.ReadLine())
            {
                case CommandFullNameSort:
                    SortByFullName();
                    break;

                case CommandOldSort:
                    SortByOld();
                    break;

                case CommandSicknessFiltering:
                    FikterBySickness();
                    break;

                case CommandExit:
                    _isWorking = false;
                    break;
            }
        }

        private void SortByFullName()
        {
            var sortedPeoples = _peoples.OrderBy(people => people.FullName);
            ShowResult(sortedPeoples.ToList());
        }

        private void SortByOld()
        {
            var sortedPeoples = _peoples.OrderBy(people => people.Old);
            ShowResult(sortedPeoples.ToList());
        }

        private void FikterBySickness()
        {
            Console.WriteLine("\nВведите назване болезни:");
            string sicknessFilter = Console.ReadLine();

            var filteredPeoples = _peoples.Where(people => people.Sickness.ToUpper() == sicknessFilter.ToUpper()).
                                           OrderBy(people => people.FullName);
            ShowResult(filteredPeoples.ToList());
        }

        private void ShowResult(List<People> result)
        {
            if (result.Count > 0)
            {
                foreach (var people in result)
                {
                    Console.WriteLine($"{people.FullName} {people.Old} {people.Sickness}");
                }
            }
            else
            {
                Console.Write("Ничего не найдено.");
            }

            Console.ReadKey();
        }
    }

    class People
    {
        public People(string fullName, int old, string sickness)
        {
            FullName = fullName;
            Old = old;
            Sickness = sickness;
        }

        public string FullName { get; }

        public int Old { get; }

        public string Sickness { get; }
    }
}