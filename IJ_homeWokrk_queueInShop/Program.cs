namespace IJ_homeWokrk_queueInShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minNumber = 10;
            int maxNumber = 1000;
            int minQueueLength = 3;
            int maxQueueLength = 10;
            int shopCashe = 0;
            Queue<int> customers = new Queue<int>();

            GenerateQueue(customers ,random.Next(minQueueLength, maxQueueLength + 1), minNumber, maxNumber);

            while (customers.Count > 0)
            {
                Console.Clear();
                WriteShopStatus(shopCashe, customers.Count);
                ServeCustomer(customers, ref shopCashe);
                Console.ReadKey(true);
            }

            Console.Clear();
            WriteShopStatus(shopCashe, customers.Count);
            Console.WriteLine("Все клиенты обслужены.");
            Console.ReadKey(true);
        }

        static void GenerateQueue(Queue<int> queueColetion, int length, int minNumber, int maxNumber)
        {
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                queueColetion.Enqueue(random.Next(minNumber, maxNumber + 1));
            }
        }

        static void ServeCustomer(Queue<int> customersQueue, ref int shopCashe)
        {
            shopCashe += customersQueue.Peek();
            Console.WriteLine($"Нынешний клиент совершил покупку в размере: {customersQueue.Peek()}");
            customersQueue.Dequeue();
        }

        static void WriteShopStatus(int shopCashe, int customersCount)
        {
            Console.WriteLine($"Деньги магазина: {shopCashe}");
            Console.WriteLine($"Клиентов в очереди: {customersCount}");
        }
    }
}