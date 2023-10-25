﻿namespace IJ_HomeWork_CarService
{
    internal class Program
    {
        static void Main()
        {
            int carsCount = 5;
            int detalesCount = 20;
            int penality = 300;
            int workPrice = 50;
            int startMoney = 500;
            double brokenChanse = 25;

            List<Detail> detales = new List<Detail>();
            List<Car> cars = new List<Car>();

            detales.Add(new Detail("Двигатель", 100, false));
            detales.Add(new Detail("Колеса", 70, false));
            detales.Add(new Detail("Корпус", 90, false));
            detales.Add(new Detail("Коробка передач", 80, false));

            Factory factory = new Factory(detales);

            for (int i = 0; i < carsCount; i++)
            {
                cars.Add(new Car(factory.MakeDetales()));
            }

            foreach (var car in cars)
            {
                car.GenerateDamage(brokenChanse);
            }

            CarService carService = new CarService(cars, factory.MakeDetales(), detalesCount, startMoney, penality, workPrice);
            carService.Work();
        }
    }

    static class CustomRandom
    {
        private static Random s_random = new();
        private static double s_maxPrecent = 100;

        public static bool GetBool(double trueChanse)
        {
            int pointsInPrecent = 100;
            trueChanse = Math.Clamp(trueChanse, 0, s_maxPrecent);
            int randomNumber = s_random.Next(0, (int)(pointsInPrecent * s_maxPrecent));
            return randomNumber <= pointsInPrecent * trueChanse;
        }

        public static int GetNumber(int minNumber, int maxNumber)
        {
            return s_random.Next(minNumber, maxNumber);
        }
    }

    class CarService
    {
        private int _money;
        private int _detalesPrice;
        private Queue<Car> _cars;
        private Dictionary<Detail, int> _detales = new Dictionary<Detail, int>();

        public CarService(List<Car> cars, List<Detail> detales, int detalesCount, int startMoney, int penalty, int workPrice)
        {
            _cars = new Queue<Car>(cars);

            for (int i = 0; i < detales.Count; i++)
            {
                _detales[detales[i]] = detalesCount;
            }

            Penality = Math.Abs(penalty);
            WorkPrice = Math.Abs(workPrice);
            _money = Math.Abs(startMoney);
        }

        private int Penality { get; }

        private int WorkPrice { get; }

        public void Work()
        {
            while (_cars.Count > 0)
            {
                Console.Clear();
                Car car = _cars.Dequeue();
                ServeCar(car);

                if (_money < 0)
                {
                    Console.WriteLine("Автосервис абанкротился");
                    Console.ReadKey();
                }
            }
        }

        private void ServeCar(Car car)
        {
            _detalesPrice = 0;

            while (car.IsFixed() == false)
            {
                List<Detail> selectedDetales = SelectDetales(car);

                if (selectedDetales.Count > 0)
                {
                    foreach (var selsectedDetale in selectedDetales)
                    {
                        Detail newDetale = GetDetaleByName(selsectedDetale.Name);

                        if (newDetale != null)
                        {
                            car.SwichDetale(newDetale);
                            _detalesPrice += newDetale.Price;
                        }
                        else
                        {
                            Console.WriteLine($"На складе нет детали {selsectedDetale.Name}");
                            Console.ReadKey();
                        }
                    }

                    if (car.IsFixed())
                    {
                        Console.WriteLine("Машина востановленна");
                        _money += WorkPrice + _detalesPrice;
                        Console.WriteLine($"Вы получили Оплату за работу в размере {WorkPrice}, и оплату верно заменённых деталей в размере {_detalesPrice}");
                        Console.ReadKey();

                    }
                }
                else
                {
                    _money -= Penality;
                    Console.WriteLine($"Вы отказали клиенту и выплатили штраф в размере {Penality}");
                    Console.ReadKey();
                    break;
                }
            }

            if (car.MaterialDamage > 0)
            {
                _money -= car.MaterialDamage;
                Console.WriteLine($"Вы выплатили материальный усщерб в размере {car.MaterialDamage} за неверно заменённую(ные) деталь(и)");
                Console.ReadKey();
            }
        }

        private List<Detail> SelectDetales(Car car)
        {
            bool isSelecting = true;
            List<int> detaleNumbers = new List<int>();
            List<Detail> selectedDetales = new List<Detail>();

            while (isSelecting)
            {
                Console.Clear();
                ShowInfo();
                Console.WriteLine("Детали машины клиента:");
                car.ShowDetales();
                Console.WriteLine("\n Выбранные детали:");

                for (int i = 0; i < detaleNumbers.Count; i++)
                {
                    Console.Write(detaleNumbers[i]);

                    if (i < detaleNumbers.Count - 1)
                    {
                        Console.Write(", ");
                    }
                }

                Console.WriteLine("\n Выберите номер детали, которую хотите поменять, " +
                                 $"\n или введите пустое поле, если выбрали все необходимые детали." +
                                 $"\n Не выбрав ни одной детали, вы отказываете клиенту.");
                string detaleNumber = Console.ReadLine();

                if (detaleNumber == string.Empty)
                {
                    isSelecting = false;
                }
                else
                {
                    if (int.TryParse(detaleNumber, out int number))
                    {
                        if (number > 0 && number <= car.GetDetails().Count)
                        {
                            if (detaleNumbers.Contains(number) == false)
                            {
                                detaleNumbers.Add(number);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Номера детали {number} не существует");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\"{detaleNumber}\" не является числом.");
                        Console.ReadKey();
                    }
                }
            }

            for (int i = 0; i < detaleNumbers.Count; i++)
            {
                selectedDetales.Add(car.GetDetails()[detaleNumbers[i] - 1]);
            }

            return selectedDetales;
        }

        private Detail GetDetaleByName(string detaleName)
        {
            var detales = _detales.Keys;

            foreach (var detale in detales)
            {
                if (detale.Name == detaleName)
                {
                    if (_detales[detale] > 0)
                    {
                        _detales[detale]--;
                        return new Detail(detale.Name, detale.Price, detale.IsBroken);
                    }
                }
            }

            return null;
        }

        private void ShowInfo()
        {
            Console.WriteLine($"Деньги автосервиса: {_money}");
            Console.WriteLine($"Клиенты в очереди: {_cars.Count}\n");
            Console.WriteLine("Детали на складе:");

            var detales = _detales.Keys;

            foreach (var detale in detales)
            {
                Console.WriteLine($"{detale.Name} {_detales[detale]}");
            }

            Console.WriteLine();
        }
    }

    class Factory
    {
        private List<Detail> _detales;

        public Factory(List<Detail> detales)
        {
            if (detales != null && detales.Count > 0)
            {
                _detales = new List<Detail>(detales);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public List<Detail> MakeDetales()
        {
            List<Detail> newList = new List<Detail>();

            foreach (var detale in _detales)
            {
                newList.Add(new Detail(detale.Name, detale.Price, detale.IsBroken));
            }

            return newList;
        }
    }

    class Car
    {
        private List<Detail> _details;

        public Car(List<Detail> detales)
        {
            _details = new List<Detail>(detales);
        }

        public int MaterialDamage { get; private set; }

        public List<Detail> GetDetails()
        {
            List<Detail> newList = new List<Detail>();

            foreach (var detale in _details)
            {
                newList.Add(new Detail(detale.Name, detale.Price, detale.IsBroken));
            }

            return newList;
        }

        public bool IsFixed()
        {
            foreach (var detale in _details)
            {
                if (detale.IsBroken)
                {
                    return false;
                }
            }

            return true;
        }

        public void GenerateDamage(double BrokenChanse)
        {
            bool isBrokened = false;

            foreach (var detale in _details)
            {
                if (CustomRandom.GetBool(BrokenChanse))
                {
                    detale.TakeDamage();
                    isBrokened = true;
                }
            }

            if (isBrokened == false)
            {
                _details[CustomRandom.GetNumber(0, _details.Count)].TakeDamage();
            }
        }

        public void ShowDetales()
        {
            for (int i = 0; i < _details.Count; i++)
            {
                Console.Write($"{i + 1} ");
                _details[i].ShowInfo();
            }
        }

        public void SwichDetale(Detail newDetale)
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].Name == newDetale.Name)
                {
                    if (_details[i].IsBroken == false)
                    {
                        MaterialDamage = _details[i].Price;
                    }

                    _details[i] = newDetale;
                    break;
                }
            }
        }
    }

    class Detail
    {
        public Detail(string name, int price, bool isBroken)
        {
            Name = name;
            Price = price;
            IsBroken = isBroken;
        }

        public bool IsBroken { get; private set; }

        public string Name { get; private set; }

        public int Price { get; private set; }

        public void TakeDamage()
        {
            IsBroken = true;
        }

        public void ShowInfo()
        {
            Console.Write($"Название: {Name} ");
            Console.Write($"Сломана: ");

            if (IsBroken)
            {
                Console.WriteLine("Да");
            }
            else
            {
                Console.WriteLine("Нет");
            }
        }
    }
}