namespace Task_5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 10;
            int[] array = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(-20, 21);
                Console.Write("{0} ", array[i]);
            }

            int positiveNumberCount = 0;
            int negativeNumberCount = 0;
            int zeroCount = 0;

            foreach (var a in array)
            {
                if (a > 0)
                {
                    positiveNumberCount++;
                }
                else if (a < 0)
                {
                    negativeNumberCount++;
                }
                else
                {
                    zeroCount++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Количество положительных чисел в массиве: {0}", positiveNumberCount);
            Console.WriteLine("Количество отрицательных чисел в массиве: {0}", negativeNumberCount);
            Console.WriteLine("Количество нулей в массиве: {0}", zeroCount);
            Console.ReadKey();
        }

    }
}
