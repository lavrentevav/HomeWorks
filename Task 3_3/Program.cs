namespace Task_3_3
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
            Console.Write("Введите число c: ");
            double d = Convert.ToDouble(Console.ReadLine());

            double max = a;

            if (b > max)
            {
                max = b;
            }
            if (c > max)
            {
                max = c;
            }
            if (d > max)
            {
                max = d;
            }

            Console.WriteLine("Максимальное число: {0}", max);
            Console.ReadKey();
        }
    }
}
