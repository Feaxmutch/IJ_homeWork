namespace IJ_homeWork_bookStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Storage
    {
        private List<Book> _books = new List<Book>();

        public void AddBook()
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
        
        private List<Book> SearchByTitle(List<Book> books, string title)
        {
            List<Book> foundedBooks = new List<Book>();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == title)
                {
                    foundedBooks.Add(books[i]);
                }
            }

            return foundedBooks;
        }


    }

    class Book
    {
        public Book(string title, string autor, int year)
        {
            Title = title;
            Autor = autor;
            Year = year;
        }

        public string Title { get; private set; }

        public string Autor { get; private set; }

        public int Year { get; private set; }

        public void WriteInfo()
        {
            Console.WriteLine($"имя: {Title} автор: {Autor} год выпуска: {Year}");
        }
    }
}