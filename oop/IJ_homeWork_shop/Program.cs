namespace IJ_homeWork_shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string MenuPlayer = "1";
            const string MenuSeller = "2";
            const string CommandExit = "exit";

            Item sword = new Item("Sword", 300);
            Item shield = new Item("Shield", 360);
            Item armor = new Item("Armor", 230);
            Item healingPotion = new Item("Healing potion", 45);
            Seller seller = new Seller(new List<Item>() { sword, shield, armor, healingPotion }, 5);
            Player player = new Player();
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine($"{MenuPlayer}) Отобразить инвентарь." +
                              $"\n{MenuSeller}) Обратится к торговцу." +
                              $"\n{CommandExit}) Закрыть программу.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case MenuPlayer:
                        player.ShowInfo();
                        break;

                    case MenuSeller:
                        seller.Serve(player);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }
    }

    class Seller
    {
        private List<Item> _products = new List<Item>();

        public Seller(List<Item> products, int count)
        {
            foreach (Item product in products)
            {
                for (int i = 0; i < count; i++)
                {
                    _products.Add(product);
                }
            }
        }

        public void Serve(Player player)
        {
            const string MenuProducts = "1";
            const string MenuBuy = "2";
            const string CommandExit = "exit";

            bool isServing = true;

            while (isServing)
            {
                Console.Clear();
                Console.WriteLine($"{MenuProducts}) Показать все предметы." +
                                  $"\n{MenuBuy}) Купить предмет." +
                                  $"\n{CommandExit}) Завершить торговлю.");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case MenuProducts:
                        ShowProducts();
                        break;

                    case MenuBuy:
                        Buy(player);
                        break;

                    case CommandExit:
                        isServing = false;
                        break;
                }
            }
        }

        private void ShowProducts()
        {
            Console.Clear();

            for (int i = 0; i < _products.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                _products[i].ShowInfo();
            }

            Console.ReadKey();
        }

        private Item TakeProduct(Item product, int money)
        {
            if (money >= product.Price)
            {
                return product;
            }

            return null;
        }

        private Item GetProduct(int productNumber)
        {
            return _products[productNumber - 1];
        }

        private void Buy(Player player)
        {
            Console.Clear();
            ShowProducts();

            Console.WriteLine("Введите номер предмета, который хотите купить:");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int number))
            {
                Item itemForBuy = GetProduct(number);

                if (player.Money >= itemForBuy.Price)
                {
                    player.GetItem(TakeProduct(itemForBuy, player.TakeMoney(itemForBuy.Price)));
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Номер предмета должен быть числом.");
                Console.ReadKey();
            }
        } 
    }

    class Item
    {
        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }

        public int Price { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} цена: {Price}");
        }
    }

    class Player
    {
        private List<Item> _items = new List<Item>();

        public Player()
        {
            Money = 10000;
        }

        public int Money { get; private set; }

        public int TakeMoney(int price)
        {
            if (price <= Money)
            {
                return Money -= price;
            }

            return 0;
        }

        public void GetItem(Item item)
        {
            if (item != null)
            {
                _items.Add(item);
            }
        }

        public void ShowInfo()
        {
            Console.Clear();
            ShowMoney();
            Console.WriteLine();
            ShowItems();
            Console.ReadKey();
        }

        private void ShowItems()
        {
            foreach (var item in _items)
            {
                item.ShowInfo();
            }
        }

        private void ShowMoney()
        {
            Console.WriteLine($"Монеты: {Money}");
        }
    }
}