﻿namespace IJ_homeWork_shop_2
{
    internal class Program
    {
        static void Main()
        {
            Product apple = new Product("apple", 69);
            Product milk = new Product("milk", 49);
            Product bread = new Product("bread", 45);
            Product crackers = new Product("crackers", 39);
            Product banana = new Product("banana", 59);

            Dictionary<Product, int> products = new Dictionary<Product, int>()
            {
                { apple, 100},
                { milk, 100},
                { bread, 100},
                { crackers, 100},
                { banana, 100}
            };

            Superstore superstore = new Superstore(products);

            superstore.Work();
        }
    }

    class Superstore
    {
        public Superstore(Dictionary<Product, int> products)
        {
            Customers = new Queue<Customer>();
            Products = products;
            int customersCount = UserUtils.GetRandomNumber(5, 10);

            for (int i = 0; i < customersCount; i++)
            {
                Customers.Enqueue(GenerateCustomer());
            }
        }

        public Queue<Customer> Customers { get; private set; }

        public Dictionary<Product, int> Products { get; private set; }

        public void Work()
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                ShowInfo();
                Console.WriteLine();

                if (Customers.Count > 0)
                {
                    Customer currentCustomer = Customers.Peek();
                    Console.WriteLine("К вам пришел клиент со следующими продуктами:");
                    currentCustomer.ShowProducts();
                    int finalPrice = GetPriceSum(currentCustomer.GiveProducts());
                    Console.WriteLine($"Клиент должен заплатить {finalPrice}");

                    if (currentCustomer.Money < finalPrice)
                    {
                        ReturnProduct(out Product returnedProduct);
                        Console.WriteLine($"но не может. По этому он возвращает {returnedProduct.Name}");
                        Console.ReadKey();
                        continue;
                    }

                    currentCustomer.ToPay(finalPrice);
                    Console.WriteLine("И успешно оплачивает свою цену.");
                    Customers.Dequeue();
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("Клиентов не осталось. Программа завершится после нажатия любой клавишы.");
                Console.ReadKey();
                isWorking = false;
            }
        }

        private void ShowInfo()
        {
            ShowProducts();
            Console.WriteLine();
            ShowCustomersCount();
        }

        private void ShowProducts()
        {
            Dictionary<Product, int>.KeyCollection keys = Products.Keys;

            Console.WriteLine("Продукты в наличии:");

            foreach (var product in keys)
            {
                Console.WriteLine($"Название: {product.Name} стоимость: {product.Price} количество: {Products[product]}");
            }
        }

        private void ShowCustomersCount()
        {
            Console.WriteLine($"Количество клиентов: {Customers.Count}");
        }

        private void ReturnProduct(out Product returnedProduct)
        {
            returnedProduct = Customers.Peek().GiveRandomProduct();

            if (Products.ContainsKey(returnedProduct))
            {
                Products[returnedProduct]++;
                return;
            }

            Products[returnedProduct] = 1;
        }

        private Product GiveProduct(Product product)
        {
            if (Products.ContainsKey(product))
            {
                if (Products[product] > 0)
                {
                    Products[product]--;
                    return product;
                }
            }

            return null;
        }

        private Customer GenerateCustomer()
        {
            Dictionary<Product, int>.KeyCollection keys = Products.Keys;
            List<Product> customerProducts = new List<Product>();

            foreach (var product in keys)
            {
                int productCount = UserUtils.GetRandomNumber(6);

                if (productCount > Products[product])
                {
                    productCount = Products[product];
                }

                for (int i = 0; i < productCount; i++)
                {
                    customerProducts.Add(GiveProduct(product));
                }
            }

            Customer customer = new Customer(customerProducts);
            return customer;
        }

        private int GetPriceSum(List<Product> products)
        {
            int priceSum = 0;

            for (int i = 0; i < products.Count; i++)
            {
                priceSum += products[i].Price;
            }

            return priceSum;
        }
    }

    class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }

        public int Price { get; private set; }
    }

    class Customer
    {
        private List<Product> _products;

        public Customer(List<Product> products)
        {
            _products = products;
            Money = UserUtils.GetRandomNumber(100, 2000);
        }

        public int Money { get; private set; }

        public List<Product> GiveProducts()
        {
            return _products;
        }

        public Product GiveRandomProduct()
        {
            Product randomProduct = _products[UserUtils.GetRandomNumber(_products.Count)];
            _products.Remove(randomProduct);
            return randomProduct;
        }

        public void ShowProducts()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine($"Название: {_products[i].Name} стоимость: {_products[i].Price}");
            }
        }

        public void ToPay(int price)
        {
            if (Money >= price)
            {
                Money -= price;
            }
        }
    }

    class UserUtils
    {
        private static Random s_random = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            return s_random.Next(min, max);
        }

        public static int GetRandomNumber(int max)
        {
            return s_random.Next(max);
        }
    }
}