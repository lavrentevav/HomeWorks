using System;

namespace Task_3_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            int a = Convert.ToInt32(Console.ReadLine());

            if (a / 100 == 0 && a / 10 > 0)
            {
                Console.WriteLine("Число двузначное: Да");
            }
            else
            {
                Console.WriteLine("Число двузначное: Нет");
            }

            Console.ReadKey();
        }
    }
}
