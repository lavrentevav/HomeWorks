namespace Task_2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Градусы: ");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.Write("Минуты: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Секунды: ");
            int s = Convert.ToInt32(Console.ReadLine());

            double rad = (d * 60 * 60 + m * 60 + s) * Math.PI / 180 / 3600;

            Console.WriteLine("Число радиан: {0}", rad);
            Console.ReadKey();

        }
    }
}
