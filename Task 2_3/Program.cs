using System;
using System.Security.Cryptography;

namespace Task_2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Длина в дюймах: ");
            double inch = Convert.ToDouble(Console.ReadLine());

            double totalLengthMm = inch * 25.4;

            int m = (int)(totalLengthMm / 1000);
            int cm = (int)(totalLengthMm % 1000 / 10);
            double mm = Math.Round(totalLengthMm % 1000 % 10, 1);

            Console.WriteLine("Всего миллиметров: {0}мм", Math.Round(totalLengthMm, 1));
            Console.WriteLine("Длина в метрической системе: {0}м {1}см {2}мм", m, cm, mm);
            Console.ReadKey();

        }
    }
}
