namespace IJ_homeWork_dossier
{
    internal class Program
    {
        static void Main()
        {
            const string MenuAddDossier = "D1";
            const string MenuWriteDossers = "D2";
            const string MenuDeleteDosser = "D3";
            const string MenuFindDosserBySurname = "D4";
            const string CommandExit = "D5";

            string[] names = new string[0];
            string[] posts = new string[names.Length];
            string userInput = string.Empty;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine($"\n{MenuAddDossier.Remove(0, 1)}) добавить досье" +
                                  $"\n{MenuWriteDossers.Remove(0, 1)}) вывести все досье" +
                                  $"\n{MenuDeleteDosser.Remove(0, 1)}) удалить досье" +
                                  $"\n{MenuFindDosserBySurname.Remove(0, 1)}) поиск по фамилии" +
                                  $"\n{CommandExit.Remove(0, 1)}) выход");

                userInput = Console.ReadKey(true).Key.ToString();

                switch (userInput)
                {
                    case MenuAddDossier:
                        AddDossier(ref names, ref posts);
                        break;

                    case MenuWriteDossers:
                        WriteAllDossiers(names, posts);
                        break;

                    case MenuDeleteDosser:
                        DeleteDossier(ref names, ref posts);
                        break;

                    case MenuFindDosserBySurname:
                        FindDossierBySurname(names, posts);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }

        static void AddDossier(ref string[] names, ref string[] posts)
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

            Console.Write("Введите Должность: ");
            userInputs[3] = Console.ReadLine();

            for (int i = 0; i < userInputs.Length; i++)
            {
                if (userInputs[i] == string.Empty)
                {
                    userInputs[i] = "Не_указано";
                }
            }

            Console.CursorVisible = false;

            names = AddElement(names, $"{userInputs[1]} {userInputs[0]} {userInputs[2]}");
            posts = AddElement(posts, userInputs[3]);

            Console.WriteLine("Добавленно следющее досье:");
            WriteDossier(names, posts, names.Length);

            Console.ReadKey(true);
        }

        static void WriteDossier(string[] names, string[] posts, int dosserNumber)
        {
            Console.WriteLine($"{dosserNumber}. {names[dosserNumber - 1]}  - {posts[dosserNumber - 1]}");
        }

        static void DeleteDossier(ref string[] names, ref string[] posts)
        {
            string[] namesBuffer = new string[names.GetLength(0) - 1];
            string[] postsBuffer = new string[posts.Length - 1];

            Console.Clear();
            WriteAllDossiers(names, posts);
            Console.Write("\nВведите номер досье, которое хотите удалить ");
            int dosserNumber = Convert.ToInt32(Console.ReadLine());

            if (dosserNumber <= 0 || dosserNumber > names.Length)
            {
                Console.WriteLine("Некоректный номер досье");
                Console.ReadKey();
            }
            else
            {
                names = RemoveElement(names, dosserNumber - 1);
                posts = RemoveElement(posts, dosserNumber - 1);
            }
        }

        static void FindDossierBySurname(string[] names, string[] posts)
        {
            string[] userInput = new string[1];
            char separator = ' ';
            bool dossierIsFounded = false;

            Console.Clear();
            Console.CursorVisible = true;

            Console.Write("Введите начало фамилии, или полную фамилию: ");
            userInput[0] = Console.ReadLine();

            for (int i = 0; i < names.Length; i++)
            {
                if (userInput[0].Length <= names[i].Split(separator)[0].Length)
                {
                    if (names[i].Split(separator)[0].Remove(userInput[0].Length).ToLower() == userInput[0].ToLower() || userInput[0].ToLower() == names[i].Split(separator)[0].ToLower())
                    {
                        WriteDossier(names, posts, i + 1);
                        dossierIsFounded = true;
                    }
                }
            }

            if (dossierIsFounded == false)
            {
                Console.Write("Ни одно досье не найдено.");
            }

            Console.ReadKey();
        }

        static void WriteAllDossiers(string[] names, string[] posts)
        {
            Console.Clear();

            for (int i = 1; i <= names.Length; i++)
            {
                WriteDossier(names, posts, i);
            }

            Console.ReadKey(true);
        }

        static string[] AddElement(string[] array, string newElement)
        {
            string[] newArray = new string[array.Length + 1];

            for (int i = 0; i < newArray.Length - 1; i++)
            {
                newArray[i] = array[i];
            }

            newArray[newArray.Length - 1] = newElement;
            return newArray;
        }

        static string[] RemoveElement(string[] array, int elementIndex)
        {
            string[] newArray = new string[array.Length - 1];

            array[elementIndex] = null;

            for (int i = elementIndex; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }
    }
}