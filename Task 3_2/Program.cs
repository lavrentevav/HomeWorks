namespace Task_3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите число b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите число c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            double max = a;

            if (b > max)
            {
                max = b;
            }
            if (c > max)
            {
                max = c;
            }

            Console.WriteLine("Максимальное число: {0}", max);
            Console.ReadKey();
        }
    }
}
