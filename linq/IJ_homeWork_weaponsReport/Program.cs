namespace IJ_homeWork_weaponsReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Soulder> soulders = new()
            {
                new("Степан", "Scar", "Лейтенант", 2),
                new("Семён", "Scar", "Капрал", 3),
                new("Алиса", "MP5", "Рядовой", 2),
                new("Елена", "MP5", "Лейтенант", 1),
                new("Мелания", "Scar", "Рядовой", 1),
                new("Артём", "M4A1", "Капрал", 4),
                new("Тимур", "M60", "Сержант", 4),
                new("Есения", "MP5", "Капрал", 2),
                new("Максим", "M4A1", "Сержант", 4),
                new("Сафия", "MP5", "Сержант", 3)
            };

            var filteredSoulders = soulders.Select(soulder => new { soulder.Name, soulder.Rank });

            foreach (var soulder in filteredSoulders)
            {
                Console.WriteLine($"Имя:\"{soulder.Name}\" Звание:\"{soulder.Rank}\"");
            }

            Console.ReadKey();
        }
    }

    class Soulder
    {
        public Soulder(string name, string weapon, string rank, int serviceLife)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            ServiceLife = serviceLife;
        }

        public string Name { get; }

        public string Weapon { get; }

        public string Rank { get; }

        public int ServiceLife { get; }
    }
}