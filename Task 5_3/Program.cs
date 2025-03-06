namespace Task_5_3
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
                array[i] = rnd.Next(0, 51);
                Console.Write("{0} ", array[i]);
            }

            int maxElement = array[0];
            int minElement = array[0];
            string maxElementIndexes = "1";
            string minElementIndexes = "1";

            for (int i = 1; i < n; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                    maxElementIndexes = (i + 1).ToString();
                }
                else if (array[i] == maxElement)
                {
                    maxElementIndexes += ", " + (i + 1);
                }
                if (array[i] < minElement)
                {
                    minElement = array[i];
                    minElementIndexes = (i + 1).ToString();
                }
                else if (array[i] == minElement)
                {
                    minElementIndexes += ", " + (i + 1);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Позиция в массиве максимального числа {0}: {1}", maxElement, maxElementIndexes);
            Console.WriteLine("Позиция в массиве минимального числа {0}: {1}", minElement, minElementIndexes);
            Console.ReadKey();
        }
    }
}
