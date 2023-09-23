namespace IJ_homeWork_War
{
    internal class Program
    {
        static void Main()
        {
            List<Platoon> platoons = new List<Platoon>() { new Platoon("Ястреб", 5), new Platoon("Кобра", 5) };
            Battlefield battlefield = new Battlefield(platoons);
            battlefield.Fight();
        }
    }

    static class StaticRandom
    {
        private static Random s_random = new Random();

        public static int GetRandomValue(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue);
        }
    }

    class Battlefield
    {
        private List<Platoon> _platoons = new List<Platoon>();

        public Battlefield(List<Platoon> platoons)
        {
            _platoons = new List<Platoon>(platoons);
        }

        public void Fight()
        {
            Platoon attacker;
            Platoon target;

            while (_platoons.Count > 1)
            {
                for (int i = 0; i < _platoons.Count && _platoons.Count > 1; i++)
                {
                    if (_platoons[i].SoldiersCount > 0)
                    {
                        attacker = _platoons[i];

                        if (i < _platoons.Count - 1)
                        {
                            target = _platoons[i + 1];
                        }
                        else
                        {
                            target = _platoons[0];
                        }

                        FightStep(attacker, target);
                    }
                    else
                    {
                        _platoons.RemoveAt(i);
                    }
                }
            }

            Console.Clear();
            Console.Write($"Победил взвод {_platoons[0].Name}");
            Console.ReadKey();
        }

        private void FightStep(Platoon attacker, Platoon target)
        {
            Console.Clear();
            ShowInfo();
            attacker.AttackPlatoon(target);
            Console.ReadKey();
        }

        private void ShowInfo()
        {
            for (int i = 0; i < _platoons.Count; i++)
            {
                Console.WriteLine($"Солдат в взводе {_platoons[i].Name}: {_platoons[i].SoldiersCount}");
            }

            Console.WriteLine();
        }
    }

    class Platoon
    {
        private int _minPosition = 1;
        private int _maxPosition = 3;
        private List<Soldier> _soldiers = new List<Soldier>();

        public Platoon(string name, int soldiersCount)
        {
            Name = name;

            for (int i = 0; i < soldiersCount; i++)
            {
                _soldiers.Add(GenerateSoldier());
            }
        }

        public int SoldiersCount
        {
            get => _soldiers.Count;
        }

        public string Name { get; private set; }

        public Soldier GenerateSoldier()
        {
            const int Sniper = 0;
            const int Supporter = 1;
            const int Stormtrooper = 2;

            int soldierType = StaticRandom.GetRandomValue(Sniper, Stormtrooper + 1);
            int soldierPosition = StaticRandom.GetRandomValue(_minPosition, _maxPosition + 1);

            switch (soldierType)
            {
                case Sniper:
                    return new Sniper(soldierPosition, new SniperRifle());

                case Supporter:
                    return new Supporter(soldierPosition, new Rifle());

                case Stormtrooper:
                    return new Stormtrooper(soldierPosition, new SMG());
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

            int targetPosition = StaticRandom.GetRandomValue(_minPosition, attackingSoldier.AttackDistance - attackingSoldier.Position + 1);
            Console.WriteLine($"Солдат взвода {Name} на позиции {attackingSoldier.Position} и дистанцией атаки {attackingSoldier.AttackDistance} атакует случайного солдата взвода {target.Name} на позиции {targetPosition}");
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
                attackedSoldier.TakeDamage(damage);

                if (attackedSoldier.IsDied)
                {
                    _soldiers.Remove(attackedSoldier);
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
                return soldiers[StaticRandom.GetRandomValue(0, soldiers.Count)];
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

        public Soldier(double armor, int position, Weapon weapon)
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
            get => _armor;
            private set => _armor = Math.Clamp(value, 0, 0.9);
        }

        public int Position
        {
            get => _position;
            private set => _position = Math.Clamp(value, 1, 3);
        }

        public int WeaponDamage
        {
            get => _weapon.Damage;
        }

        public int AttackDistance
        {
            get => _weapon.Distance;
        }

        public void MoveTo(int position)
        {
            Position = position;
        }

        public void TakeDamage(int damage)
        {
            int finaleDamage = (int)(damage - (damage * Armor));
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
        private int _minDamage;
        private int _maxDamage;

        public Weapon(int minDamage, int maxDamage, int distance)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Damage = StaticRandom.GetRandomValue(MinDamage, MaxDamage + 1);
            Distance = distance;
        }

        private int MinDamage
        {
            get => _minDamage;
            set => _minDamage = Math.Min(value, _maxDamage - 1);
        }

        private int MaxDamage
        {
            get => _maxDamage;
            set => _maxDamage = Math.Max(value, _minDamage + 1);
        }

        public int Distance
        {
            get => _distance;
            private set => _distance = Math.Max(value, 1);
        }

        public int Damage
        {
            get => _damage;
            private set => _damage = Math.Clamp(value, _minDamage, _maxDamage);
        }
    }

    class SniperRifle : Weapon
    {
        public SniperRifle() : base(110, 150, 4)
        {
        }
    }

    class Rifle : Weapon
    {
        public Rifle() : base(25, 40, 3){}
    }

    class SMG : Weapon
    {
        public SMG() : base(10, 25, 2){}
    }

    class Sniper : Soldier
    {
        public Sniper(int position, SniperRifle weapon) : base(0.2, position, weapon){}
    }

    class Stormtrooper : Soldier
    {
        public Stormtrooper(int position, SMG weapon) : base(0.7, position, weapon){}
    }

    class Supporter : Soldier
    {
        public Supporter(int position, Rifle weapon) : base(0.5, position, weapon){}
    }
}