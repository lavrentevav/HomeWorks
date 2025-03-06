using System;

namespace Task_4_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите положительное целое число: ");
            ulong a = Convert.ToUInt64(Console.ReadLine());

            ulong reversedA = 0;

            while (a != 0)
            {
                ulong lastDigit = a % 10;
                reversedA = reversedA * 10 + lastDigit;
                a /= 10;
            }

            Console.WriteLine("Развернутое число: {0}", reversedA);

            Console.ReadKey();
        }

    }
}
