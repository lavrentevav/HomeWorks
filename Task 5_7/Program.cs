namespace Task_5_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 10;
            const int m = 5;
            int[,] array = new int[n, m];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                int max = 0;
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = rnd.Next(0, 11);
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }
                    Console.Write("{0,-4}", array[i, j]);
                }
                Console.WriteLine("  Max:{0,-6}", max);
            }
            Console.ReadKey();
        }
    }
}
