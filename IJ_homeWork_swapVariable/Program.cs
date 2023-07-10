namespace IJ_homeWork_swapVariable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Чобитько";
            string lastName = "Илья";     // Тот, что Муромец
            Console.WriteLine($"{firstName} {lastName}");
            string nameBufer = firstName;
            firstName = lastName;
            lastName = nameBufer;
            Console.WriteLine($"{firstName} {lastName}");
            Console.ReadKey();
        }
    }
}