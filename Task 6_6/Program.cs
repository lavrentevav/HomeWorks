using System.Text.RegularExpressions;

namespace Task_6_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "";
            Regex regex = new Regex(@"^(?=.*\d)(?=.*[A-ZА-ЯЁ])(?=.*[a-zа-яё])(?=.*[!#;%:?*]).{14,}$");

            Console.WriteLine("Введите пароль. Пароль должен состоять из 14 символов, содержать минимум одну цифру, прописную букву, строчную букву и специальный символ:");
            while (!regex.IsMatch(password))
            {
                password = Console.ReadLine();
                if (!regex.IsMatch(password))
                {
                    Console.WriteLine("Пароль слишком простой. Введите пароль, удовлетворяющий условиям:");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Пароль принят.");
                }
            }

            Console.ReadKey();
        }
    }
}
