using System;

namespace Task_3_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            double a = Convert.ToDouble(Console.ReadLine());

            if (a <= -10 || a >= 10)
            {
                Console.WriteLine("Число вне диапазона -10<x<10: Да");
            }
            else
            {
                Console.WriteLine("Число вне диапазона -10<x<10: Нет");
            }

            Console.ReadKey();
        }
    }
}
