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
            string[] userInput = new string[5];
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

                userInput[0] = Console.ReadKey(true).Key.ToString();

                switch (userInput[0])
                {
                    case MenuAddDossier:
                        CommandAddDossier(ref names, ref posts);
                        break;

                    case MenuWriteDossers:
                        WriteAllDossers(names, posts);
                        break;

                    case MenuDeleteDosser:
                        DeleteDosser(ref names,ref posts);
                        break;

                    case MenuFindDosserBySurname:
                        CommandFindDosserBySurname(ref names, ref posts);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }

        static void AddDossier(ref string[] names, ref string[] posts, string name, string surname, string patronymic, string post)
        {
            string[] namesBuffer = new string[names.GetLength(0)];
            string[] postsBuffer = new string[posts.Length];

            for (int i = 0; i < namesBuffer.GetLength(0); i++)
            {
                namesBuffer[i] = names[i];
                postsBuffer[i] = posts[i];
            }

            names = new string[names.Length + 1];
            names[names.Length - 1] = $"{surname} {name} {patronymic}";
            posts = new string[posts.Length + 1];
            posts[posts.Length - 1] = post;

            for (int i = 0; i < namesBuffer.GetLength(0); i++)
            {
                names[i] = namesBuffer[i];
                posts[i] = postsBuffer[i];
            }
        }

        static void WriteDosser(string[] names, string[] posts, int dosserNumber)
        {
            Console.WriteLine($"{dosserNumber}. {names[dosserNumber - 1]}  - {posts[dosserNumber - 1]}");
        }

        static void DeleteDosser(ref string[] names, ref string[] posts )
        {
            Console.Clear();


            string[] namesBuffer = new string[names.GetLength(0) - 1];
            string[] postsBuffer = new string[posts.Length - 1];

            WriteAllDossers(names, posts);
            Console.Write("\nВведите номер досье, которое хотите удалить ");
            int dosserNumber = Convert.ToInt32(Console.ReadLine());

            names[dosserNumber - 1] = null;
            posts[dosserNumber - 1] = null;

            for (int i = dosserNumber - 1; i < names.Length - 1; i++)
            {
                names[i] = names[i + 1];
                posts[i] = posts[i + 1];
            }

            for (int i = 0; i < namesBuffer.Length; i++)
            {
                namesBuffer[i] = names[i];
                postsBuffer[i] = posts[i];
            }

            names = new string[names.Length - 1];
            posts = new string[posts.Length - 1];

            for (int i = 0; i < namesBuffer.Length; i++)
            {
                names[i] = namesBuffer[i];
                posts[i] = postsBuffer[i];
            }
        }

        static int[] FindDosserBySurname(ref string[] names, string surname)
        {
            int[] foundedIndexes = new int[0];
            int[] indexesBuffer = new int[foundedIndexes.Length];

            for (int i = 0; i < names.GetLength(0); i++)
            {
                if (names[i].Split(' ')[0].Remove(surname.Length).ToLower() == surname.ToLower())
                {
                    indexesBuffer = new int[foundedIndexes.Length];

                    for (int j = 0; j < indexesBuffer.Length; j++)
                    {
                        indexesBuffer[j] = foundedIndexes[j];
                    }

                    foundedIndexes = new int[foundedIndexes.Length + 1];
                    foundedIndexes[foundedIndexes.Length - 1] = i;

                    for (int j = 0; j < indexesBuffer.Length; j++)
                    {
                        foundedIndexes[j] = indexesBuffer[j];
                    }
                }
            }

            return foundedIndexes;
        }

        static void WriteAllDossers(string[] names, string[] posts)
        {
            Console.Clear();

            for (int i = 1; i <= names.Length; i++)
            {
                WriteDosser(names, posts, i);
            }

            Console.ReadKey();
        }

        static void CommandAddDossier(ref string[] names, ref string[] posts)
        {
            string[] userInput = new string[4];

            Console.Clear();
            Console.CursorVisible = true;

            Console.Write("Введите имя: ");
            userInput[0] = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            userInput[1] = Console.ReadLine();

            Console.Write("Введите отчество: ");
            userInput[2] = Console.ReadLine();

            Console.Write("Введите Должность: ");
            userInput[3] = Console.ReadLine();

            Console.CursorVisible = false;
            AddDossier(ref names, ref posts, userInput[0], userInput[1], userInput[2], userInput[3]);

            Console.WriteLine("Добавленно следющее досье:");
            WriteDosser(names, posts, names.Length);

            Console.ReadKey();
        }

        static void CommandFindDosserBySurname(ref string[] names, ref string[] posts)
        {
            string[] userInput = new string[1];

            Console.Clear();
            Console.CursorVisible = true;

            Console.Write("Введите начало фамилии, или полную фамилию: ");
            userInput[0] = Console.ReadLine();

            int[] indexes = FindDosserBySurname(ref names, userInput[0]);

            for (int i = 0; i < indexes.Length; i++)
            {
                WriteDosser(names, posts, indexes[i] + 1);
            }

            Console.ReadKey();
        }


    }
}