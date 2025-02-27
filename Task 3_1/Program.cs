namespace Task_3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите число b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            if (a > b)
            {
                Console.WriteLine("a > b");
            }
            else
            {
                if (a == b)
                {
                    Console.WriteLine("a = b");
                }
                else
                {
                    Console.WriteLine("a < b");
                }

            }

            Console.ReadKey();
        }
    }
}
