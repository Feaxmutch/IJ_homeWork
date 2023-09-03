namespace IJ_homeWork_fighters
{
    internal class Program
    {
        static void Main()
        {
            
        }
    }

    abstract class Fighter
    {
        private double _armor;

        protected Fighter(int health, double armor, int attackDistance, int attackDamage)
        {
            Health = health;
            Armor = armor;
            AttackDistance = attackDistance;
            AttackDamage = attackDamage;
            DefendPower = 2;
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
                if (value > 1)
                {
                    _armor = 1;
                }
                else if (value < 0)
                {
                    _armor = 0;
                }
            } 
        }

        public int AttackDistance { get; private set; }

        public int AttackDamage { get; private set; }

        protected bool IsDefending { get; private set; }

        protected int DefendPower { get; private set; }

        public virtual void Attack(Fighter target)
        {
            target.TakeDamage(AttackDamage);
        }

        public void TakeDamage(int damage, bool isIgnoredArmor = false, bool isIgnoredDefend = false)
        {
            if (isIgnoredArmor)
            {
                if (isIgnoredDefend)
                {
                    Health -= damage;
                }
                else
                {
                    if (IsDefending)
                    {
                        Health -= damage / DefendPower;
                        IsDefending = false;
                    }
                    else
                    {
                        Health -= damage;
                    }
                }
            }
            else
            {
                if (isIgnoredDefend)
                {
                    Health -= (int)(damage - damage * Armor);
                }
                else
                {
                    if (IsDefending)
                    {
                        Health -= (int)((damage - damage * Armor) / DefendPower);
                        IsDefending = false;
                    }
                    else
                    {
                        Health -= (int)(damage - damage * Armor);
                    }
                }
            }
        }

        public void Defend()
        {
            IsDefending = true;
        }
    }

    class Knight : Fighter
    {
        public Knight() : base(100, 0.8, 3, 40)
        {
            StrongMultiplier = 1.8;
        }

        public bool IsStrongAttack { get; private set; }

        public double StrongMultiplier { get; private set; }

        public override void Attack(Fighter target)
        {
            if (IsStrongAttack)
            {
                target.TakeDamage((int)(AttackDamage * StrongMultiplier));
            }
            else
            {
                target.TakeDamage(AttackDamage);
            }
        }

        public void PrepareStrongAttack()
        {
            IsStrongAttack = true;
        }
    }

    class Spearman : Fighter
    {
        public Spearman() : base(100, 0.3, 5, 35)
        {

        }

        public override void Attack(Fighter target)
        {
            target.TakeDamage(AttackDamage, true);
        }
    }

    
}