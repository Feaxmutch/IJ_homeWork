namespace IJ_homeWork_dossier
{
    internal class Program
    {
        static void AddDossier(ref string[,] names, ref string[] posts, string name, string surname, string patronymic, string post)
        {
            string[,] namesBuffer = new string[names.GetLength(0), 3];
            string[] postsBuffer = new string[posts.Length];

            for (int i = 0; i < namesBuffer.GetLength(0); i++)
            {
                for (int j = 0; j < namesBuffer.GetLength(1); j++)
                {
                    namesBuffer[i,j] = names[i,j];
                }
                postsBuffer[i] = posts[i];
            }

            names = new string[names.GetLength(0) + 1, 3];
            names[names.GetLength(0) - 1, 0] = surname;
            names[names.GetLength(0) - 1, 1] = name;
            names[names.GetLength(0) - 1, 2] = patronymic;

            posts = new string[posts.Length + 1];
            posts[posts.Length - 1] = post;

            for (int i = 0; i < namesBuffer.GetLength(0); i++)
            {
                for (int j = 0; j < namesBuffer.GetLength(1); j++)
                {
                    names[i,j] = namesBuffer[i,j];
                }
                posts[i] = postsBuffer[i];
            }
        }

        static void WriteDosser(string[,] names, string[] posts, int dosserNumber)
        {
            Console.WriteLine($"{dosserNumber}. {names[dosserNumber - 1,0]} {names[dosserNumber - 1, 1]} {names[dosserNumber - 1, 2]} - {posts[dosserNumber - 1]}");
        }

        static void DeleteDosser(ref string[,] names, ref string[] posts, int dosserNumber)
        {
            string[,] namesBuffer = new string[names.GetLength(0) - 1, 3];
            string[] postsBuffer = new string[posts.Length - 1];

            for (int j = 0; j < names.GetLength(1); j++)
            {
                names[dosserNumber - 1, j] = null;
            }

            posts[dosserNumber - 1] = null;

            for (int i = dosserNumber - 1; i < names.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < names.GetLength(1); j++)
                {
                    names[i, j] = names[i + 1, j];
                }
                posts[i] = posts[i + 1];
            }

            for (int i = 0; i < namesBuffer.GetLength(0); i++)
            {
                for (int j = 0; j < namesBuffer.GetLength(1); j++)
                {
                    namesBuffer[i, j] = names[i, j];
                }
                postsBuffer[i] = posts[i];
            }

            names = new string[names.GetLength(0) - 1, 3];
            posts = new string[posts.Length - 1];

            for (int i = 0; i < namesBuffer.GetLength(0); i++)
            {
                for (int j = 0; j < namesBuffer.GetLength(1); j++)
                {
                    names[i, j] = namesBuffer[i, j];
                }
                posts[i] = postsBuffer[i];
            }
        }

        static void FindDosserBySurname(ref string[,] names, ref string[] posts, string surname)
        {

        }

        static void Main()
        {
            const string MenuAddDosser = "D1";
            const string MenuWriteDossers = "D2";
            const string MenuDeleteDosser = "D3";
            const string MenuFindDosserBySurname = "D4";
            const string CommandExit = "D5";

            string[,] names = new string[0, 3];
            string[] posts = new string[names.Length];
            string[] userInput = new string[5];
            bool isWorking = true;

            AddDossier(ref names, ref posts, "Данил", "Миншаехов", "Рустамович", "программист");             // Временные методы. Нужно удалить позже.
            AddDossier(ref names, ref posts, "Александр", "Огурцов", "Андреевич", "таксист");             
            AddDossier(ref names, ref posts, "Тимофей", "Сахаров", "Григоривич", "дизайнер");
            AddDossier(ref names, ref posts, "Сергей", "Смежнов", "Петрович", "Танкист");
            DeleteDosser(ref names, ref posts, 2);
            while (isWorking)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine($"\n{MenuAddDosser.Remove(0, 1)}) добавить досье" +
                                  $"\n{MenuWriteDossers.Remove(0, 1)}) вывести все досье" +
                                  $"\n{MenuDeleteDosser.Remove(0, 1)}) удалить досье" +
                                  $"\n{MenuFindDosserBySurname.Remove(0, 1)}) поиск по фамилии" +
                                  $"\n{CommandExit.Remove(0, 1)}) выход");

                userInput[0] = Console.ReadKey(true).Key.ToString();

                switch (userInput[0])
                {
                    case MenuAddDosser:
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
                        WriteDosser(names, posts, names.GetLength(0));

                        Console.ReadKey();
                        break;

                    case MenuWriteDossers:
                        Console.Clear();

                        for (int i = 1; i <= names.GetLength(0); i++)
                        {
                            WriteDosser(names, posts, i);
                        }

                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}