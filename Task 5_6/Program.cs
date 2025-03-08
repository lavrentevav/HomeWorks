namespace Task_5_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            int[,] array = new int[n, n];
           
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = i % 2 == 0 && j % 2 == 0 || i % 2 != 0 && j % 2 != 0 ? 1 : 0;
                    Console.Write("{0} ", array[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
