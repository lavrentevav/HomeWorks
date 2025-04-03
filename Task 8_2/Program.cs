namespace Task_8_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите возраст:");
            int age;

            try
            {
                age = Convert.ToInt32(Console.ReadLine());
                ValidateAge(age);
                Console.WriteLine($"Возраст находится в допустимом диапазоне.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите целое число.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }           

            Console.ReadKey();
        }

        static void ValidateAge(int age)
        {
            if (age < 0)
                throw new ArgumentException("Возраст не может быть отрицательным.");
            else if (age > 150)
                throw new ArgumentOutOfRangeException("Возраст слишком большой.");
        }
    }
}
