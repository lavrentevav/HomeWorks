using System;

namespace Task_7_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длины сторон треугольника: ");
            double a = 0;
            double b = 0;
            double c = 0;

            try
            {
                a = Convert.ToDouble(Console.ReadLine());
                b = Convert.ToDouble(Console.ReadLine());
                c = Convert.ToDouble(Console.ReadLine());
                ValidateInput(a, b, c);
                double result = CalcSquare(a, b, c);
                Console.WriteLine($"Площадь треугольника равна: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено не число.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        static void ValidateInput(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 || (a + b) <= c || (a + c) <= b || (b + c) <= a)
                throw new ArgumentException("Треугольника с указанными длинами сторон не существует.");
        }

        static double CalcSquare(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
