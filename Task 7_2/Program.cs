using System;

namespace Task_7_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину грани куба:");
            double a = 0;

            try
            {                
                while (a <= 0)
                {
                    a = Convert.ToDouble(Console.ReadLine());
                    if (a <= 0)
                    Console.WriteLine("Введите положительное число:");
                }
                CalcCube(a, out double volumeCube, out double areaCube);
                Console.WriteLine($"Объём куба равен: {volumeCube}");
                Console.WriteLine($"Площадь куба равна: {areaCube}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено не число.");
            }
            
            Console.ReadKey();
        }

        static void CalcCube(double a, out double volumeCube, out double areaCube)
        {
            volumeCube = a * a * a;
            areaCube = a * a * 6;
        }
    }
}
