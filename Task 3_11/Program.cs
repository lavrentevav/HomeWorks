using System;

namespace Task_3_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите габариты участка: ");
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите габариты 1-го здания: ");
            double p = Convert.ToDouble(Console.ReadLine());
            double q = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите габариты 2-го здания: ");
            double r = Convert.ToDouble(Console.ReadLine());
            double s = Convert.ToDouble(Console.ReadLine());

            if (a <= 0 || b <= 0 || p <= 0 || q <= 0 || r <= 0 || s <= 0)
            {
                Console.WriteLine("Ошибка: Габариты должны быть положительными числами.");
            }
            else
            {
                if (
                (q + s <= a && Math.Max(p, r) <= b) || // Оба здания в стандартной ориентации, друг над другом
                (q + s <= b && Math.Max(p, r) <= a) || // Оба здания в стандартной ориентации, друг над другом (участок повёрнут)

                (p + r <= a && Math.Max(q, s) <= b) || // Оба здания в стандартной ориентации, рядом слева направо
                (p + r <= b && Math.Max(q, s) <= a) || // Оба здания в стандартной ориентации, рядом слева направо (участок повёрнут)

                (q + r <= a && Math.Max(p, s) <= b) || // 1-е здание в стандартной ориентации, 2-е повёрнуто на 90гр, друг над другом
                (q + r <= b && Math.Max(p, s) <= a) || // 1-е здание в стандартной ориентации, 2-е повёрнуто на 90гр, друг над другом (участок повёрнут)

                (p + s <= a && Math.Max(q, r) <= b) || // 1-е здание в стандартной ориентации, 2-е повёрнуто на 90гр, рядом слева направо
                (p + s <= b && Math.Max(q, r) <= a)    // 1-е здание в стандартной ориентации, 2-е повёрнуто на 90гр, рядом слева направо (участок повёрнут)
                )
                {
                    Console.WriteLine("Здания умещаются на участок");
                }
                else
                {
                    Console.WriteLine("Здания не умещаются на участок");
                }
            }

            Console.ReadKey();
        }
    }
}