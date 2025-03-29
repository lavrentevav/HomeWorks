namespace Task_8_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите два целых числа:");
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nПроизвести математическую операцию:\n(1 – сложение, 2 – вычитание, 3 – произведение, 4 – частное)");
                int mathOperator = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (mathOperator)
                {
                    case 1:                        
                        Console.WriteLine($"Сумма чисел: {a + b}");
                        break;                        
                    case 2:
                        Console.WriteLine($"Разность чисел: {a - b}");
                        break;
                    case 3:
                        Console.WriteLine($"Произведение чисел: {a * b}");
                        break;
                    case 4:
                        if (b == 0)
                            throw new DivideByZeroException();
                        Console.WriteLine($"Частное чисел: {(double)a / b}");
                        break;
                    default:
                        Console.WriteLine("Введено некорректное обозначение математической операции.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Деление на 0 не имеет смысла.");
            }
            Console.ReadKey();
        }
    }
}
