using Task_13_2;

namespace Task_13_2
{
    // Делегат для события изменения состояния устройства
    public delegate void DeviceStateHandler(string deviceType, string newState, DateTime changeTime);

    public class SmartHomeSystem // Класс, моделирующий умный дом
    {
        public bool LightOn { get; private set; }
        public int CurrentTemperature { get; private set; } = 20;
        public bool DoorLocked { get; private set; } = true;

        public event DeviceStateHandler? DeviceStateChanged;

        // Методы управления светом
        public void TurnOnLight()
        {
            LightOn = true;
            DeviceStateChanged?.Invoke("Свет", "Включен", DateTime.Now);
        }

        public void TurnOffLight()
        {
            LightOn = false;
            DeviceStateChanged?.Invoke("Свет", "Выключен", DateTime.Now);
        }

        // Метод управления термостатом
        public void SetTemperature(int newTemp)
        {
            CurrentTemperature = newTemp;
            DeviceStateChanged?.Invoke("Термостат", $"Температура изменена на {newTemp}°C", DateTime.Now);
        }

        // Методы управления дверью
        public void LockDoor()
        {
            DoorLocked = true;
            DeviceStateChanged?.Invoke("Дверь", "Заблокирована", DateTime.Now);
        }

        public void UnlockDoor()
        {
            DoorLocked = false;
            DeviceStateChanged?.Invoke("Дверь", "Разблокирована", DateTime.Now);
        }

        // Методы для получения текущего состояния
        public bool GetLightState() => LightOn;
        public int GetCurrentTemperature() => CurrentTemperature;
        public bool GetDoorState() => DoorLocked;
    }
}
class Program
{
    static void Main(string[] args)
    {
        var smartHomeSystem = new SmartHomeSystem();

        Console.WriteLine("Начальное состояние:");
        Console.WriteLine($"Свет: {(smartHomeSystem.GetLightState() ? "Вкл" : "Выкл")}");
        Console.WriteLine($"Термостат: {smartHomeSystem.GetCurrentTemperature()}°C");
        Console.WriteLine($"Дверь: {(smartHomeSystem.GetDoorState() ? "Заблокирована" : "Разблокирована")}");
        Console.WriteLine();

        // Подписываемся на событие изменения состояния
        smartHomeSystem.DeviceStateChanged += (deviceType, newState, changeTime) =>
        {
            Console.WriteLine($"[{changeTime:HH:mm:ss}] {deviceType}: {newState}");
        };
        smartHomeSystem.TurnOnLight();
        smartHomeSystem.SetTemperature(23);
        smartHomeSystem.UnlockDoor();
        smartHomeSystem.TurnOffLight();
        smartHomeSystem.LockDoor();

        Console.ReadKey();
    }
}