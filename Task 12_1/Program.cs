namespace Task_12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Книги с string-Code и int-Year
            Book<string, int>[] books1 = new Book<string, int>[]
            {
                new Book<string, int>("F-1234", "Распознавания", "Уильям Гэддис", 1955),
                new Book<string, int>("F-1235", "Приглашение на казнь", "Владимир Набоков", 1938)
            };

            // Книги с int-Code и string-Year
            Book<int, string>[] books2 = new Book<int, string>[]
            {
                new Book<int, string>(41, "Радуга тяготения", "Томас Пинчон", "1973"),
                new Book<int, string>(42, "Илиада", "Гомер", "IX—VIII вв. до н. э.")
            };

            // Поиск книги с string-Code
            var book1 = FindBook(books1, "F-1234");
            Console.WriteLine(book1?.ToString() ?? "Книга не найдена");

            // Поиск книги с int-Code
            var book2 = FindBook(books2, 42);
            Console.WriteLine(book2?.ToString() ?? "Книга не найдена");

            Console.ReadKey();
        }

        public static Book<T, U> FindBook<T, U>(Book<T, U>[] books, T code)
        {
            foreach (Book<T, U> book in books)
            {
                if (book.Code.Equals(code))
                    return book;
            }
            return null;
        }
    }

    public class Book<T, U>
    {
        public T Code { get; set; }
        public U PublicationYear { get; set; }     
        public string Title { get; set; }
        public string Author { get; set; }

        // Конструктор
        public Book(T code, string title, string author, U publicationYear)
        {
            Code = code;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }

        // Переопределение ToString для удобного вывода
        public override string ToString()
            => $"Код: {Code} ({typeof(T).Name}), Название: {Title}, Автор: {Author}, Год: {PublicationYear} ({typeof(U).Name})";
    }
}
