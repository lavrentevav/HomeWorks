namespace Task_14_1
{
    internal class Program
    {
        static void Main()
        {
            // Создаём список игроков
            List<string> players = new List<string>();

            // Добавляем игроков (Add)
            players.Add("Иванов");
            players.Add("Петров");
            players.Add("Сидоров");

            // Вставляем игрока по индексу (Insert)
            players.Insert(1, "Козлов");

            // Проверяем наличие игрока (Contains)
            bool hasPetrov = players.Contains("Петров");
            Console.WriteLine($"Есть ли игрок Петров в команде? {(hasPetrov ? "Да" : "Нет")}");

            // Удаляем игрока (Remove)
            players.Remove("Сидоров");

            // Получаем индекс игрока (IndexOf)
            int kozlovIndex = players.IndexOf("Козлов");
            Console.WriteLine($"Индекс игрока Козлова: {kozlovIndex}");

            // Сортируем список (Sort)
            players.Sort();

            // Выводим всех игроков
            Console.WriteLine("\nТекущий состав команды:");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {players[i]}");
            }
            Console.WriteLine($"В команде есть игроки? {(players.Count > 0 ? "Да" : "Нет")}");
            // Очищаем список (Clear)
            players.Clear();
            Console.WriteLine($"\nКоличество игроков после очистки: {players.Count}");
            Console.ReadKey();
        }
    }
}
