namespace Task_16_1
{
    internal class Program
    {
        static int[] GenerateArrayTask(int size)
        {
            Console.WriteLine("Генерация массива...");
            var random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 11);
                Console.Write($"{array[i]} ");
                Thread.Sleep(1000);
            }

            Console.WriteLine("\nМассив сгенерирован!");
            return array;
        }

        static double CalculateAverageTask(int[] array)
        {
            Console.WriteLine("Вычисление среднего арифметического...");
            int sum = 0;

            foreach (int num in array)
            {
                sum += num;
                Thread.Sleep(500);
            }

            return (double)sum / array.Length;
        }

        static async Task Main(string[] args)
        {
            //Демонстрация ContinueWith
            Console.WriteLine("Демонстрация '.ContinueWith':");
            Task<int[]> task1 = Task.Run(() => GenerateArrayTask(10));
            Task<double> task2 = task1.ContinueWith(t =>
            {
                int[] array = t.Result;
                return CalculateAverageTask(array);
            });
            Console.WriteLine($"{task2.Result:G2}\n");

            //Демонстрация async/await

            Console.WriteLine("Демонстрация 'async/await':");
            
            int[] array = await Task.Run(() => GenerateArrayTask(10));            
            double average = await Task.Run(() => CalculateAverageTask(array));
            Console.WriteLine($"{average:G2}");
            
            Console.ReadKey();
        }
    }
}
