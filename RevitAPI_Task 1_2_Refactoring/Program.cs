using System.Runtime.CompilerServices;

namespace RevitAPI_Task_1_2_Refactoring
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
            ShoppingCartService.CalculateAndPrintTotalPrice(itemsWithQuantities);
            Console.ReadKey();
        }
    }
    public class ShoppingCartService
    {
        private const decimal discountValue = 0.05m;

        public static decimal CalculateAndPrintTotalPrice(Dictionary<decimal, int> itemsWithQuantities)
        {
            decimal baseTotal = itemsWithQuantities.Sum(item => item.Key * item.Value);

            decimal discount = baseTotal * discountValue;

            decimal finalPrice = baseTotal - discount;

            Console.WriteLine($"Base: {baseTotal}, Discount: {discount}, Final: {finalPrice}");
            return finalPrice;
        }
    }
}