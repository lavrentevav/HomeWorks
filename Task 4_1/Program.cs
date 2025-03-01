using System;

namespace Task_43_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            while (n <= 0 || n >= 21)
            {
                Console.WriteLine("Введите натуральное число: ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 0)
                {
                    Console.WriteLine("Ошибка ввода.");
                    Console.WriteLine();
                }
                else
                {
                    if (n >= 21)
                    {
                        Console.WriteLine("Ошибка. Переполнение переменной при вычислении факториала");
                        Console.WriteLine();
                    }
                }
            }

            ulong f = 1;

            for (uint i = 1; i <= n; i++)
            {
                f *= i;                              
            }
            
            Console.WriteLine("Факториал числа {0} равен: {1}", n, f);           
            Console.ReadKey();
        }
    }
}
