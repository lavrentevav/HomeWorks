using System;

namespace Task_4_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число: ");
            long a = Convert.ToInt64(Console.ReadLine());

            int i = 0;

            while (Math.Abs(a) != 0)
            {
                a /= 10;
                i++;
            }

            if (i == 0)
            {
                i = 1;
            }
            Console.WriteLine("Количество цифр в числе: {0}", i);

            Console.ReadKey();
        }
    }
}
