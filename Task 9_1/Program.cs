namespace Task_9_1
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                var book = new Book("Евгений Онегин", "А. С. Пушкин", 1833, 287);
                var book1 = new Book("Волшебная гора", "Т. Манн", 1924, 829);
                Console.WriteLine(book.GetInfo());
                Console.WriteLine(book1.GetInfo());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
    public class Book
    {
        private string _title;
        private string _author;

        public int Year { get; set; }
        public int Pages { get; set; }

        public Book(string title, string author, int year, int pages)
        {
            if (pages <= 0)
                throw new ArgumentException("Количество страниц должно быть положительным числом");

            _title = title;
            _author = author;
            Year = year;
            Pages = pages;
        }

        public string GetInfo()
        {
            return $"{_title}, {_author}, {Year} год, {Pages} стр.";
        }
    }
}
