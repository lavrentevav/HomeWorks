namespace Task_2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите четырёхзначное число: ");
            int n1 = Convert.ToInt32(Console.ReadLine());

            int a = n1 / 1000;
            int b = (n1 / 100) % 10;
            int c = (n1 / 10) % 10;
            int d = n1 % 10;

            int n2 = a * 1000 + d * 100 + c * 10 + b;

            Console.WriteLine("Цифры оригинального числа: {0},{1},{2},{3}", a, b, c, d);
            Console.WriteLine("Преобразованное число: {0}", n2);
            Console.ReadKey();
        }
    }
}
