namespace IJ_homeWork_UnificationOfTroops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string unificationСondition = "Б";

            List<Soulder> troop1 = new()
            {
                new("Свешников"),
                new("Киселев"),
                new("Бобров"),
                new("Рубцов"),
                new("Беляков"),
                new("Ильин"),
                new("Сидоров"),
                new("Старостин"),
                new("Бычков"),
                new("Антипов")
            };

            List<Soulder> troop2 = new()
            {
                new("Савельев"),
                new("Лазарев"),
                new("Калинин"),
                new("Барсуков"),
                new("Давыдов"),
                new("Воронин"),
                new("Борисов"),
                new("Ларин"),
                new("Казаков"),
                new("Беляев"),
            };

            var souldersForUnification = troop1.Where(soulder => soulder.LastName.StartsWith(unificationСondition));
            troop1 = troop1.Except(souldersForUnification).ToList();
            troop2 = troop2.Union(souldersForUnification).ToList();
        }
    }

    class Soulder
    {
        public Soulder(string lastName)
        {
            LastName = lastName;
        }

        public string LastName { get; }
    }
}