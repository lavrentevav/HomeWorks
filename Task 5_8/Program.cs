namespace Task_5_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            int[] array = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(0, 11);
                Console.Write("{0} ", array[i]);
            }

            int max1Element = 0;
            int max2Element = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i] > max1Element)
                {
                    max2Element = max1Element;
                    max1Element = array[i];
                }
                else if (array[i] > max2Element)
                {
                    max2Element = array[i];
                }
            }
            Console.WriteLine();
            Console.WriteLine("Два наибольших числа в массиве: {0}, {1}", max1Element, max2Element);
            Console.ReadKey();
        }
    }
}
