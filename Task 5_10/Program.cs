namespace Task_5_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            while (n <= 0)
            {
                Console.WriteLine("Введите количество строк и столбцов: ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 0)
                {
                    Console.WriteLine("Ошибка ввода. Количество должно быть положительным числом.");
                }
                Console.WriteLine();
            }

            int[,] array = new int[n, n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = rnd.Next(0, 2);
                    Console.Write("{0,-2}", array[i, j]);
                }
                Console.WriteLine();
            }

            bool CrossesWin = false;

            for (int i = 0; i < n; i++) //проверка строк
            {
                CrossesWin = true;
                for (int j = 0; j < n; j++)
                {
                    if (array[i, j] != 1)
                    {
                        CrossesWin = false;
                        break;
                    }
                }
                if (CrossesWin)
                {
                    break;
                }
            }

            if (!CrossesWin) //проверка столбцов
            {
                for (int i = 0; i < n; i++)
                {
                    CrossesWin = true;
                    for (int j = 0; j < n; j++)
                    {
                        if (array[j, i] != 1)
                        {
                            CrossesWin = false;
                            break;
                        }
                    }
                    if (CrossesWin)
                    {
                        break;
                    }
                }
            }

            if (!CrossesWin) //проверка 1й диагонали
            {
                CrossesWin = true;
                for (int i = 0, j = 0; i < n; i++, j++)
                {
                    if (array[i, j] != 1)
                    {
                        CrossesWin = false;
                        break;
                    }
                }
            }

            if (!CrossesWin) //проверка 2й диагонали
            {
                CrossesWin = true;
                for (int i = 0, j = n - 1; i < n; i++, j--)
                {
                    if (array[i, j] != 1)
                    {
                        CrossesWin = false;
                        break;
                    }
                }
            }

            Console.WriteLine(CrossesWin ? "Крестики победили." : "Крестики не победили.");

            Console.ReadKey();
        }
    }
}
