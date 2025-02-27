using System;

namespace Task_3_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            int a = Convert.ToInt32(Console.ReadLine());

            if (a % 2 == 0)
            {
                Console.WriteLine("Число чётное: Да");
            }
            else
            {
                Console.WriteLine("Число чётное: Нет");
            }

            Console.ReadKey();
        }
    }
}
