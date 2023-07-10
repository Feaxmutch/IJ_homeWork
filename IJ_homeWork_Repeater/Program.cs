namespace IJ_homeWork_Repeater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text;
            int numberOfRepetitions;
            Console.Title = "повторюшка";
            Console.WriteLine("Здравствуйте. Я могу повторить введённый вами текст столько раз, сколько захотите.");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Введите текст, который хотите повторить: "); 
            text = Console.ReadLine();
            Console.Write("Введите количество повторений: "); 
            numberOfRepetitions = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            for (int i = 0; i < numberOfRepetitions; i++)
            {
                Console.WriteLine(text);
            }

            Console.ReadKey();
        }
    }
}