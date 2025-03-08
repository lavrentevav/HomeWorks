namespace Task_5_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оригинальный массив:");
            const int n = 10;
            int[] array = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(-50, 51);
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Отсортированный массив:");

            for (int i = 0; i < n / 2 - 1; i++)
            {
                for (int j = i + 1; j < n / 2; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            for (int i = n - 1; i > n / 2; i--)
            {
                for (int j = i - 1; j > n / 2 - 1; j--)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.ReadKey();
        }
    }
}
