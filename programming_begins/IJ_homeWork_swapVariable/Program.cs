namespace IJ_homeWork_swapVariable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Чобитько";
            string lastName = "Илья";
            Console.WriteLine($"{firstName} {lastName}");
            string nameBuffer = firstName;
            firstName = lastName;
            lastName = nameBuffer;
            Console.WriteLine($"{firstName} {lastName}");
            Console.ReadKey();
        }
    }
}