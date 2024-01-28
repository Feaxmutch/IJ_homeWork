namespace IJ_homeWork_weaponsReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Soulder> soulders = new()
            {
                new("Степан", Weapon.Scar, Rank.Лейтенант, 2),
                new("Семён", Weapon.Scar, Rank.Капрал, 3),
                new("Алиса", Weapon.MP5, Rank.Рядовой, 2),
                new("Елена", Weapon.MP5, Rank.Лейтенант, 1),
                new("Мелания", Weapon.Scar, Rank.Рядовой, 1),
                new("Артём", Weapon.M4A1, Rank.Капрал, 4),
                new("Тимур", Weapon.M4A1, Rank.Сержант, 4),
                new("Есения", Weapon.MP5, Rank.Капрал, 2),
                new("Максим", Weapon.M4A1, Rank.Сержант, 4),
                new("Сафия", Weapon.MP5, Rank.Сержант, 3)
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
        public Soulder(string name, Weapon weapon, Rank rank, int serviceLife)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            ServiceLife = serviceLife;
        }

        public string Name { get; }

        public Weapon Weapon { get; }

        public Rank Rank { get; }

        public int ServiceLife { get; }
    }

    enum Weapon
    {
        M4A1,
        MP5,
        M60,
        Scar
    }

    enum Rank
    {
        Рядовой,
        Капрал,
        Сержант,
        Лейтенант
    }
}