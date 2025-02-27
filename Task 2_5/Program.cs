namespace Task_2_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину в метрах: ");
            double l1 = Convert.ToDouble(Console.ReadLine());

            double l2 = Math.Ceiling(l1);
            
            Console.WriteLine("Длина, округленная до целого в бОльшую сторону: {0}", l2);
            Console.ReadKey();
        }
    }
}
