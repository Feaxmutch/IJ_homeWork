namespace IJ_HomeWork_CarService
{
    internal class Program
    {
        static void Main()
        {
            int carsCount = 5;
            int detailsCount = 20;
            int penality = 300;
            int workPrice = 50;
            int startMoney = 500;
            double brokenChanse = 25;

            List<Detail> details = new List<Detail>();
            List<Car> cars = new List<Car>();

            details.Add(new Detail("Двигатель", 100, false));
            details.Add(new Detail("Колеса", 70, false));
            details.Add(new Detail("Корпус", 90, false));
            details.Add(new Detail("Коробка передач", 80, false));

            Factory factory = new Factory(details);

            for (int i = 0; i < carsCount; i++)
            {
                cars.Add(new Car(factory.MakeDetails()));
            }

            foreach (var car in cars)
            {
                car.GenerateDamage(brokenChanse);
            }

            CarService carService = new CarService(cars, factory.MakeDetails(), detailsCount, startMoney, penality, workPrice);
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
        private int _detailsPrice;
        private Queue<Car> _cars;
        private Dictionary<Detail, int> _details = new Dictionary<Detail, int>();

        public CarService(List<Car> cars, List<Detail> details, int detailsCount, int startMoney, int penalty, int workPrice)
        {
            _cars = new Queue<Car>(cars);

            for (int i = 0; i < details.Count; i++)
            {
                _details[details[i]] = detailsCount;
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
            _detailsPrice = 0;

            while (car.IsFixed() == false)
            {
                List<Detail> selectedDetails = SelectDetails(car);

                if (selectedDetails.Count > 0)
                {
                    foreach (var selsectedDetail in selectedDetails)
                    {
                        Detail newDetail = GetDetailByName(selsectedDetail.Name);

                        if (newDetail != null)
                        {
                            car.SwichDetail(newDetail);
                            _detailsPrice += newDetail.Price;
                        }
                        else
                        {
                            Console.WriteLine($"На складе нет детали {selsectedDetail.Name}");
                            Console.ReadKey();
                        }
                    }

                    if (car.IsFixed())
                    {
                        Console.WriteLine("Машина востановленна");
                        _money += WorkPrice + _detailsPrice;
                        Console.WriteLine($"Вы получили Оплату за работу в размере {WorkPrice}, и оплату верно заменённых деталей в размере {_detailsPrice}");
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

        private List<Detail> SelectDetails(Car car)
        {
            bool isSelecting = true;
            List<int> detailNumbers = new List<int>();
            List<Detail> selectedDetails = new List<Detail>();

            while (isSelecting)
            {
                Console.Clear();
                ShowInfo();
                Console.WriteLine("Детали машины клиента:");
                car.ShowDetails();
                Console.WriteLine("\n Выбранные детали:");

                for (int i = 0; i < detailNumbers.Count; i++)
                {
                    Console.Write(detailNumbers[i]);

                    if (i < detailNumbers.Count - 1)
                    {
                        Console.Write(", ");
                    }
                }

                Console.WriteLine("\n Выберите номер детали, которую хотите поменять, " +
                                 $"\n или введите пустое поле, если выбрали все необходимые детали." +
                                 $"\n Не выбрав ни одной детали, вы отказываете клиенту.");
                string detailNumber = Console.ReadLine();

                if (detailNumber == string.Empty)
                {
                    isSelecting = false;
                }
                else
                {
                    if (int.TryParse(detailNumber, out int number))
                    {
                        if (number > 0 && number <= car.GetDetails().Count)
                        {
                            if (detailNumbers.Contains(number) == false)
                            {
                                detailNumbers.Add(number);
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
                        Console.WriteLine($"\"{detailNumber}\" не является числом.");
                        Console.ReadKey();
                    }
                }
            }

            for (int i = 0; i < detailNumbers.Count; i++)
            {
                selectedDetails.Add(car.GetDetails()[detailNumbers[i] - 1]);
            }

            return selectedDetails;
        }

        private Detail GetDetailByName(string detailName)
        {
            var details = _details.Keys;

            foreach (var detail in details)
            {
                if (detail.Name == detailName)
                {
                    if (_details[detail] > 0)
                    {
                        _details[detail]--;
                        return new Detail(detail.Name, detail.Price, detail.IsBroken);
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

            var details = _details.Keys;

            foreach (var detail in details)
            {
                Console.WriteLine($"{detail.Name} {_details[detail]}");
            }

            Console.WriteLine();
        }
    }

    class Factory
    {
        private List<Detail> _details;

        public Factory(List<Detail> details)
        {
            if (details != null && details.Count > 0)
            {
                _details = new List<Detail>(details);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public List<Detail> MakeDetails()
        {
            List<Detail> newList = new List<Detail>();

            foreach (var detail in _details)
            {
                newList.Add(new Detail(detail.Name, detail.Price, detail.IsBroken));
            }

            return newList;
        }
    }

    class Car
    {
        private List<Detail> _details;

        public Car(List<Detail> details)
        {
            _details = new List<Detail>(details);
        }

        public int MaterialDamage { get; private set; }

        public List<Detail> GetDetails()
        {
            List<Detail> newList = new List<Detail>();

            foreach (var detail in _details)
            {
                newList.Add(new Detail(detail.Name, detail.Price, detail.IsBroken));
            }

            return newList;
        }

        public bool IsFixed()
        {
            foreach (var detail in _details)
            {
                if (detail.IsBroken)
                {
                    return false;
                }
            }

            return true;
        }

        public void GenerateDamage(double BrokenChanse)
        {
            bool isBrokened = false;

            foreach (var detail in _details)
            {
                if (CustomRandom.GetBool(BrokenChanse))
                {
                    detail.TakeDamage();
                    isBrokened = true;
                }
            }

            if (isBrokened == false)
            {
                _details[CustomRandom.GetNumber(0, _details.Count)].TakeDamage();
            }
        }

        public void ShowDetails()
        {
            for (int i = 0; i < _details.Count; i++)
            {
                Console.Write($"{i + 1} ");
                _details[i].ShowInfo();
            }
        }

        public void SwichDetail(Detail newDetail)
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].Name == newDetail.Name)
                {
                    if (_details[i].IsBroken == false)
                    {
                        MaterialDamage = _details[i].Price;
                    }

                    _details[i] = newDetail;
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