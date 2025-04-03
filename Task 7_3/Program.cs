using System;

namespace Task_7_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оригинальный массив:");
            Random rnd = new Random();
            int n = rnd.Next(1, 11);
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = rnd.Next(1, 11);
            }
            PrintNumbers(numbers);
            Console.WriteLine("\n");
            Console.WriteLine("Если хотите развернуть массив, введите \"Да\".");
            string reverseInput = Console.ReadLine();
            if (reverseInput.Trim().ToLower() == "да")
            {
                bool reverse = true;
                PrintNumbers(numbers, reverse);
            }
            else
            {
                Console.WriteLine("Массив не будет развёрнут.");
            }
            Console.ReadLine();
        }

        static void PrintNumbers(int[] array, bool reverse = false)
        {
            if (!reverse)
            {
                foreach (int element in array)
                    Console.Write($"{element} ");
            }
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }
    }
}
