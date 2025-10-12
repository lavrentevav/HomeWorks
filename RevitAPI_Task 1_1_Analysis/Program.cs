using System.Runtime.CompilerServices;

namespace RevitAPI_Task_1_1_Analysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShoppingCartService shoppingCartService = new();

            Dictionary<decimal, int> itemsWithQuantities = [];
            itemsWithQuantities.Add(5, 2);
            itemsWithQuantities.Add(10, 2);
            itemsWithQuantities.Add(15, 2);
            shoppingCartService.CalculateTotalPriceWithQuantities("Regular", itemsWithQuantities);

            Console.ReadKey();
        }
    }
    public class ShoppingCartService
    {
        public decimal CalculateTotalPrice(string customerType, List<decimal> itemPrices)
        {
            decimal baseTotal = 0; //Нарушение KISS: проще написать baseTotal = itemPrices.Sum()
            for (int i = 0; i < itemPrices.Count; i++)
            {
                baseTotal += itemPrices[i];
            }

            decimal discount = 0;

            if (customerType == "Regular") //Нарушение KISS: структуру if-else будет неудобно использовать при увеличении количества категорий покупателей
            {
                discount = baseTotal * 0.05m; // 5%
            }
            else if (customerType == "Premium")
            {
                discount = baseTotal * 0.15m; // 15%
                if (discount > 1000)
                {
                    discount = 1000 + (discount - 1000) * 0.1m;
                }
            }
            else if (customerType == "VIP")
            {
                discount = baseTotal * 0.20m; // 20% Нарушение DRY: формула расчета скидки повторяется трижды. Нужно сделать отдельный метод
            }

            decimal finalPrice = baseTotal - discount;

            Console.WriteLine($"Base: {baseTotal}, Discount: {discount}, Final: {finalPrice}"); //Нарушение KISS: метод называется CalculateTotalPrice, но занимается ещё и выводом информации
            return finalPrice;
        }

        public decimal CalculateTotalPriceWithQuantities(string customerType, Dictionary<decimal, int> itemsWithQuantities) //Нарушение DRY+KISS: если учесть, что на ввод будет всегда подаваться словарь (цена артикула + количество), то можно обойтись одним методом, не преобразовывая в отдельном методе dictionary в list
        {
            List<decimal> allPrices = new List<decimal>();
            foreach (var item in itemsWithQuantities)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    allPrices.Add(item.Key);
                }
            }
            return CalculateTotalPrice(customerType, allPrices);
        }
    } //Нарушения принципа YAGNI выявить не удалось, поскольку на момент анализа мы не знаем ТЗ. Условия рефакторинга (отсутствие необходимости поддержки премиум и вип клиентов) узнаём позже.
}
