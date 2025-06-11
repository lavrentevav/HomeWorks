namespace Task_11_2
{
    internal class Program
    {
        static void Main()
        {
            // Массив летающих объектов
            IFlyable[] flyingObjects = new IFlyable[]
            {
                new Bird(1000),
                new Airplane(10000, 200),
            };

            // Демонстрация полиморфизма
            foreach (var flyingObject in flyingObjects)
            {
                Console.WriteLine(flyingObject.Fly());
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
    // Интерфейс для летающих объектов
    public interface IFlyable
    {
        string Fly();
        int MaxAltitude { get; }
    }

    // Класс "Птица"
    public class Bird : IFlyable
    {
        public string Name => "Птица";
        public int MaxAltitude { get; private set; }
        public Bird(int maxAltitude)
        {
            MaxAltitude = maxAltitude;
        }
        public string Fly()
        {
            return $"{Name}: \"Лечу на высоте {MaxAltitude} метров\"";
        }
    }
    // Класс "Самолёт"
    public class Airplane : IFlyable
    {
        public string Name => "Самолёт";
        public int MaxAltitude { get; private set; }
        public int CountPassengers { get; private set; }
        public Airplane(int maxAltitude, int countPassengers)
        {
            MaxAltitude = maxAltitude;
            CountPassengers = countPassengers;
        }
        public string Fly()
        {
            return $"{Name}: \"Лечу на высоте {MaxAltitude} метров. Везу {CountPassengers} пассажиров.\"";
        }
    }
}
