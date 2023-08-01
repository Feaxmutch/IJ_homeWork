namespace IJ_homeWokrk_queueInShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            
            int shopCashe = 0;
            Queue<int> customers = new Queue<int>();

            GenerateQueue(customers);
            shopCashe = ServeCustomers(customers, shopCashe);
            Console.Clear();
            WriteShopStatus(shopCashe, customers.Count);
            Console.WriteLine("Все клиенты обслужены.");
            Console.ReadKey(true);
        }

        static void GenerateQueue(Queue<int> queueColetion)
        {
            Random random = new Random();
            int minNumber = 10;
            int maxNumber = 1000;
            int minRandomLength = 3;
            int maxRandomLength = 10;
            int length = random.Next(minRandomLength, maxRandomLength + 1);

            for (int i = 0; i < length; i++)
            {
                queueColetion.Enqueue(random.Next(minNumber, maxNumber + 1));
            }
        }

        static int ServeCustomers(Queue<int> customersQueue, int shopCashe)
        {
            while (customersQueue.Count > 0)
            {
                Console.Clear();
                WriteShopStatus(shopCashe, customersQueue.Count);
                Console.WriteLine($"Нынешний клиент совершил покупку в размере: {customersQueue.Peek()}");
                shopCashe += customersQueue.Dequeue();
                Console.ReadKey(true);
            }

            return shopCashe;
        }

        static void WriteShopStatus(int shopCashe, int customersCount)
        {
            Console.WriteLine($"Деньги магазина: {shopCashe}");
            Console.WriteLine($"Клиентов в очереди: {customersCount}");
        }
    }
}