namespace Task_11_1
{
    internal class Program
    {
        static void Main()
        {
            // Массив животных
            Animal[] animals = new Animal[]
            {
                new Dog(),
                new Cat(),
            };

            // Демонстрация полиморфизма
            foreach (var animal in animals)
                animal.ShowInfo();

            Console.ReadKey();
        }
    }

    public abstract class Animal
    {
        // Абстрактное свойство для имени
        public abstract string Name { get; }

        // Абстрактный метод
        public abstract string Say();

        // Обычный (не абстрактный) метод
        public void ShowInfo()
        {
            Console.WriteLine($"{Name} говорит: \"{Say()}\"");
            Console.WriteLine();
        }
    }
    // Класс "Собака"
    public class Dog : Animal
    {
        public override string Name => "Собака";

        public override string Say()
        {
            return "Гав!";
        }
    }

    // Класс "Кошка"
    public class Cat : Animal
    {
        public override string Name => "Кошка";

        public override string Say()
        {
            return "Мяу!";
        }
    }
}
