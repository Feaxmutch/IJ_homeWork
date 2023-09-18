namespace IJ_homeWork_War
{
    internal class Program
    {
        static void Main()
        {
            Battlefield battlefield = new();
            battlefield.Fight();
        }
    }

    static class StaticRandom
    {
        private static Random _random = new Random();

        public static int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }

    class Battlefield
    {
        private Platoon _leftPlatoon = new Platoon(5);
        private Platoon _rightPlatoon = new Platoon(5);
        private int _platoonTurn;

        public void Fight()
        {
            _platoonTurn = 1;

            while (_leftPlatoon.SoldiersCount > 0 && _rightPlatoon.SoldiersCount > 0)
            {
                Console.Clear();
                ShowInfo();

                if (_platoonTurn == 1)
                {
                    _leftPlatoon.AttackPlatoon(_rightPlatoon);
                    _platoonTurn = 2;
                }
                else
                {
                    _rightPlatoon.AttackPlatoon(_leftPlatoon);
                    _platoonTurn = 1;
                }

                Console.ReadKey();
            }

            Console.Clear();

            if (_leftPlatoon.SoldiersCount > 0)
            {
                Console.WriteLine("Победил взвод 1");
            }
            else
            {
                Console.WriteLine("Победил взвод 2");
            }
        }

        private void ShowInfo()
        {
            Console.WriteLine($"Солдат в 1-ом взводе: {_leftPlatoon.SoldiersCount}");
            Console.WriteLine($"Солдат в 2-ом взводе: {_rightPlatoon.SoldiersCount}");
            Console.WriteLine();
            Console.WriteLine($"Ход {_platoonTurn}-го взвода");
        }
    }

    class Platoon
    {
        private int _minPosition = 1;
        private int _maxPosition = 3;
        private List<Soldier> _soldiers = new List<Soldier>();

        public Platoon(int soldiersCount)
        {
            for (int i = 0; i < soldiersCount; i++)
            {
                _soldiers.Add(GenerateSoldier());
                SoldiersCount++;
            }
        }

        public int SoldiersCount { get; private set; }

        public Soldier GenerateSoldier()
        {
            const int sniper = 0;
            const int Supporter = 1;
            const int Stormtrooper = 2;

            const int AX50 = 3;
            const int Kar98k = 4;

            const int M13 = 5;
            const int Scar = 6;

            const int MP5 = 7;
            const int Uzi = 8;

            int soldierType = StaticRandom.Next(sniper, Stormtrooper + 1);
            int soldierPosition = StaticRandom.Next(_minPosition, _maxPosition + 1);
            int solderWeapon;

            switch (soldierType)
            {
                case sniper:
                    solderWeapon = StaticRandom.Next(AX50, Kar98k + 1);

                    switch (solderWeapon)
                    {
                        case AX50:
                            return new Sniper(soldierPosition, new AX50());

                        case Kar98k:
                            return new Sniper(soldierPosition, new Kar98k());
                    }
                    break;

                case Supporter:
                    solderWeapon = StaticRandom.Next(M13, Scar + 1);

                    switch (solderWeapon)
                    {
                        case M13:
                            return new Supporter(soldierPosition, new M13());

                        case Scar:
                            return new Supporter(soldierPosition, new Scar());
                    }
                    break;

                case Stormtrooper:
                    solderWeapon = StaticRandom.Next(MP5, Uzi + 1);

                    switch (solderWeapon)
                    {
                        case MP5:
                            return new Stormtrooper(soldierPosition, new MP5());

                        case Uzi:
                            return new Stormtrooper(soldierPosition, new Uzi());
                    }
                    break;
            }

            return null;
        }

        public void AttackPlatoon(Platoon target)
        {
            Soldier attackingSoldier = GetRandomSoldier(_soldiers);

            while (attackingSoldier.AttackDistance - attackingSoldier.Position <= _minPosition - 1)
            {
                if (GetSoldiersInPosition(_minPosition).Count != 0)
                {
                    attackingSoldier = GetRandomSoldier(GetSoldiersInPosition(1));
                }
                else
                {
                    MoveSoldiersForward();
                }
            }

            int targetPosition = StaticRandom.Next(_minPosition, attackingSoldier.AttackDistance - attackingSoldier.Position + 1);
            Console.WriteLine($"Солдат на позиции {attackingSoldier.Position} и дистанцией атаки {attackingSoldier.AttackDistance} атакует случайного солдата на позиции {targetPosition}");
            target.TakeDamage(targetPosition, attackingSoldier.WeaponDamage);
            
        }

        public void TakeDamage(int position, int damage)
        {
            Soldier attackedSoldier = GetRandomSoldier(GetSoldiersInPosition(position));

            if (attackedSoldier == null)
            {
                Console.WriteLine($"На позиции {position} никого не оказалось. Солдат никуда не попал");
            }
            else
            {
                attackedSoldier.TakeDamage(damage, out int finaleDamage);

                if (attackedSoldier.IsDied)
                {
                    _soldiers.Remove(attackedSoldier);
                    SoldiersCount--;
                }
            }
            
        }

        private List<Soldier> GetSoldiersInPosition(int position)
        {
            List<Soldier> soldiersInPosition = new List<Soldier>();

            foreach (var soldier in _soldiers)
            {
                if (soldier.Position == position)
                {
                    soldiersInPosition.Add(soldier);
                }
            }

            return soldiersInPosition;
        }

        private Soldier GetRandomSoldier(List<Soldier> soldiers)
        {
            if (soldiers.Count > 0)
            {
                return soldiers[StaticRandom.Next(0, soldiers.Count)];
            }
            else
            {
                return null;
            }
        }

        private void MoveSoldiersForward()
        {
            for (int i = _minPosition + 1; i <= _maxPosition; i++)
            {
                List<Soldier> soldiers = GetSoldiersInPosition(i);

                if (soldiers.Count != 0)
                {
                    foreach (var soldier in soldiers)
                    {
                        soldier.MoveTo(i - 1);
                    }
                }
            }
        }
    }

    abstract class Soldier
    {
        private double _armor;
        private Weapon _weapon;
        private int _position;

        public Soldier(double armor, int position ,Weapon weapon)
        {
            Health = 100;
            IsDied = false;
            Armor = armor;
            Position = position;
            _weapon = weapon;
        }

        public int Health { get; private set; }

        public bool IsDied { get; private set; }

        public double Armor
        {
            get
            {
                return _armor;
            }
            private set
            {
                _armor = Math.Clamp(value, 0, 0.9);
            }
        }

        public int Position
        {
            get
            {
                return _position;
            }
            private set
            {
                _position = Math.Clamp(value, 1, 3);
            }
        }

        public int WeaponDamage
        {
            get
            {
                return _weapon.Damage;
            }
        }

        public int AttackDistance
        {
            get
            {
                return _weapon.Distance;
            }
        }

        public void MoveTo(int position)
        {
            Position = position;
        }

        public void TakeDamage(int damage, out int finaleDamage)
        {
            finaleDamage = (int)(damage - (damage * Armor));
            Health -= finaleDamage;
            Console.WriteLine($"Солдат на позиции {Position} получил {finaleDamage} ед. урона");

            if (Health <= 0)
            {
                Console.WriteLine("Урон был смертелен");
                IsDied = true;
            }
        }
    }

    abstract class Weapon
    {
        private int _distance;
        private int _damage;

        public Weapon(int damage ,int distance)
        {
            Damage = damage;
            Distance = distance;
        }

        public int Distance 
        { 
            get
            {
                return _distance;
            }
            private set
            {
                _distance = Math.Max(value, 1);
            }
        }

        public int Damage
        {
            get
            {
                return _damage;
            }
            private set
            {
                _damage = Math.Max(value, 1);
            }
        }
    }

    abstract class SniperRifle : Weapon
    {
        public SniperRifle(int damage) : base(damage, 4)
        {

        }
    }

    abstract class Rifle : Weapon
    {
        public Rifle(int damage) : base(damage, 3)
        {

        }
    }

    abstract class SMG : Weapon
    {
        public SMG(int damage) : base(damage, 2)
        {
            
        }
    }

    class Sniper : Soldier
    {
        public Sniper(int position ,SniperRifle weapon) : base(0.2, position, weapon)
        {

        }
    }

    class Stormtrooper : Soldier
    {
        public Stormtrooper(int position, SMG weapon) : base(0.7, position, weapon)
        {

        }
    }

    class Supporter : Soldier
    {
        public Supporter(int position, Rifle weapon) : base(0.5, position, weapon)
        {

        }
    }

    class AX50 : SniperRifle
    {
        public AX50() : base(150)
        {

        }
    }

    class Kar98k : SniperRifle
    {
        public Kar98k() : base(120)
        {

        }
    }

    class M13 : Rifle
    {
        public M13() : base(25)
        {

        }
    }

    class Scar : Rifle
    {
        public Scar() : base(30)
        {

        }
    }

    class MP5 : SMG
    {
        public MP5() : base(22)
        {

        }
    }

    class Uzi : SMG
    {
        public Uzi() : base(14)
        {

        }
    }
}