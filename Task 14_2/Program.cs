namespace Task_14_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаём словарь для хранения товаров (артикул -> количество)
            Dictionary<string, int> storage = new Dictionary<string, int>
            {
                { "A001", 10 },
                { "B205", 25 },
                { "C307", 15 }
            };

            // Проверка наличия ключа (ContainsKey)
            bool hasB205 = storage.ContainsKey("B205");
            Console.WriteLine($"Есть ли товар с артикулом B205? {(hasB205 ? "Да" : "Нет")}");

            // Изменение значения по ключу (индексатор)
            storage["A001"] = 8;
            
            // Получение значения по ключу (TryGetValue)
            if (storage.TryGetValue("C307", out int C307Quantity))
            {
                Console.WriteLine($"Количество наушников: {C307Quantity}");
            }

            // Изменение значения по ключу (индексатор)
            storage["B205"] += 5;

            // Удаление товара (Remove)
            storage.Remove("C307");

            // Перебор всех элементов
            Console.WriteLine("\nАссортимент товаров:");
            foreach (var product in storage)
            {
                Console.WriteLine($"Артикул: {product.Key}, Количество: {product.Value}");
            }

            // Проверка словаря на пустоту (Count)
            Console.WriteLine($"На складе есть товары? {(storage.Count > 0 ? "Да" : "Нет")}");

            // Очистка словаря (Clear)
            storage.Clear();
            Console.WriteLine($"Количество товаров после ликвидации: {storage.Count}");
            Console.ReadKey();
        }
    }
}
