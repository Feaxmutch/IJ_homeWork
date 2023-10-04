namespace IJ_homeWork_zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();
    }

    class Aviary 
    {
        private List<Animal> _animals = new List<Animal>();

        public List<Animal> Animals { get => new List<Animal>(_animals); }
    }

    abstract class Animal
    {
        private string _name;
        private Gender _gender;

        public Animal(string name, Gender gender)
        {
            _name = name;
            _gender = gender;
        }

        public string Name { get => _name; }

        public Gender Gender { get => _gender; }

        public abstract void MakeSound();
    } 

    class Monkey : Animal
    {
        public Monkey(Gender gender) : base("Обезьяна", gender){}

        public override void MakeSound()
        {
            Console.Write("");
        }
    }

    enum Gender
    {
        Male,
        Female
    }
}