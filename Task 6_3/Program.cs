namespace Task_6_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите месяц отчёта:");
            string month = Console.ReadLine();
            Console.WriteLine("Введите год отчёта:");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите общую сумму продаж:");
            double money = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите количество проданных товаров:");
            double quantity = Convert.ToDouble(Console.ReadLine());

            double averageCost = money / quantity;

            if (!string.IsNullOrEmpty(month))
            {
                month = char.ToUpper(month[0]) + month.Substring(1);
            }

            string moneyText = money.ToString("N");
            string quantityText = quantity.ToString("N0");
            string averageCostText = averageCost.ToString("N");

            Console.WriteLine("--------------------------------\n" +
                              "Отчёт о продажах за {0} {1}\n" +
                              "--------------------------------\n" +
                              "Общая сумма продаж: {2} р.\n" +
                              "Количество проданных товаров: {3} шт.\n" +
                              "Средняя стоимость товаров: {4} р.\n" +
                              "--------------------------------\n",
                              month, year, moneyText, quantityText, averageCostText);

            Console.ReadKey();
        }
    }
}
