namespace Task_7_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Массив чисел:");
            Random rnd = new Random();
            int n = rnd.Next(1, 11);
            int[] array = new int[n];            

            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(-100, 101);
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            int result = GetMaxNumber(array);
            Console.WriteLine($"Максимальное число в массиве: {result}");
            Console.ReadKey();
        }

        static int GetMaxNumber(params int[] numbers)
        {
            int maxNumber = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                    maxNumber = numbers[i];                  
            }
            return maxNumber;
        }
    }
}
