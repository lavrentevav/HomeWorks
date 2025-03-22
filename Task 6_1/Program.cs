using System.Text.RegularExpressions;

namespace Task_6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку из слов, разделенных пробелами, без знаков препинания:");
            string input = Console.ReadLine();

            while (Regex.IsMatch(input, @"[^a-zA-Zа-яА-ЯёЁ0-9\s]") || string.IsNullOrWhiteSpace(input)) // проверяем не введены ли знаки препинания, нижние подчеркивания, а также не введена ли пустота или только пробелы без текста
            {
                Console.WriteLine("Ошибка ввода. Введите строку из слов, разделенных пробелами, без знаков препинания:");
                input = Console.ReadLine();
            }

            string[] words = input.Split(' ');

            int maxLength = 0;
            string maxLengthWord = "";

            foreach (var word in words)
            {
                if (word.Length > maxLength)
                {
                    maxLength = word.Length;
                    maxLengthWord = word;
                }
                else if (word.Length == maxLength)
                {
                    maxLengthWord = maxLengthWord + ", " + word;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Самое длинное слово в строке: {0}", maxLengthWord);
            Console.ReadKey();
        }
    }
}
