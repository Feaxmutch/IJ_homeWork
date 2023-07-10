namespace IJ_homeWork_sicretMеssage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sicretMessage = "Медвежьи лапки";
            string password = "ponchik228";
            uint attempts = 3;

            for (uint i = attempts; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine("Введите пароль, для доступа к секретному сообщению.");
                Console.WriteLine($"Количество попыток: {i}");
                
                if (Console.ReadLine() == password)
                {
                    Console.WriteLine(sicretMessage);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный пароль.");
                    Console.ReadKey();
                }
            }
        }
    }
}