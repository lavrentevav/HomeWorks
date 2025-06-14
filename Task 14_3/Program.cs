namespace Task_14_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание HashSet для хранения email подписчиков
            HashSet<string> subscribers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // Добавление элементов (Add)
            subscribers.Add("alice@example.com");
            subscribers.Add("bob@example.com");
            subscribers.Add("charlie@example.com");

            // Попытка добавить дубликат
            bool addedDuplicate = subscribers.Add("Alice@example.com");
            Console.WriteLine($"Удалось добавить 'Alice@example.com'? {(addedDuplicate ? "Да" : "Нет (дубликат)")}");

            Console.WriteLine($"Есть ли подписчики в системе? {(subscribers.Count > 0 ? "Да" : "Нет")}");

            Console.WriteLine($"\nТекущие подписчики:");
            Print(subscribers);

            // Создание второго множества для операций
            HashSet<string> newSubscribers = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Bob@example.com", "dave@example.com", "Eve@example.com" };

            Console.WriteLine($"\nНовые подписчики:");
            Print(newSubscribers);

            // Пересечение множеств (IntersectWith)
            HashSet<string> commonSubscribers = new HashSet<string>(subscribers, StringComparer.OrdinalIgnoreCase);
            commonSubscribers.IntersectWith(newSubscribers);
            Console.WriteLine("\nОбщие подписчики:");
            Print(commonSubscribers);

            // Объединение множеств (UnionWith)
            subscribers.UnionWith(newSubscribers);
            Console.WriteLine("\nВсе подписчики после объединения:");
            Print(subscribers);

            // Удаление элемента (Remove)
            subscribers.Remove("Charlie@example.com");

            // Количество элементов (Count)
            Console.WriteLine($"\nВсего подписчиков в системе после удаления 'Charlie@example.com': {subscribers.Count}");

            // Проверка на подмножество (IsSubsetOf)
            HashSet<string> testSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "BOB@example.com", "Dave@example.com" };
            Console.WriteLine($"\n'BOB@example.com' и 'Dave@example.com' являются подписчиками? {(testSet.IsSubsetOf(subscribers) ? "Да" : "Нет")}");

            // Очистка коллекции (Clear)
            subscribers.Clear();
            Console.WriteLine($"\nКоличество подписчиков после очистки: {subscribers.Count}");

            Console.ReadKey();
        }
        public static void Print<T>(HashSet<T> hashset)
        {
            foreach (var item in hashset)
                Console.WriteLine($"- {item}");
        }
    }
}
