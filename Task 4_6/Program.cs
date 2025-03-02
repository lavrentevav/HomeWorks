using System;

namespace Task_4_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            double a = Convert.ToDouble(Console.ReadLine());

            while (a >= 1)
            {
                if (a == 1)
                {
                    Console.WriteLine("Число является степенью двойки.");
                }
                else if (a < 1)
                {
                    Console.WriteLine("Число не является степенью двойки.");
                }
                a /= 2;
            }
            if (a != 0.5)
            {
                Console.WriteLine("Число не является степенью двойки.");
            }

            Console.ReadKey();
        }
    }
}
