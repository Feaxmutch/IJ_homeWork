namespace IJ_homeWork_bookStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new();

            storage.ShowMenu();
        }
    }

    class Storage
    {
        private List<Book> _books = new List<Book>();

        public void ShowMenu()
        {
            const ConsoleKey MenuAdd = ConsoleKey.D1;
            const ConsoleKey MenuRemove = ConsoleKey.D2;
            const ConsoleKey MenuShowAll = ConsoleKey.D3;
            const ConsoleKey MenuSearch = ConsoleKey.D4;
            const ConsoleKey CommandEscape = ConsoleKey.Escape;

            bool isSelecting = true;

            while (isSelecting)
            {
                Console.Clear();
                Console.Write($"{MenuAdd}) Добавить книгу" +
                            $"\n{MenuRemove}) Удалить книгу" +
                            $"\n{MenuShowAll}) Отобразить все книги" +
                            $"\n{MenuSearch}) Найти книгу");

                ConsoleKey userInput = Console.ReadKey(true).Key;

                switch (userInput)
                {
                    case CommandEscape:
                        isSelecting = false;
                        break;

                    case MenuAdd:
                        AddBook();
                        break;

                    case MenuRemove:
                        RemoveBook();
                        break;

                    case MenuShowAll:
                        ShowAllBooks();
                        break;

                    case MenuSearch:
                        ShowSearchMenu();
                        break;
                }
            }
        }

        private void AddBook()
        {
            Console.Clear();

            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();

            Console.Write("Введите автора книги: ");
            string autor = Console.ReadLine();

            Console.Write("Введите год выпуска книги: ");

            if (int.TryParse(Console.ReadLine(), out int year))
            {
                _books.Add(new Book(title, autor, year));
            }
            else
            {
                Console.WriteLine("Ошибка. Год выпуска должен быть числом.");
                Console.ReadKey();
            }
        }

        private void RemoveBook()
        {
            int lastParametеr = (int)BookParametеr.Year;
            List<Book> booksForRemove = new List<Book>(_books);

            for (int i = 0; i <= lastParametеr; i++)
            {
                ShowBooks(booksForRemove);
                Console.Write("Введите ");

                switch (i)
                {
                    case (int)BookParametеr.Title:
                        Console.Write("название ");
                        break;

                    case (int)BookParametеr.Autor:
                        Console.Write("автора ");
                        break;

                    case (int)BookParametеr.Year:
                        Console.Write("год выпуска ");
                        break;
                }

                Console.Write("книги, которую хотите удалить: ");

                string userInput = Console.ReadLine();

                switch (i)
                {
                    case (int)BookParametеr.Title:
                        booksForRemove = Search(_books, BookParametеr.Title, userInput);
                        break;

                    case (int)BookParametеr.Autor:
                        booksForRemove = Search(_books, BookParametеr.Autor, userInput);
                        break;

                    case (int)BookParametеr.Year:
                        booksForRemove = Search(_books, BookParametеr.Year, userInput);
                        break;
                }
            }

            if (booksForRemove.Count > 0)
            {
                _books.Remove(booksForRemove[0]);
                Console.WriteLine("Книга не найдена");
            }
            else
            {
                Console.WriteLine("Книга не найдена");
            }
        }

        private void ShowAllBooks()
        {
            Console.Clear();
            ShowBooks(_books);
            Console.ReadKey();
        }

        private void ShowSearchMenu()
        {
            const string CommandTitle = "1";
            const string CommandAutor = "2";
            const string CommandYear = "3";

            List<Book> foundedBooks = new List<Book>();
            bool isSelecting = true;
            string searchMode = string.Empty;

            while (isSelecting)
            {
                Console.Clear();
                Console.Write("Выберите параметр, по которому будет производится поиск:" +
                             $"\n{CommandTitle}) По названию" +
                             $"\n{CommandAutor}) По автору" +
                             $"\n{CommandYear}) По году выпуска");

                searchMode = Console.ReadKey(true).KeyChar.ToString();
                isSelecting = false;

                Console.Clear();
                Console.Write("Введите ");

                switch (searchMode)
                {
                    default:
                        isSelecting = true;
                        break;

                    case CommandTitle:
                        Console.Write("название");
                        break;

                    case CommandAutor:
                        Console.Write("автора");
                        break;

                    case CommandYear:
                        Console.Write("год выпуска");
                        break;
                }

                Console.Write(": ");
            }

            string searchRequest = Console.ReadLine();

            switch (searchMode)
            {
                case CommandTitle:
                    foundedBooks = Search(_books, BookParametеr.Title, searchRequest);
                    break;

                case CommandAutor:
                    foundedBooks = Search(_books, BookParametеr.Autor, searchRequest);
                    break;

                case CommandYear:
                    foundedBooks = Search(_books, BookParametеr.Year, searchRequest);
                    break;
            }

            Console.Clear();

            if (foundedBooks.Count > 0)
            {
                Console.WriteLine("Найдены следующие книги");
                ShowBooks(foundedBooks);
            }
            else
            {
                Console.WriteLine("Не найдено ни одной книги");
            }

            Console.ReadKey();
        }

        private List<Book> Search(List<Book> books, BookParametеr parametеr, string searchRequest)
        {
            List<Book> foundedBooks = new List<Book>();

            foreach (var book in books)
            {
                switch (parametеr)
                {
                    case BookParametеr.Title:
                        if (book.Title.ToLower().Contains(searchRequest.ToLower()))
                        {
                            foundedBooks.Add(book);
                        }
                        break;

                    case BookParametеr.Autor:
                        if (book.Autor.ToLower().Contains(searchRequest.ToLower()))
                        {
                            foundedBooks.Add(book);
                        }
                        break;

                    case BookParametеr.Year:
                        if (book.Year == int.Parse(searchRequest))
                        {
                            foundedBooks.Add(book);
                        }
                        break;
                }
            }

            return foundedBooks;
        }

        private void ShowBooks(List<Book> books)
        {
            if (books != null)
            {
                foreach (var book in books)
                {
                    book.ShowInfo();
                }
            }
        }
    }

    class Book
    {
        private string _title;
        private string _autor;

        public Book(string title, string autor, int year)
        {
            Title = title;
            Autor = autor;
            Year = year;
        }

        public string Title
        {
            get => _title;

            private set
            {
                if (value == string.Empty)
                {
                    _title = "Не_указанно";
                }
                else
                {
                    _title = value;
                }
            } 
        }

        public string Autor 
        {
            get => _autor;
            
            private set
            {
                if (value == string.Empty)
                {
                    _autor = "Не_указанно";
                }
                else
                {
                    _autor = value;
                }
            } 
        }

        public int Year { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"имя: {Title} автор: {Autor} год выпуска: {Year}");
        }
    }

    enum BookParametеr
    {
        Title,
        Autor,
        Year
    }
}