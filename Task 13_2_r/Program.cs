using System.Text;

namespace Task_13_2_r
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Зашифровать текст");
                Console.WriteLine("2. Расшифровать текст");
                Console.WriteLine("3. Выход");

                string choice = Console.ReadLine();

                if (choice == "3")
                    break;
                else if (choice != "1" && choice != "2")
                    Console.WriteLine("Неверный ввод!\n");
                else
                {
                    Console.Write("Введите текст: ");
                    string input = Console.ReadLine();

                    string result = AtbashTransform(input);

                    Console.WriteLine($"Текст после (де)шифровки: {result}\n");
                }                                       
            }
        }

        static string AtbashTransform(string input)
        {
            const string russianCapital = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            const string russianLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            const string latinCapital = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string latinLower = "abcdefghijklmnopqrstuvwxyz";

            StringBuilder result = new(input.Length);

            foreach (char c in input)
            {
                int index;
                if ((index = russianCapital.IndexOf(c)) != -1)
                    result.Append(russianCapital[^(index + 1)]);
                else if ((index = russianLower.IndexOf(c)) != -1)
                    result.Append(russianLower[^(index + 1)]);
                else if ((index = latinCapital.IndexOf(c)) != -1)
                    result.Append(latinCapital[^(index + 1)]);
                else if ((index = latinLower.IndexOf(c)) != -1)
                    result.Append(latinLower[^(index + 1)]);
                else
                    result.Append(c);
            }

            return result.ToString();
        }        
    }
}
