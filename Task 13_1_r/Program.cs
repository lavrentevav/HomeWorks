namespace Task_13_1_r
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new();
            int secretNumber = rnd.Next(1, 101);
            int attempts = 0;
            int guess = 0;

            Console.WriteLine("Я хочу сыграть с тобой в одну игру...\n" +
                "Я загадал целое число от 1 до 100. Попробуй угадать!\n");

            while (guess != secretNumber)
            {
                Console.Write($"Попытка #{attempts + 1}. Введи свою догадку: ");

                try
                {
                    guess = Convert.ToInt32(Console.ReadLine());

                    if (guess < 1 || guess > 100)
                        throw new ArgumentOutOfRangeException();

                    attempts++;

                    if (guess < secretNumber)
                    {
                        Console.WriteLine("Моё число больше!\n");
                    }
                    else if (guess > secretNumber)
                    {
                        Console.WriteLine("Моё число меньше!\n");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Это не целое число! Сделаем вид, что ты случайно.\n");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Число должно быть от 1 до 100! Сделаем вид, что ты случайно.\n");
                }
            }

            Console.WriteLine($"\nПоздравляю! Ты угадал(а) число {secretNumber} за {attempts} попыток.");

            Console.ReadKey();
        }
    }
}
