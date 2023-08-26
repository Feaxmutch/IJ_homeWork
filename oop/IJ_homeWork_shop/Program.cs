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
            Dictionary<Item, int> sellerItems = new Dictionary<Item, int>() { { sword, 5 }, { shield, 4 }, { armor, 4 }, { healingPotion, 8 } };
            Seller seller = new Seller(sellerItems);
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

    class Character
    {
        protected List<Item> Items = new List<Item>();

        public int Money { get; protected set; }

        public void ShowInfo()
        {
            Console.Clear();
            ShowMoney();
            Console.WriteLine();
            ShowItems();
            Console.ReadKey();
        }

        protected virtual void ShowItems()
        {
            foreach (var item in Items)
            {
                item.ShowInfo();
            }
        }

        private void ShowMoney()
        {
            Console.WriteLine($"Монеты: {Money}");
        }
    }

    class Seller: Character
    {
        public Seller(Dictionary<Item, int> items)
        {
            Dictionary<Item, int>.KeyCollection keys = items.Keys;

            foreach (var item in keys)
            {
                for (int i = 0; i < items[item]; i++)
                {
                    Items.Add(item);
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
                        ShowItems();
                        break;

                    case MenuBuy:
                        Sell(player);
                        break;

                    case CommandExit:
                        isServing = false;
                        break;
                }
            }
        }

        protected override void ShowItems()
        {
            Console.Clear();

            for (int i = 0; i < Items.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                Items[i].ShowInfo();
            }

            Console.ReadKey();
        }

        private Item GetItemByNumber(int productNumber)
        {
            if (productNumber > 0 && productNumber <= Items.Count)
            {
                return Items[productNumber - 1];
            }
            else
            {
                return null;
            }
        }

        private void Sell(Player player)
        {
            Console.Clear();
            ShowItems();

            Console.WriteLine("Введите номер предмета, который хотите купить:");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int number))
            {
                Item itemForBuy = GetItemByNumber(number);

                if (itemForBuy == null)
                {
                    Console.WriteLine($"Ошибка. предмета под номером {number} не существует.");
                    Console.ReadKey();
                    return;
                }

                if (player.Money >= itemForBuy.Price)
                {
                    player.TakeMoney(itemForBuy.Price);
                    player.GetItem(itemForBuy);
                    Items.Remove(itemForBuy);
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

    class Player: Character
    {
        public Player()
        {
            Money = 10000;
        }

        public int TakeMoney(int money)
        {
            if (money <= Money)
            {
                return Money -= money;
            }

            return 0;
        }

        public void GetItem(Item item)
        {
            if (item != null)
            {
                Items.Add(item);
            }
        }
    }
}