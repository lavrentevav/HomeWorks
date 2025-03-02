using System;

namespace Task_4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            while (n <= 0)
            {
                Console.WriteLine("Введите натуральное число: ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 0)
                {
                    Console.WriteLine("Ошибка ввода. Число не соответствует условию задачи.");
                    Console.WriteLine();
                }
            }

            double f = 0;

            for (int i = 1; i <= n; i++)
            {
                f += 1.0 / i;
            }

            Console.WriteLine("Результат суммирования равен: {0}", f);
            Console.ReadKey();
        }
    }
}
