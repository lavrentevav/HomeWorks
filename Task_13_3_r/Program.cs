using System.Xml.Linq;

namespace Task_13_3_r
{
    // Базовый класс персонажа
    public abstract class Character
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public bool IsAlive => Health > 0;

        protected Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public virtual void Attack(Character target)
        {
            target.Health -= Damage;
            Console.WriteLine($"{Name} наносит персонажу {target.Name} урон {Damage}HP!");
        }
    }

    // Класс игрока
    public class Player : Character
    {
        public int HealthPotions { get; private set; } = 3;
        private const int PotionHealAmount = 10;
        private const int PlayerDamage = 5;
        private const int MaxHealth = 10;

        public Player(string name) : base(name, MaxHealth, PlayerDamage) { }

        public void UseHealthPotion()
        {
            var initialHealth = Health;
            Health = Math.Min(Health + PotionHealAmount, MaxHealth);
            HealthPotions--;
            Console.WriteLine($"{Name} использует зелье здоровья и восстанавливает {Health - initialHealth} HP!");
        }
    }

    // Класс монстра
    public class Monster : Character
    {
        private static readonly Random rnd = new();

        public Monster() : base("Злобный Гоблин", 20, 0) { }

        public override void Attack(Character target)
        {
            Damage = rnd.Next(1, 7);
            base.Attack(target);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("=== Игра 'Битва с монстром' ===");
                Console.WriteLine("Введите имя вашего персонажа:");
                string playerName;
                while (string.IsNullOrWhiteSpace(playerName = Console.ReadLine()))
                {
                    Console.WriteLine("Имя не может быть пустым! Попробуйте снова:");
                }

                Player player = new(playerName);
                Monster monster = new();

                Console.WriteLine($"Битва начинается! {player.Name} против {monster.Name}!");

                while (player.IsAlive && monster.IsAlive)
                {
                    // Ход игрока
                    Console.WriteLine("\nВаш ход:");
                    Console.WriteLine("1 - Атаковать / 2 - Использовать зелье здоровья");

                    string choice = Console.ReadLine();
                    if (choice != "1" && choice != "2")
                    {
                        Console.WriteLine("Неверный ввод!\n");
                        continue;
                    }
                    switch (choice)
                    {
                        case "1":
                            player.Attack(monster);
                            break;
                        case "2":
                            if (player.HealthPotions <= 0)
                            {
                                Console.WriteLine("Зелья кончились! Вам остаётся только атаковать!");
                                player.Attack(monster);
                                break;
                            }
                            else
                            {
                                player.UseHealthPotion();
                                break;
                            }
                    }

                    if (!monster.IsAlive) break;

                    // Ход монстра
                    Console.WriteLine($"\nХод {monster.Name}...");
                    Thread.Sleep(2000);
                    monster.Attack(player);

                    if (!player.IsAlive) break;

                    // Текущий статус
                    Console.WriteLine("\nТекущее состояние:");
                    Console.WriteLine($"{player.Name}: {player.Health} HP");
                    Console.WriteLine($"{monster.Name}: {monster.Health} HP");
                    Console.WriteLine($"Зелья здоровья: {player.HealthPotions}");
                }

                // Результат битвы
                Console.WriteLine("\n=== Битва окончена! ===");
                if (player.IsAlive)
                {
                    Console.WriteLine($"Поздравляем! {player.Name} победил {monster.Name}!");
                }
                else
                {
                    Console.WriteLine($"{monster.Name} победил {player.Name}...");
                }

                Console.WriteLine("\nХотите сыграть еще раз? (y/n)");
            }
            while (Console.ReadLine().ToLower() == "y");
        }
    }
}
