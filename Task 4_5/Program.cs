using System;

namespace Task_4_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = 0;

            while (a < 20 || a > 60)
            {
                Console.WriteLine("Введите число из диапазона [20; 60]: ");
                a = Convert.ToDouble(Console.ReadLine());
                if (a < 20 || a > 60)
                {
                    Console.WriteLine("Ошибка. Введено некорректное число.");
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    Console.WriteLine("Вы справились!");
                }
            }
            Console.ReadKey();
        }
    }
}
