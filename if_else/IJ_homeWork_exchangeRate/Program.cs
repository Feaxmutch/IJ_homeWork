namespace IJ_homeWork_exchangeRate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string MenuRUB = "D1";
            const string MenuUSD = "D2";
            const string MenuEUR = "D3";
            const string CommandRUBToUSD = "D1";
            const string CommandRUBToEUR = "D2";
            const string CommandUSDToRUB = "D1";
            const string CommandUSDToEUR = "D2";
            const string CommandEURToRUB = "D1";
            const string CommandEURToUSD = "D2";
            const string CommandBack = "Escape";

            Random random = new Random();
            int minRandomValue = 1;
            int maxRandomValue = 101;
            double ExchangeRateRUBToUSD = 0.011894;
            double ExchangeRateRUBToEUR = 0.01093;
            double ExchangeRateUSDToRUB = 84.08;
            double ExchangeRateUSDToEUR = 0.91897;
            double ExchangeRateEURToRUB = 91.49;
            double ExchangeRateEURToUSD = 1.09;
            double userRUB = random.Next(minRandomValue, maxRandomValue);
            double userUSD = random.Next(minRandomValue, maxRandomValue);
            double userEUR = random.Next(minRandomValue, maxRandomValue);
            double userMoneyForConvert;
            bool isRunning = true;
            bool isRUBMenu;
            bool isUSDMenu;
            bool isEURMenu;

            while (isRunning == true)
            {
                Console.Clear();
                Console.WriteLine($"RUB {userRUB}\n" +
                                  $"USD {userUSD}\n" +
                                  $"EUR {userEUR}\n");
                Console.WriteLine("(1) - Конвертировать рубли\n" +
                                  "(2) - Конвертировать доллары\n" +
                                  "(3) - Конвертировать евро\n" +
                                  "(Esc) - Закрыть программу");

                switch (Console.ReadKey(true).Key.ToString())
                {
                    case MenuRUB:
                        isRUBMenu = true;

                        while (isRUBMenu)
                        {
                            Console.Clear();
                            Console.WriteLine($"RUB {userRUB}\n" +
                                              $"USD {userUSD}\n" +
                                              $"EUR {userEUR}\n");
                            Console.WriteLine("Во что вы хотите конвертировать рубли?\n" +
                                              "(1) - В доллары\n" +
                                              "(2) - В евро\n" +
                                              "(Esc) - вернуться");

                            switch (Console.ReadKey(true).Key.ToString())
                            {
                                case CommandRUBToUSD:
                                    Console.Clear();
                                    Console.WriteLine($"RUB {userRUB}\n" +
                                                      $"USD {userUSD}\n" +
                                                      $"EUR {userEUR}\n");
                                    Console.WriteLine("Сколько рублей вы хотите конвертировать в доллары?");
                                    userMoneyForConvert = Convert.ToDouble(Console.ReadLine());
                                    userRUB -= userMoneyForConvert;
                                    userUSD += userMoneyForConvert * ExchangeRateRUBToUSD;
                                    isRUBMenu = false;
                                    break;

                                case CommandRUBToEUR:
                                    Console.Clear();
                                    Console.WriteLine($"RUB {userRUB}\n" +
                                                      $"USD {userUSD}\n" +
                                                      $"EUR {userEUR}\n");
                                    Console.WriteLine("Сколько рублей вы хотите конвертировать в евро?");
                                    userMoneyForConvert = Convert.ToDouble(Console.ReadLine());
                                    userRUB -= userMoneyForConvert;
                                    userEUR += userMoneyForConvert * ExchangeRateRUBToEUR;
                                    isRUBMenu = false;
                                    break;

                                case CommandBack:
                                    isRUBMenu = false;
                                    break;
                            }
                        }
                        break;

                    case MenuUSD:
                        isUSDMenu = true;

                        while (isUSDMenu)
                        {
                            Console.Clear();
                            Console.WriteLine($"RUB {userRUB}\n" +
                                              $"USD {userUSD}\n" +
                                              $"EUR {userEUR}\n");
                            Console.WriteLine("Во что вы хотите конвертировать доллары?\n" +
                                              "(1) - В рубли\n" +
                                              "(2) - В евро\n" +
                                              "(Esc) - вернуться");

                            switch (Console.ReadKey(true).Key.ToString())
                            {
                                case CommandUSDToRUB:
                                    Console.Clear();
                                    Console.WriteLine($"RUB {userRUB}\n" +
                                                      $"USD {userUSD}\n" +
                                                      $"EUR {userEUR}\n");
                                    Console.WriteLine("Сколько долларов вы хотите конвертировать в рубли?");
                                    userMoneyForConvert = Convert.ToDouble(Console.ReadLine());
                                    userUSD -= userMoneyForConvert;
                                    userRUB += userMoneyForConvert * ExchangeRateUSDToRUB;
                                    isUSDMenu = false;
                                    break;

                                case CommandUSDToEUR:
                                    Console.Clear();
                                    Console.WriteLine($"RUB {userRUB}\n" +
                                                      $"USD {userUSD}\n" +
                                                      $"EUR {userEUR}\n");
                                    Console.WriteLine("Сколько долларов вы хотите конвертировать в евро?");
                                    userMoneyForConvert = Convert.ToDouble(Console.ReadLine());
                                    userUSD -= userMoneyForConvert;
                                    userEUR += userMoneyForConvert * ExchangeRateUSDToEUR;
                                    isUSDMenu = false;
                                    break;

                                case CommandBack:
                                    isUSDMenu = false;
                                    break;
                            }
                        }
                        break;

                    case MenuEUR:
                        isEURMenu = true;

                        while (isEURMenu)
                        {
                            Console.Clear();
                            Console.WriteLine($"RUB {userRUB}\n" +
                                              $"USD {userUSD}\n" +
                                              $"EUR {userEUR}\n");
                            Console.WriteLine("Во что вы хотите конвертировать евро?\n" +
                                              "(1) - В рубли\n" +
                                              "(2) - В доллары\n" +
                                              "(Esc) - вернуться");

                            switch (Console.ReadKey(true).Key.ToString())
                            {
                                case CommandEURToRUB:
                                    Console.Clear();
                                    Console.WriteLine($"RUB {userRUB}\n" +
                                                      $"USD {userUSD}\n" +
                                                      $"EUR {userEUR}\n");
                                    Console.WriteLine("Сколько евро вы хотите конвертировать в рубли?");
                                    userMoneyForConvert = Convert.ToDouble(Console.ReadLine());
                                    userEUR -= userMoneyForConvert;
                                    userRUB += userMoneyForConvert * ExchangeRateEURToRUB;
                                    isEURMenu = false;
                                    break;

                                case CommandEURToUSD:
                                    Console.Clear();
                                    Console.WriteLine($"RUB {userRUB}\n" +
                                                      $"USD {userUSD}\n" +
                                                      $"EUR {userEUR}\n");
                                    Console.WriteLine("Сколько евро вы хотите конвертировать в доллары?");
                                    userMoneyForConvert = Convert.ToDouble(Console.ReadLine());
                                    userEUR -= userMoneyForConvert;
                                    userUSD += userMoneyForConvert * ExchangeRateEURToUSD;
                                    isEURMenu = false;
                                    break;

                                case CommandBack:
                                    isEURMenu = false;
                                    break;
                            }
                        }
                        break;

                    case CommandBack:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}