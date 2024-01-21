namespace IJ_homeWork_Leaderboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int levelLeaderboardPosition = 0;
            int strengthLeaderboardPosition = 60;
            int playersInLeaderboard = 3;

            List<Player> players = new()
            {
                new("HaGuBatoP_TanKoV", 56, 15),
                new("One_ShOt_ONe_Kill", 65, 59),
                new("zeon", 78, 32),
                new("Glamorous", 23, 93),
                new("Filipin is bro Heldor Lenstop", 82, 80),
                new("Papar@zzi", 68, 12),
                new("Ate1st", 90, 59),
                new("Archer", 46, 81),
                new("Kuki", 52, 57),
                new("NIGGA_KillER", 91, 32)
            };

            var levelLeaderboard = players.OrderByDescending(player => player.Level).ToList();
            var strengthLeaderboard = players.OrderByDescending(player => player.Strength).ToList();

            WriteLeaderboard(levelLeaderboard, playersInLeaderboard, levelLeaderboardPosition);
            WriteLeaderboard(strengthLeaderboard, playersInLeaderboard, strengthLeaderboardPosition);

            Console.ReadKey();
        }

        static void WriteLeaderboard(List<Player> players, int leaderboardCap, int leaderboardPosition)
        {
            for (int i = 0; i < leaderboardCap; i++)
            {
                Console.SetCursorPosition(leaderboardPosition, i);
                Console.Write($"name:\"{players[i].Name}\" level:{players[i].Level} strength:{players[i].Strength}");
            }
        }
    }

    class Player
    {
        public Player(string name, int level, int strength)
        {
            Name = name;
            Level = level;
            Strength = strength;
        }

        public string Name { get; }

        public int Level { get; private set; }

        public int Strength { get; private set; }
    }
}