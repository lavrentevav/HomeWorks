using System.Text.RegularExpressions;

namespace Task_6_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] test =
            {
                "+7(917)456-02-05", "+7917456-02-05" , "+7-917-456-02-05", "+79174560205", "+7(917)456-02-0", "(917)45-02-02"
            };
            
            Regex regex = new Regex(@"^\+\d{1}\(\d{3}\)\d{3}-\d{2}-\d{2}$");

            foreach (var str in test)
            {
                if (regex.IsMatch(str))
                    Console.WriteLine("\"{0}\" - подходит", str);
                else
                    Console.WriteLine("\"{0}\" - не подходит", str);
            }
            
            Console.ReadKey();
        }
    }
}
