namespace IJ_homeWork_dossier_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string MenuAddDossier = "D1";
            const string MenuWriteDossiers = "D2";
            const string MenuDeleteDossier = "D3";
            const string CommandExit = "D4";

            List<string> names = new List<string>();
            List<string> posts = new List<string>();
            string userInput = string.Empty;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Console.CursorVisible = false;

                Console.WriteLine($"\n{MenuAddDossier.Remove(0, 1)}) добавить досье" +
                                  $"\n{MenuWriteDossiers.Remove(0, 1)}) вывести все досье" +
                                  $"\n{MenuDeleteDossier.Remove(0, 1)}) удалить досье" +
                                  $"\n{CommandExit.Remove(0, 1)}) выход");

                userInput = Console.ReadKey(true).Key.ToString();

                switch (userInput)
                {
                    case MenuAddDossier:
                        AddDossier(names, posts);
                        break;

                    case MenuWriteDossiers:
                        WriteAllDossiers(names, posts);
                        break;

                    case MenuDeleteDossier:
                        DeliteDossier(names, posts);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }

        static void AddDossier(List<string> names, List<string> posts)
        {
            string[] userInputs = new string[4];

            Console.Clear();
            Console.CursorVisible = true;

            Console.Write("Введите имя: ");
            userInputs[0] = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            userInputs[1] = Console.ReadLine();

            Console.Write("Введите отчество: ");
            userInputs[2] = Console.ReadLine();

            Console.Write("Введите должность: ");
            userInputs[3] = Console.ReadLine();

            Console.CursorVisible = false;

            for (int i = 0; i < userInputs.Length; i++)
            {
                if (userInputs[i] == string.Empty)
                {
                    userInputs[i] = "Не_указано";
                }
            }

            names.Add($"{userInputs[1]} {userInputs[0]} {userInputs[2]}");
            posts.Add(userInputs[3]);

            Console.WriteLine("Добавленно следующее досье:");
            WriteDossier(names, posts, names.Count);

            Console.ReadKey(true);
        }

        static void WriteDossier(List<string> names, List<string> posts, int dossierNumber)
        {
            Console.WriteLine($"{dossierNumber}. {names[dossierNumber - 1]} - {posts[dossierNumber - 1]}");
        }

        static void WriteAllDossiers(List<string> names, List<string> posts)
        {
            Console.Clear();

            for (int i = 1; i <= names.Count; i++)
            {
                WriteDossier(names, posts, i);
            }

            Console.ReadKey(true);
        }

        static void DeliteDossier(List<string> names, List<string> posts)
        {
            Console.Clear();
            WriteAllDossiers(names, posts);
            Console.Write("\nВведите номер досье, которое хотите удалить: ");

            if (int.TryParse(Console.ReadLine(), out int dossierNumber))
            {
                if (dossierNumber <= 0 || dossierNumber > names.Count)
                {
                    Console.WriteLine("Некоректный номер досье");
                }
                else
                {
                    names.RemoveAt(dossierNumber - 1);
                }
            }
            else
            {
                Console.WriteLine("Похоже вы ввели не число.");
            }

            Console.ReadKey();
        }
    }
}