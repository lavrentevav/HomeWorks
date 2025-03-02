using System;

namespace Task_3_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            int a = Convert.ToInt32(Console.ReadLine());

            if (a % 10 == 0)
            {
                Console.WriteLine("Число оканчивается на 0: Да");
            }
            else
            {
                Console.WriteLine("Число оканчивается на 0: Нет");
            }

            Console.ReadKey();
        }
    }
}
