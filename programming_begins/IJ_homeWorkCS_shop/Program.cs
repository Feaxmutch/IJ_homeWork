using System;
namespace IJ_homeWorkCS_shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int crystalPrice = 34;
            int userCrystals = 0;

            Console.Write("Введите начальное количество монет: ");
            int userGold = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.WriteLine($"Монеты: {userGold}\n" +
                              $"Кристалы: {userCrystals}\n");
            Console.WriteLine($"Мы продаём кристалы. \nИх цена составляет {crystalPrice} золотых монет за штуку.");
            Console.WriteLine("Сколько кристалов вы хотите купить?");
            int buyedCrystals = Convert.ToInt32(Console.ReadLine());
            userGold -= buyedCrystals * crystalPrice;
            userCrystals += buyedCrystals;
            Console.Clear();

            Console.WriteLine($"Монеты: {userGold}\n" +
                              $"Кристалы: {userCrystals}\n");
            Console.Write($"Вы купили {buyedCrystals} кристалов.");
            Console.ReadKey();
        }
    }
}
