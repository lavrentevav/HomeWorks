using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_6_2
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

            input = input.Replace(" ", "").ToLower();

            StringBuilder result = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                result.Append(input[i]);
            }

            Console.WriteLine();
            Console.WriteLine(input == result.ToString() ? "Строка является палиндромом" : "Строка не является палиндромом");
            Console.ReadKey();
        }
    }
}
