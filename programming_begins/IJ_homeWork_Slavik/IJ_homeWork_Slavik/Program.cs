using System;
namespace IJ_homeWork_Slavik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Slavik";

            Console.WriteLine("Здравствуйте. Меня зовут Славик. Я консольная программа.");
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("А как вас зовут?");
            Console.Write("\nВведите своё имя: ");
            string userName = Console.ReadLine();

            Console.WriteLine($"Приятно познакомится {userName}.");
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Относительно недавно мой создатель узнал, что на планете существует акула, живущая уже 518 лет.");
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"Как вы думаете {userName}: смогу ли я столько прожить в интернете?\n" +
                              "Вопрос конечно риторический, и не только потому, что в моём коде нет конструкций if else.\n" +
                              "Но и потому, что есть поговорка \"Интернет всё помнит\".");
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Кстати о возрасте. Сколько вам лет?");
            Console.Write("\nВведите свой возраст: ");
            string userAge = Console.ReadLine();  
            
            Console.WriteLine($"Я пока не умею сравнивать числа, но буду предполагать, что {userAge} это большое число, и вы достаточно взрослый человек.");
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"{userName} а кто вы по професии?");
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Со мной и так всё понятно. Я работаю здесь и сейчас, но что на счёт вас?");
            Console.Write("\nВведите название своей професии: ");
            string userProfession = Console.ReadLine();

            Console.WriteLine($"{userProfession} хорошая работа, но самое главное, чтобы она не доставляла беспокойство.");
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Если это так, то всё хорошо.");
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Кстати, чуть не забыл.");
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Изначальным заданием было написание небольшого предложения о пользователе.");
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("кхм кхм");
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"Вас зовут {userName}, ваш возраст {userAge} лет/год, ваша профессия {userProfession}.");
            Console.Write("\nЭто конец программы. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}
