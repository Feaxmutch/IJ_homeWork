namespace IJ_homeWork_shelfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int curentYear = 2024;

            List<Stew> stews = new()
            {
                new("Гродфуд", 2017, 4),
                new("Йошкар-Ола", 2021, 5),
                new("Йошкар-Ола", 2021, 5),
                new("Йошкар-Ола", 2018, 5),
                new("Селянская", 2024, 6),
                new("Йошкар-Ола", 2024, 5),
                new("Березовская", 2021, 5),
                new("Селянская", 2023, 6),
                new("Березовская", 2020, 5),
                new("Березовская", 2021, 5),
                new("Гродфуд", 2018, 4),
                new("Селянская", 2017, 6),
                new("Гродфуд", 2020, 4),
                new("Селянская", 2022, 6),
                new("Йошкар-Ола", 2024, 5),
                new("Селянская", 2018, 6),
                new("Гродфуд", 2024, 4),
                new("Гродфуд", 2017, 4),
                new("Селянская", 2021, 6),
                new("Йошкар-Ола", 2024, 5)
            };

            var expiredStew = stews.Where(stew => stew.YearOfProduction + stew.ShelfLife <= curentYear).
                                    OrderBy(stew => stew.Name).
                                    ToList();
            Console.WriteLine("Просроченая тушёнка:\n");

            foreach (var stew in expiredStew)
            {
                Console.Write($"название:\"{stew.Name}\" ");
                Console.Write($"Дата изготовления:\"{stew.YearOfProduction}\" ");
                Console.WriteLine($"Срок годности:\"{stew.ShelfLife}\"");
            }

            Console.ReadKey();
        }
    }

    class Stew
    {
        public Stew(string name, int yearOfProduction, int shelfLife)
        {
            Name = name;
            YearOfProduction = yearOfProduction;
            ShelfLife = shelfLife;
        }

        public string Name { get; }

        public int YearOfProduction { get; }

        public int ShelfLife { get; }
    }
}