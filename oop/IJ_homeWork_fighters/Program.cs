namespace IJ_homeWork_fighters
{
    internal class Program
    {
        static void Main()
        {
            Fighter fighter1 = SetFighter(ConsoleColor.Blue);
            Fighter fighter2 = SetFighter(ConsoleColor.Red);

            while (fighter1.Health > 0 && fighter2.Health > 0)
            {
                FightStage(fighter1, fighter2);

                if (fighter1.Health > 0 && fighter2.Health > 0 == false)
                {
                    break;
                }

                FightStage(fighter2, fighter1);
            }

            Console.Clear();

            if (fighter1.Health > 0)
            {
                fighter1.WriteWinWords();
            }
            else
            {
                fighter2.WriteWinWords();
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
            bool isSelecting = true;  

            Console.ForegroundColor = color;

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
                        return new Knight(color);

                    case CommandSpearman:
                        Console.ForegroundColor = defaultColor;
                        return new Spearman(color);

                    case CommandBarbarian:
                        Console.ForegroundColor = defaultColor;
                        return new Barbarian(color);

                    case CommandViking:
                        Console.ForegroundColor = defaultColor;
                        return new Viking(color);

                    case CommandSheldMan:
                        Console.ForegroundColor = defaultColor;
                        return new SheldMan(color);
                }
            }

            return null;
        }

        static void ShowFghtersInfo(Fighter[] fighters) 
        {
            foreach (var fighter in fighters)
            {
                fighter.ShowHealth();
            }
            Console.WriteLine();
        }

        static void FightStage(Fighter attacking, Fighter attacked)
        {
            Console.Clear();
            ShowFghtersInfo(new Fighter[] { attacking, attacked });
            attacking.Attack(attacked);
            Console.ReadKey();
        }
    }

    abstract class Fighter
    {
        private double _armor;

        protected Fighter(int health, double armor, int attackDamage, ConsoleColor color)
        {
            Health = health;
            Armor = armor;
            AttackDamage = attackDamage;
            Color = color;
            Console.ForegroundColor = DefaultColor;
        }

        protected ConsoleColor Color { get; private set; }

        protected ConsoleColor DefaultColor { get; private set; }

        public int Health { get; private set; }

        public double Armor 
        {
            get
            {
                return _armor;
            }
            private set
            {
                if (value > 1)
                {
                    _armor = 1;
                }
                else if (value < 0)
                {
                    _armor = 0;
                }
                else
                {
                    _armor = value;
                }
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

        public Knight(ConsoleColor color) : base(100, 0.8, 40, color)
        {
            _strongMultiplier = 1.8;
        }

        public override void Attack(Fighter target)
        {
            Random random = new Random();
            _isStrongAttack = Convert.ToBoolean(random.Next(0,2));
            Console.ForegroundColor = Color;

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

            Console.ForegroundColor = DefaultColor;
        }

        public override void TakeDamage(int damage, out int finalDamage, bool isIgnoredArmor = false)
        {
            Console.ForegroundColor = Color;
            base.TakeDamage(damage, out finalDamage, isIgnoredArmor);
            Console.WriteLine($"Рыцарь получил урон в размере {finalDamage}");
            Console.ForegroundColor = DefaultColor;
        }

        public override void ShowHealth()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Здоровье рыцаря: {Health}");
            Console.ForegroundColor = DefaultColor;
        }

        public override void WriteWinWords()
        {
            Console.ForegroundColor = Color;
            Console.Write("Рыцарь победил");
            Console.ForegroundColor = DefaultColor;
        }
    }

    class Spearman : Fighter
    {
        public Spearman(ConsoleColor color) : base(100, 0.3, 35, color)
        {

        }

        public override void Attack(Fighter target)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("Копейщик атакует противника");
            target.TakeDamage(AttackDamage, out int damage, true);
            Console.ForegroundColor = DefaultColor;
        }

        public override void TakeDamage(int damage, out int finalDamage, bool isIgnoredArmor = false)
        {
            Console.ForegroundColor = Color;
            base.TakeDamage(damage, out finalDamage, isIgnoredArmor);
            Console.WriteLine($"Копейщик получил урон в размере {finalDamage}");
            Console.ForegroundColor = DefaultColor;
        }

        public override void ShowHealth()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Здоровье копейщика: {Health}");
            Console.ForegroundColor = DefaultColor;
        }

        public override void WriteWinWords()
        {
            Console.ForegroundColor = Color;
            Console.Write("Копейщик победил");
            Console.ForegroundColor = DefaultColor;
        }
    }

    class Barbarian : Fighter
    {
        private double _bufMultipluer = 0.5;

        public Barbarian(ConsoleColor color) : base(100, 0.2, 50, color)
        {

        }

        public override void Attack(Fighter target)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("Варвар атакует противника");
            target.TakeDamage(AttackDamage, out int damage);
            Console.ForegroundColor = DefaultColor;
        }

        public override void TakeDamage(int damage, out int finalDamage, bool isIgnoredArmor = false)
        {
            Console.ForegroundColor = Color;
            base.TakeDamage(damage, out finalDamage, isIgnoredArmor);
            AttackDamage += (int)(finalDamage * _bufMultipluer);
            Console.WriteLine($"Варвар получил урон в размере {finalDamage}, и увеличил урон");
            Console.ForegroundColor = DefaultColor;
        }

        public override void ShowHealth()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Здоровье варвара: {Health}");
            Console.ForegroundColor = DefaultColor;
        }

        public override void WriteWinWords()
        {
            Console.ForegroundColor = Color;
            Console.Write("Варвар победил");
            Console.ForegroundColor = DefaultColor;
        }
    }

    class Viking : Fighter
    {
        private double _healMultipyer = 0.8;

        public Viking(ConsoleColor color) : base(100, 0.4, 60, color)
        {
            
        }

        public override void Attack(Fighter target)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("Викинг атакует противника и лечит себя уроном");
            target.TakeDamage(AttackDamage, out int damage);
            Heal((int)(damage * _healMultipyer));
            Console.ForegroundColor = DefaultColor;
        }

        public override void TakeDamage(int damage, out int finalDamage, bool isIgnoredArmor = false)
        {
            Console.ForegroundColor = Color;
            base.TakeDamage(damage, out finalDamage, isIgnoredArmor);
            Console.WriteLine($"Викинг получил урон в размере {finalDamage}");
            Console.ForegroundColor = DefaultColor;
        }

        public override void ShowHealth()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Здоровье викинга: {Health}");
            Console.ForegroundColor = DefaultColor;
        }

        public override void WriteWinWords()
        {
            Console.ForegroundColor = Color;
            Console.Write("Викинг победил");
            Console.ForegroundColor = DefaultColor;
        }
    }

    class SheldMan : Fighter
    {
        private bool _isDefending;

        public SheldMan(ConsoleColor color) : base(100, 0.6, 40, color)
        {

        }

        public override void Attack(Fighter target)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("Щитовик атакует противника ");
            target.TakeDamage(AttackDamage, out int damage);
            Console.ForegroundColor = DefaultColor;
        }

        public override void TakeDamage(int damage, out int finalDamage, bool isIgnoredArmor = false)
        {
            Console.ForegroundColor = Color;
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

            Console.ForegroundColor = DefaultColor;
        }

        public override void ShowHealth()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Здоровье щитовика: {Health}");
            Console.ForegroundColor = DefaultColor;
        }

        public override void WriteWinWords()
        {
            Console.ForegroundColor = Color;
            Console.Write("Щитовик победил");
            Console.ForegroundColor = DefaultColor;
        }
    }
}