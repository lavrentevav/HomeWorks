using System;

namespace Task_3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите число b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите число c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            if ((a >= b && a <= c) || (a <= b && a >= c))
            {
                Console.WriteLine("Среднее число: {0}", a);
            }
            else
            {
                if ((b >= a && b <= c) || (b <= a && b >= c))
                {
                    Console.WriteLine("Среднее число: {0}", b);
                }
                else
                {
                    Console.WriteLine("Среднее число: {0}", c);
                }
            }

            Console.ReadKey();
        }
    }
}
