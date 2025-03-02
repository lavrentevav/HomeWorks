using System;

namespace Task_3_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            double a = Convert.ToDouble(Console.ReadLine());

            if (a >= -10 && a <= 10)
            {
                Console.WriteLine("Число в диапазоне [-10,10]: Да");
            }
            else
            {
                Console.WriteLine("Число в диапазоне [-10,10]: Нет");
            }

            Console.ReadKey();
        }
    }
}
