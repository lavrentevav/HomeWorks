namespace Task_5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 10;
            int[] array = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(0, 101);
                Console.Write("{0} ", array[i]);
            }

            int evenOddDifference = 0;
            
            foreach (var a in array)
            {
                if (a % 2 == 0)
                {
                    evenOddDifference++;
                }
                else
                {
                    evenOddDifference--;
                }
            }
            Console.WriteLine();

            if (evenOddDifference > 0)
            {
                Console.WriteLine("В массиве больше чётных чисел");
            }
            else if (evenOddDifference < 0)
            {
                Console.WriteLine("В массиве больше нечётных чисел");
            }
            else
            {
                Console.WriteLine("В массиве равное количество чётных и нечётных чисел");
            }

            Console.ReadKey();
        }
    }
}
