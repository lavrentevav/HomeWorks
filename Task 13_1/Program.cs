namespace Task_13_1
{
    internal class Program
    {
        // Делегат для преобразования
        public delegate int Transformer(int number);

        public static int[] Transform(int[] numbers, Transformer transform)
        {
            int[] result = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = transform(numbers[i]);
            }

            return result;
        }
        public static void Print(int[] numbers)
        {
            foreach (var number in numbers)
                Console.Write("{0,5}", number);
        }
        static void Main(string[] args)
        {
            const int n = 10;
            int[] array = new int[n];
            Random rnd = new Random();

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(-10, 11);
            }
            Print(array);

            Console.WriteLine("\n\nУдвоенный массив:");
            var duplicatedNumbers = Transform(array, n => n * 2);
            Print(duplicatedNumbers);
            Console.WriteLine("\n\nВозведённый в квадрат массив:");
            var squaredNumbers = Transform(array, n => n * n);
            Print(squaredNumbers);
            Console.WriteLine("\n\nМассив модулей:");
            var moduledNumbers = Transform(array, Math.Abs);
            Print(moduledNumbers);

            Console.ReadKey();
        }
    }
}
