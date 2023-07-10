namespace IJ_homeWork_CommandLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandHelp = "help";
            const string CommandClear = "clear";
            const string CommandExit = "exit";
            const string CommandSetBackgroundColor = "set background color";
            const string CommandSetForegroundColor = "set foreground color";
            const string CommandSetTitle = "set title";
            const string CommandLogin = "login";
            const string CommandLogout = "logout";
            const string CommandSetName = "set name";
            const string CommandSetPassword = "set password";
            const string CommandForgetPassword = "forget password";
            const string CommandWriteNames = "write names";
            const string CommandWriteName = "write name";
           

            string userInput = string.Empty;
            string DefaultAccountName = "admin";
            string DefaultAccountPassword = "admin";
            string accountName = DefaultAccountName;
            string accountPassword = DefaultAccountPassword;
            bool isRunning = true;
            bool isAccount = false;

            while (isRunning)
            {
                Console.Write("Введите команду>");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    default:
                        Console.WriteLine($"Неизвесная комманда {userInput}.\n" +
                                          $"Попробуйте выполнить \"{CommandHelp}\", для вывода всех доступных комманд.");
                        break;

                    case CommandHelp:
                        Console.WriteLine("Список комманд:");
                        Console.WriteLine($"\n{CommandSetTitle} - устанавливает заголовок консоли." +
                                          $"\n{CommandSetBackgroundColor} - устанавливает цвет фона консоли." +
                                          $"\n{CommandSetForegroundColor} - устанавливает цвет текста консоли." +
                                          $"\n{CommandLogin} - Позволяет войти в учетную запись." +
                                          $"\n{CommandLogout} - Позволяет выйти из учетной записи." +
                                          $"\n{CommandSetName} - устанавливает новое имя учетной записи." +
                                          $"\n{CommandSetPassword} - устанавливает новый пароль учетной записи." +
                                          $"\n{CommandForgetPassword} - сбрасывает пароль учетной записи (Вводить только в строку ввода пароля)." +
                                          $"\n{CommandWriteName} - выводит имя текущей учетной записи." +
                                          $"\n{CommandWriteNames} - выводит имена всех учетных записей." +
                                          $"\n{CommandClear} - очищает консоль." +
                                          $"\n{CommandExit} - закрывает консоль.");
                        break;

                    case CommandClear:
                        Console.Clear();
                        break;

                    case CommandLogin:
                        Console.Write("Введите имя учетной записи>");
                        userInput = Console.ReadLine();

                        if (userInput == accountName)
                        {
                            Console.Write("Введите пароль>");
                            userInput = Console.ReadLine();

                            if (userInput == accountPassword)
                            {
                                isAccount = true;
                            }
                            else if (userInput == CommandForgetPassword)
                            {
                                accountPassword = DefaultAccountPassword;
                                Console.WriteLine($"Пароль успешно сброшен. Новый пароль это - {accountPassword}");
                            }
                            else
                            {
                                Console.WriteLine($"Неверный пароль.\n" +
                                                  $"Если вы забыли пароль попробуйте ввести \"{CommandForgetPassword}\" в строку ввода пароля, для сброса пароля.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"имени учетной записи \"{userInput}\" не существует.\n" +
                                              $"Попробуйте выполнить \"{CommandWriteNames}\", чтобы отобразить имена учетных записей.");
                        }
                        break;

                    case CommandLogout:
                        if (isAccount)
                        {
                            isAccount = false;
                            Console.WriteLine("Вы вышли из учетной записи.");
                        }
                        else
                        {
                            Console.WriteLine($"Вы не вошли в учетную запись. Выполните \"{CommandLogin}\", для входа в учетную запись.");
                        }
                        break;

                    case CommandWriteNames:
                        Console.WriteLine($"Имена всех учетных записей - {accountName}");
                        break;

                    case CommandWriteName:
                        if (isAccount)
                        {
                            Console.WriteLine($"Имя нынешней учетной записи - \"{accountName}\"");
                        }
                        else
                        {
                            Console.WriteLine($"Вы не вошли в учетную запись. Выполните \"{CommandLogin}\", для входа в учетную запись.");
                        }
                        break;

                    case CommandSetName:
                        if (isAccount)
                        {
                            Console.Write("Введите пароль>");
                            userInput = Console.ReadLine();

                            if (userInput == accountPassword)
                            {
                                Console.Write("Введите новое имя>");
                                userInput = Console.ReadLine();
                                accountName = userInput;
                                Console.WriteLine($"Имя учетной записи изменено на {accountName}");
                            }
                            else if (userInput == CommandForgetPassword)
                            {
                                accountPassword = DefaultAccountPassword;
                                Console.WriteLine($"Пароль успешно сброшен. Новый пароль это - {accountPassword}");
                            }
                            else
                            {
                                Console.WriteLine($"Неверный пароль.\n" +
                                                  $"Если вы забыли пароль попробуйте ввести \"{CommandForgetPassword}\" в строку ввода пароля, для сброса пароля.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Вы не вошли в учетную запись. Выполните \"{CommandLogin}\", для входа в учетную запись.");
                        }
                        break;

                    case CommandSetPassword:
                        if (isAccount)
                        {
                            Console.Write("Введите текущий пароль>");
                            userInput = Console.ReadLine();

                            if (userInput == accountPassword)
                            {
                                Console.Write("Введите новый пароль>");
                                userInput = Console.ReadLine();

                                if (userInput != CommandForgetPassword)
                                {
                                    accountPassword = userInput;
                                    Console.WriteLine("Пароль успешно изменен.");
                                }
                                else
                                {
                                    Console.WriteLine($"Пароль не может быть \"{CommandForgetPassword}\". Это команда приложения для сброса пароля.");
                                }
                            }
                            else if (userInput == CommandForgetPassword)
                            {
                                accountPassword = DefaultAccountPassword;
                                Console.WriteLine($"Пароль успешно сброшен. Новый пароль это - {accountPassword}");
                            }
                            else
                            {
                                Console.WriteLine($"Неверный пароль.\n" +
                                                  $"Если вы забыли пароль попробуйте ввести \"{CommandForgetPassword}\" в строку ввода пароля, для сброса пароля.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Вы не вошли в учетную запись. Выполните \"{CommandLogin}\", для входа в учетную запись.");
                        }
                        break;

                    case CommandSetTitle:
                        if (isAccount)
                        {
                            Console.WriteLine();
                            Console.Write("Введите будующий заголовок консоли>");
                            Console.Title = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine($"Вы не вошли в учетную запись. Выполните \"{CommandLogin}\", для входа в учетную запись.");
                        }
                        break;

                    case CommandSetBackgroundColor:
                        if (isAccount)
                        {
                            Console.Write("Введите номер цвета, который хотите установить>");
                            userInput = Console.ReadLine();
                            Console.BackgroundColor = (ConsoleColor)Convert.ToInt32(userInput);
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"Вы не вошли в учетную запись. Выполните \"{CommandLogin}\", для входа в учетную запись.");
                        }
                        break;

                    case CommandSetForegroundColor:
                        if (isAccount)
                        {
                            Console.Write("Введите номер цвета, который хотите установить>");
                            userInput = Console.ReadLine();
                            Console.ForegroundColor = (ConsoleColor)Convert.ToInt32(userInput);
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"Вы не вошли в учетную запись. Выполните \"{CommandLogin}\", для входа в учетную запись.");
                        }
                        break;

                    case CommandExit:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}