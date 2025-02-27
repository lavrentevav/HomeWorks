namespace Task_2_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            
            a = a+b;
            b = a-b;
            a = a-b;

            Console.WriteLine("После замены: a={0}, b={1}", a, b);
            Console.ReadKey();

        }
    }
}
