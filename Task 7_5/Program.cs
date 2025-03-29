namespace Task_7_5
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Введите два вещественных числа:");
                double a = Convert.ToDouble(Console.ReadLine());                
                double b = Convert.ToDouble(Console.ReadLine());

                double result1 = MultiplyNumbers(a, b);
                Console.WriteLine($"Произведение вещественных чисел равно: {result1}");

                Console.WriteLine("\nВведите два целых числа:");
                int c = Convert.ToInt32(Console.ReadLine());
                int d = Convert.ToInt32(Console.ReadLine());

                int result2 = MultiplyNumbers(c, d);
                Console.WriteLine($"Произведение целых чисел равно: {result2}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение.");
            }            

            Console.ReadKey();
        }

        static int MultiplyNumbers(int number1, int number2)
        {
            return number1 * number2;
        }

        static double MultiplyNumbers(double number1, double number2)
        {
            return number1 * number2;
        }
    }
}
