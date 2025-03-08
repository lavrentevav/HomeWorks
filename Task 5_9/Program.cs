namespace Task_5_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int m = 0;

            while (n <= 0 || m <= 0)
            {
                Console.WriteLine("Введите количество строк: ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 0)
                {
                    Console.WriteLine("Ошибка ввода. Количество строк должно быть положительным числом.");
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine("Введите количество столбцов: ");
                m = Convert.ToInt32(Console.ReadLine());
                if (m <= 0)
                {
                    Console.WriteLine("Ошибка ввода. Количество столбцов должно быть положительным числом.");
                    Console.WriteLine();
                }
            }

            int[,] array = new int[n, m];
            int value = 1;
            int topLineIndex = 0;
            int rightLineIndex = m - 1;
            int bottomLineIndex = n - 1;
            int leftLineIndex = 0;

            while (value <= n * m)
            {
                for (int i = leftLineIndex; i <= rightLineIndex; i++)
                {
                    array[topLineIndex, i] = value++;
                }
                topLineIndex++;
                if (topLineIndex > bottomLineIndex)
                {
                    break;
                }

                for (int i = topLineIndex; i <= bottomLineIndex; i++)
                {
                    array[i, rightLineIndex] = value++;
                }
                rightLineIndex--;
                if (rightLineIndex < leftLineIndex)
                {
                    break;
                }

                for (int i = rightLineIndex; i >= leftLineIndex; i--)
                {
                    array[bottomLineIndex, i] = value++;
                }
                bottomLineIndex--;

                for (int i = bottomLineIndex; i >= topLineIndex; i--)
                {
                    array[i, leftLineIndex] = value++;
                }
                leftLineIndex++;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,-6}", array[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
