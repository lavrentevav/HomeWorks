using System.Text;

namespace Task_6_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            string age = Console.ReadLine();
            Console.WriteLine("Введите город:");
            string place = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            sb.Append("Имя: ");
            sb.Append(char.ToUpper(name[0]) + name.Substring(1));
            sb.Append(", Возраст: ");
            sb.Append(age);
            sb.Append(", Город: ");
            sb.Append(char.ToUpper(place[0]) + place.Substring(1));

            Console.WriteLine(sb);
            Console.ReadKey();
        }
    }
}
