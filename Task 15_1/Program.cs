using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task_15_1
{
    class Computer
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string ProcessorType { get; set; }
        public double ProcessorFrequency { get; set; }
        public int Ram { get; set; }
        public int Hdd { get; set; }
        public int VideoCardMemory { get; set; }
        public decimal Cost { get; set; }
        public int Stock { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers =
            [
            new Computer(){Id=1, Brand="Dell", ProcessorType="Intel Core i5", ProcessorFrequency=3.2, Ram=8, Hdd=512, VideoCardMemory=4, Cost=750, Stock=15},
            new Computer(){Id=2, Brand="HP", ProcessorType="AMD Ryzen 5", ProcessorFrequency=3.6, Ram=16, Hdd=1000, VideoCardMemory=6, Cost=920, Stock=8},
            new Computer(){Id=3, Brand="Lenovo", ProcessorType="Intel Core i7", ProcessorFrequency=4.0, Ram=32, Hdd=2000, VideoCardMemory=8, Cost=1500, Stock=5},
            new Computer(){Id=4, Brand="Asus", ProcessorType="AMD Ryzen 7", ProcessorFrequency=4.2, Ram=16, Hdd=512, VideoCardMemory=12, Cost=2100, Stock=3},
            new Computer(){Id=5, Brand="Acer", ProcessorType="Intel Core i3", ProcessorFrequency=3.0, Ram=4, Hdd=256, VideoCardMemory=2, Cost=450, Stock=20},
            new Computer(){Id=6, Brand="Apple", ProcessorType="Apple M1", ProcessorFrequency=3.5, Ram=16, Hdd=1000, VideoCardMemory=8, Cost=1800, Stock=7},
            new Computer(){Id=7, Brand="MSI", ProcessorType="Intel Core i9", ProcessorFrequency=4.5, Ram=64, Hdd=2000, VideoCardMemory=16, Cost=3000, Stock=2},
            new Computer(){Id=8, Brand="Samsung", ProcessorType="AMD Ryzen 3", ProcessorFrequency=3.4, Ram=8, Hdd=512, VideoCardMemory=4, Cost=680, Stock=12},
            new Computer(){Id=9, Brand="Sony", ProcessorType="Intel Core i5", ProcessorFrequency=3.8, Ram=16, Hdd=1000, VideoCardMemory=6, Cost=1100, Stock=6},
            new Computer(){Id=10, Brand="Toshiba", ProcessorType="AMD Ryzen 5", ProcessorFrequency=3.7, Ram=32, Hdd=2000, VideoCardMemory=8, Cost=1250, Stock=4}
            ];

            Console.WriteLine("Введите тип процессора:");
            string processorName = Console.ReadLine();
            var computersWithProsessorName = computers
                .Where(c => c.ProcessorType.Equals(processorName, StringComparison.OrdinalIgnoreCase));
            PrintComputers(computersWithProsessorName);

            Console.WriteLine("Введите минимальный объём ОЗУ, ГБ:");
            int minRam = Convert.ToInt32(Console.ReadLine());
            var computersMinRam = computers
                .Where(c => c.Ram >= minRam);
            PrintComputers(computersMinRam);

            Console.WriteLine("Отсортировать компьютеры по увеличению стоимости:");
            var computersSortByCost = computers
                .OrderBy(c => c.Cost);
            PrintComputers(computersSortByCost);

            Console.WriteLine("Сгруппировать компьютеры по типу процессора:");
            var computersGroupByProcessorType = computers
                .GroupBy(c => c.ProcessorType);
            foreach (var group in computersGroupByProcessorType)
            {
                Console.WriteLine($"--- Группа процессоров: {group.Key} ---");
                PrintComputers(group);
            }

            Console.WriteLine("Самый дорогой компьютер:");
            var maxCost = computers
                .Max(c => c.Cost);
            var computerExpensive = computers
                .Where(c => c.Cost == maxCost);
            PrintComputers(computerExpensive);

            Console.WriteLine("Самый дешёвый компьютер:");
            var minCost = computers
                .Min(c => c.Cost);
            var computerCheapest = computers
                .Where(c => c.Cost == minCost);
            PrintComputers(computerCheapest);

            Console.WriteLine("Есть ли компьютеры в количестве не менее 30шт.?");
            var computer30Stock = computers
                .Any(c => c.Stock >= 30);
            Console.WriteLine(computer30Stock ? "Да" : "Нет");


            Console.ReadKey();
        }
        static void PrintComputers(IEnumerable<Computer> computers)
        {
            if (!computers.Any())
            {
                Console.WriteLine("Компьютеры не найдены.");
            }
            else
            {
                if (computers.Count() > 1)
                {
                    Console.WriteLine("Список компьютеров по запросу:");
                }
                foreach (var computer in computers)
                {
                    Console.WriteLine($"- Id: {computer.Id}, " +
                                      $"марка: {computer.Brand}, " +
                                      $"тип процессора: {computer.ProcessorType}, " +
                                      $"частота: {computer.ProcessorFrequency} ГГц, " +
                                      $"ОЗУ: {computer.Ram} ГБ, " +
                                      $"ПЗУ: {computer.Hdd} ГБ, " +
                                      $"видеопамять: {computer.VideoCardMemory} ГБ, " +
                                      $"стоимость: ${computer.Cost}, " +
                                      $"на складе: {computer.Stock} шт.");
                }
            }
            Console.WriteLine("\n");
        }
    }
}
