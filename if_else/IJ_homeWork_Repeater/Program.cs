namespace IJ_homeWork_Repeater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте. Я могу повторить введённый вами текст столько раз, сколько захотите.");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Введите текст, который хотите повторить: ");
            string text = Console.ReadLine();
            Console.Write("Введите количество повторений: "); 
            int repetitionsCount = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            for (int i = 0; i < repetitionsCount; i++)
            {
                Console.WriteLine(text);
            }

            Console.ReadKey();
        }
    }
}