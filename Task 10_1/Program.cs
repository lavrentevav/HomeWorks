using System.Net;

namespace Task_10_1
{
    internal class Program
    {
        static void Main()
        {
            // 1. Демонстрация наследования и переопределения методов
            Building building = new Building("ул. Федерации, 30", 1001.4, 1987);
            building.DisplayInfo();
            Console.WriteLine($"Налог: {building.CalculateTax():F2} руб.");
            Console.WriteLine($"Возраст здания: {building.BuildingAge}");

            Console.WriteLine();

            MultiBuilding multiBuilding = new MultiBuilding ("ул. Федерации, 31", 10021.4, 1973, 5, true);
            multiBuilding.DisplayInfo();
            Console.WriteLine($"Налог: {multiBuilding.CalculateTax():F2} руб.");
            Console.WriteLine($"Средняя площадь на этаж: {multiBuilding.AreaPerFloor:F2} м2");
            Console.WriteLine($"Возраст здания: {multiBuilding.BuildingAge}\n");

            Console.WriteLine("\n--- Upcasting и Downcasting ---");

            // 2. Upcasting - приведение к базовому типу
            Building buildingUpcast = multiBuilding;  // Неявное приведение
            Console.WriteLine("\nПосле upcasting:");
            buildingUpcast.DisplayInfo();  // Вызывается переопределенный метод!
            Console.WriteLine($"Налог: {buildingUpcast.CalculateTax():F2} руб.");            
            Console.WriteLine($"Возраст здания: {buildingUpcast.BuildingAge}");

            // 3. Downcasting - приведение к производному типу
            var buildingAs = buildingUpcast as MultiBuilding;
            if (buildingAs != null)
            {
                Console.WriteLine("\nПосле downcasting с as:");
                buildingAs.DisplayInfo();
                Console.WriteLine($"Налог: {buildingAs.CalculateTax():F2} руб.");
                Console.WriteLine($"Средняя площадь на этаж: {buildingAs.AreaPerFloor:F2} м2");
                Console.WriteLine($"Возраст здания: {buildingAs.BuildingAge}\n");
            }
            Console.ReadKey();
        }
    }
    // Базовый класс
    public class Building
    {
        protected string _address;
        protected double _area;
        protected int _yearBuilt;

        // Конструктор базового класса
        public Building(string address, double area, int yearBuilt)
        {
            _address = address;
            _area = area;
            _yearBuilt = yearBuilt;
        }

        // Виртуальный метод для вычисления налога
        public virtual double CalculateTax()
        {
            return _area * 1000;
        }

        // Метод для вывода информации
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Здание по адресу: {_address}\n" +
                            $"Площадь: {_area:F2} м2\n" +
                            $"Год постройки: {_yearBuilt}");
        }

        public double BuildingAge
        {
            get
            {
                return DateTime.Now.Year - _yearBuilt;
            }
        }
    }

    // Класс-наследник
    public class MultiBuilding : Building
    {
        private int _floors;
        private bool _hasElevator;

        public MultiBuilding(string address, double area, int yearBuilt, int floors, bool hasElevator)
            : base(address, area, yearBuilt)
        {
            _floors = floors;
            _hasElevator = hasElevator;
        }

        // Переопределяем метод расчета налога
        public override double CalculateTax()
        {
            double tax = _area * 1000 * (1 + (_floors - 1) * 0.05);
            if (_hasElevator)
                tax += 5000;
            return tax;
        }

        // Переопределяем вывод информации
        public override void DisplayInfo()
        {
            Console.WriteLine($"Здание по адресу: {_address}\n" +
                            $"Площадь: {_area:F2} м2\n" +
                            $"Год постройки: {_yearBuilt}\n" +
                            $"Число этажей: {_floors}\n" +
                            $"Наличие лифта: {(_hasElevator ? "Да" : "Нет")}");
        }

        public double AreaPerFloor
        {
            get
            {                
                return _area / _floors;
            }
        }
    }
}
