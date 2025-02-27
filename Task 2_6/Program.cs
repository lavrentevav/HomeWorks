namespace Task_2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину трубы в метрах: ");
            double l1 = Convert.ToDouble(Console.ReadLine());

            double l2 = Math.Round(l1 * 2, MidpointRounding.AwayFromZero) / 2;

            Console.WriteLine("Длина, округленная до 0,5: {0}", l2);
            Console.ReadKey();
        }
    }
}
