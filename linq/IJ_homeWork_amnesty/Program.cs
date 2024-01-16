namespace IJ_homeWork_amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string crimeFilter = "Антиправительственное";

            List<People> peoples = new()
            {
                new("Элиза Каченья", "Административное"),
                new("Шэдди Сафади", "Административное"),
                new("Шая Пирсовская", "Антиправительственное"),
                new("Филипп Хассе", "Хулиганство"),
                new("Сергиу Волда", "Административное"),
                new("Саймон Венс", "Антиправительственное"),
                new("Натан Цикелек", "Административное"),
                new("Мессоф Анегович", "Антиправительственное"),
                new("Кордон Калло", "Хулиганство"),
                new("Джорджи Костава", "Антиправительственное"),
                new("Дари Лудум", "Антиправительственное"),
                new("Даник Лорун", "Хулиганство"),
                new("Винц Лэстрейд", "Административное")
            };

            Console.WriteLine("До амнистии");

            foreach (var people in peoples)
            {
                Console.WriteLine($"{people.FullName} | {people.Crime}");
            }

            var filteredPeoples = peoples.Where(people => people.Crime != crimeFilter);
            Console.WriteLine("\nПосле амнистии");

            foreach (var people in filteredPeoples)
            {
                Console.WriteLine($"{people.FullName} | {people.Crime}");
            }
        }
    }

    class People
    {
        public People(string fullName, string crime)
        {
            FullName = fullName;
            Crime = crime;
        }

        public string FullName { get; }

        public string Crime { get; }
    }
}