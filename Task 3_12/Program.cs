using System;

namespace Task_3_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число от 100 до 999: ");
            int n = Convert.ToInt32(Console.ReadLine());

            string digit3 = "";
            string digit2 = "";
            string digit1 = "";

            if (n < 100 || n > 999)
            {
                Console.WriteLine("Ошибка: Введено некорректное число.");
            }
            else
            {
                switch (n % 100)
                {
                    case 10:
                        digit3 = " десять";
                        break;
                    case 11:
                        digit3 = " одиннадцать";
                        break;
                    case 12:
                        digit3 = " двенадцать";
                        break;
                    case 13:
                        digit3 = " тринадцать";
                        break;
                    case 14:
                        digit3 = " четырнадцать";
                        break;
                    case 15:
                        digit3 = " пятнадцать";
                        break;
                    case 16:
                        digit3 = " шестнадцать";
                        break;
                    case 17:
                        digit3 = " семнадцать";
                        break;
                    case 18:
                        digit3 = " восемнадцать";
                        break;
                    case 19:
                        digit3 = " девятнадцать";
                        break;
                    default:
                        switch (n % 10)
                        {
                            case 1:
                                digit3 = " один";
                                break;
                            case 2:
                                digit3 = " два";
                                break;
                            case 3:
                                digit3 = " три";
                                break;
                            case 4:
                                digit3 = " четыре";
                                break;
                            case 5:
                                digit3 = " пять";
                                break;
                            case 6:
                                digit3 = " шесть";
                                break;
                            case 7:
                                digit3 = " семь";
                                break;
                            case 8:
                                digit3 = " восемь";
                                break;
                            case 9:
                                digit3 = " девять";
                                break;
                        }
                        break;
                }
                switch ((n / 10) % 10)
                {
                    case 2:
                        digit2 = " двадцать";
                        break;
                    case 3:
                        digit2 = " тридцать";
                        break;
                    case 4:
                        digit2 = " сорок";
                        break;
                    case 5:
                        digit2 = " пятьдесят";
                        break;
                    case 6:
                        digit2 = " шестьдесят";
                        break;
                    case 7:
                        digit2 = " семьдесят";
                        break;
                    case 8:
                        digit2 = " восемьдесят";
                        break;
                    case 9:
                        digit2 = " девяносто";
                        break;
                }
                switch (n / 100)
                {
                    case 1:
                        digit1 = "сто";
                        break;
                    case 2:
                        digit1 = "двести";
                        break;
                    case 3:
                        digit1 = "триста";
                        break;
                    case 4:
                        digit1 = "четыреста";
                        break;
                    case 5:
                        digit1 = "пятьсот";
                        break;
                    case 6:
                        digit1 = "шестьсот";
                        break;
                    case 7:
                        digit1 = "семьсот";
                        break;
                    case 8:
                        digit1 = "восемьсот";
                        break;
                    case 9:
                        digit1 = "девятьсот";
                        break;
                }
            }
            Console.WriteLine("{0}{1}{2}", digit1, digit2, digit3);
            Console.ReadKey();
        }
    }
}
