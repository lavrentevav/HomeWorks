using System;

namespace Task_3_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество построенных домов: ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n % 100 >= 11 && n % 100 <= 14)
            {
                Console.WriteLine("Мы построили {0} домов", n);
            }
            else
                switch (n % 10)
                {
                    case 1:
                        Console.WriteLine("Мы построили {0} дом", n);
                        break;
                    case 2:
                    case 3:
                    case 4:
                        Console.WriteLine("Мы построили {0} дома", n);
                        break;
                    default:
                        Console.WriteLine("Мы построили {0} домов", n);
                        break;
                }

            Console.ReadKey();
        }
    }
}
