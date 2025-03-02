using System;

namespace Task_4_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;

            while (a <= 0 || b >= 0)
            {
                Console.WriteLine("Введите положительное целочисленное основание степени: ");
                a = Convert.ToInt32(Console.ReadLine());
                if (a <= 0)
                {
                    Console.WriteLine("Ошибка ввода. Число не соответствует условию задачи.");
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine("Введите отрицательный целочисленный показатель степени: ");
                b = Convert.ToInt32(Console.ReadLine());
                if (b >= 0)
                {
                    Console.WriteLine("Ошибка ввода. Число не соответствуют условию задачи.");
                    Console.WriteLine();
                }
            }

            b = -b;
            double f = 1;

            for (int i = 1; i <= b; i++)
            {
                f *= a;
            }
            f = 1.0 / f;

            Console.WriteLine("Результат возведения в степень равен: {0}", f);
            Console.ReadKey();
        }
    }
}
