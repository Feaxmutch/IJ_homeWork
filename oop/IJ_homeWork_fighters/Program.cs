namespace IJ_homeWork_fighters
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<ConsoleColor, Fighter> fighters = new Dictionary<ConsoleColor, Fighter>();
            ConsoleColor color1 = ConsoleColor.Red;
            ConsoleColor color2 = ConsoleColor.Blue;


            fighters[color1] = SetFighter(color1);
            fighters[color2] = SetFighter(color2);

            while (fighters[color1].Health > 0 && fighters[color2].Health > 0)
            {
                FightStage(fighters, color1, color2);

                if (fighters[color1].Health > 0 && fighters[color2].Health > 0 == false)
                {
                    break;
                }

                FightStage(fighters, color2, color1);
            }

            Console.Clear();

            if (fighters[color1].Health > 0)
            {
                Console.ForegroundColor = color1;
                fighters[color1].WriteWinWords();
            }
            else
            {
                Console.ForegroundColor = color2;
                fighters[color2].WriteWinWords();
            }
        }

        static Fighter SetFighter(ConsoleColor color)
        {
            const ConsoleKey CommandKnight = ConsoleKey.D1;
            const ConsoleKey CommandSpearman = ConsoleKey.D2;
            const ConsoleKey CommandBarbarian = ConsoleKey.D3;
            const ConsoleKey CommandViking = ConsoleKey.D4;
            const ConsoleKey CommandSheldMan = ConsoleKey.D5;

            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            bool isSelecting = true;

            while (isSelecting)
            {
                Console.Clear();
                Console.WriteLine($"Выберите бойца:\n" +
                              $"{CommandKnight}) Рыцарь\n" +
                              $"{CommandSpearman}) Копейщик\n" +
                              $"{CommandBarbarian}) Варвар\n" +
                              $"{CommandViking}) Викинг\n" +
                              $"{CommandSheldMan}) Щитовик");

                switch (Console.ReadKey(true).Key)
                {
                    case CommandKnight:
                        Console.ForegroundColor = defaultColor;
                        return new Knight();

                    case CommandSpearman:
                        Console.ForegroundColor = defaultColor;
                        return new Spearman();

                    case CommandBarbarian:
                        Console.ForegroundColor = defaultColor;
                        return new Barbarian();

                    case CommandViking:
                        Console.ForegroundColor = defaultColor;
                        return new Viking();

                    case CommandSheldMan:
                        Console.ForegroundColor = defaultColor;
                        return new SheldMan();
                }
            }

            return null;
        }

        static void ShowFghtersInfo(Dictionary<ConsoleColor, Fighter> fighters)
        {
            Dictionary<ConsoleColor, Fighter>.KeyCollection keys = fighters.Keys;
            ConsoleColor defaultColor = Console.ForegroundColor;

            foreach (var key in keys)
            {
                Console.ForegroundColor = key;
                fighters[key].ShowHealth();
            }

            Console.ForegroundColor = defaultColor;
            Console.WriteLine();
        }

        static void FightStage(Dictionary<ConsoleColor, Fighter> fighters, ConsoleColor attacking, ConsoleColor attacked)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.Clear();
            ShowFghtersInfo(fighters);
            Console.ForegroundColor = attacking;
            fighters[attacking].Attack(fighters[attacked]);
            Console.ForegroundColor = defaultColor;
            Console.ReadKey();
        }
    }

    abstract class Fighter
    {
        private double _armor;

        protected Fighter(int health, double armor, int attackDamage)
        {
            Health = health;
            Armor = armor;
            AttackDamage = attackDamage;
        }

        public int Health { get; private set; }

        public double Armor
        {
            get
            {
                return _armor;
            }
            private set
            {
                _armor = Math.Clamp(value, 0, 1);
            }
        }

        public int AttackDamage { get; protected set; }

        public virtual void Attack(Fighter target)
        {
            target.TakeDamage(AttackDamage, out int damage);
        }

        public virtual void TakeDamage(int damage, out int finalDamage, bool isIgnoredArmor = false)
        {
            if (isIgnoredArmor)
            {
                finalDamage = damage;
                Health -= finalDamage;
            }
            else
            {
                finalDamage = (int)(damage - (damage * Armor));
                Health -= finalDamage;
            }
        }

        protected void Heal(int value)
        {
            if (value > 0)
            {
                Health += value;
            }
        }

        public abstract void ShowHealth();

        public abstract void WriteWinWords();
    }

    class Knight : Fighter
    {
        private bool _isStrongAttack;
        private double _strongMultiplier;

        public Knight() : base(100, 0.8, 40)
        {
            _strongMultiplier = 1.8;
        }

        public override void Attack(Fighter target)
        {
            Random random = new Random();
            _isStrongAttack = Convert.ToBoolean(random.Next(0, 2));

            if (_isStrongAttack)
            {
                Console.WriteLine("Рыцарь атакует противника сильной атакой");
                target.TakeDamage((int)(AttackDamage * _strongMultiplier), out int damage);
            }
            else
            {
                Console.WriteLine("Рыцарь атакует противника");
                base.Attack(target);
            }
        }

        public override void TakeDamage(int damage, out int finalDamage, bool isIgnoredArmor = false)
        {
            base.TakeDamage(damage, out finalDamage, isIgnoredArmor);
            Console.WriteLine($"Рыцарь получил урон в размере {finalDamage}");
        }

        public override void ShowHealth()
        {
            Console.WriteLine($"Здоровье рыцаря: {Health}");
        }

        public override void WriteWinWords()
        {
            Console.Write("Рыцарь победил");
        }
    }

    class Spearman : Fighter
    {
        public Spearman() : base(100, 0.3, 35)
        {

        }

        public override void Attack(Fighter target)
        {
            Console.WriteLine("Копейщик атакует противника");
            target.TakeDamage(AttackDamage, out int damage, true);
        }

        public override void TakeDamage(int damage, out int finalDamage, bool isIgnoredArmor = false)
        {
            base.TakeDamage(damage, out finalDamage, isIgnoredArmor);
            Console.WriteLine($"Копейщик получил урон в размере {finalDamage}");
        }

        public override void ShowHealth()
        {
            Console.WriteLine($"Здоровье копейщика: {Health}");
        }

        public override void WriteWinWords()
        {
            Console.Write("Копейщик победил");
        }
    }

    class Barbarian : Fighter
    {
        private double _bufMultipluer = 0.5;

        public Barbarian() : base(100, 0.2, 50)
        {

        }

        public override void Attack(Fighter target)
        {
            Console.WriteLine("Варвар атакует противника");
            target.TakeDamage(AttackDamage, out int damage);
        }

        public override void TakeDamage(int damage, out int finalDamage, bool isIgnoredArmor = false)
        {
            base.TakeDamage(damage, out finalDamage, isIgnoredArmor);
            AttackDamage += (int)(finalDamage * _bufMultipluer);
            Console.WriteLine($"Варвар получил урон в размере {finalDamage}, и увеличил урон");
        }

        public override void ShowHealth()
        {
            Console.WriteLine($"Здоровье варвара: {Health}");
        }

        public override void WriteWinWords()
        {
            Console.Write("Варвар победил");
        }
    }

    class Viking : Fighter
    {
        private double _healMultipyer = 0.8;

        public Viking() : base(100, 0.4, 60)
        {

        }

        public override void Attack(Fighter target)
        {
            Console.WriteLine("Викинг атакует противника и лечит себя уроном");
            target.TakeDamage(AttackDamage, out int damage);
            Heal((int)(damage * _healMultipyer));
        }

        public override void TakeDamage(int damage, out int finalDamage, bool isIgnoredArmor = false)
        {
            base.TakeDamage(damage, out finalDamage, isIgnoredArmor);
            Console.WriteLine($"Викинг получил урон в размере {finalDamage}");
        }

        public override void ShowHealth()
        {
            Console.WriteLine($"Здоровье викинга: {Health}");
        }

        public override void WriteWinWords()
        {
            Console.Write("Викинг победил");
        }
    }

    class SheldMan : Fighter
    {
        private bool _isDefending;

        public SheldMan() : base(100, 0.6, 40)
        {

        }

        public override void Attack(Fighter target)
        {
            Console.WriteLine("Щитовик атакует противника ");
            target.TakeDamage(AttackDamage, out int damage);
        }

        public override void TakeDamage(int damage, out int finalDamage, bool isIgnoredArmor = false)
        {
            Random random = new Random();
            _isDefending = Convert.ToBoolean(random.Next(0, 2));

            if (_isDefending)
            {
                finalDamage = 0;
                Console.WriteLine($"Щитовик заблокировал атаку");
            }
            else
            {
                base.TakeDamage(damage, out finalDamage, isIgnoredArmor);
                Console.WriteLine($"Щитовик получил урон в размере {finalDamage}");

            }
        }

        public override void ShowHealth()
        {
            Console.WriteLine($"Здоровье щитовика: {Health}");
        }

        public override void WriteWinWords()
        {
            Console.Write("Щитовик победил");
        }
    }
}