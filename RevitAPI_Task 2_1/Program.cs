using Microsoft.Extensions.DependencyInjection;
using System;

namespace RevitAPI_Task_2_1
{
    public interface INotificationSender
    {
        void Send(string recipient, string message);
    }

    public class EmailSender : INotificationSender
    {
        public void Send(string recipient, string message)
        {
            // Симуляция отправки email
            Console.WriteLine($"Email для {recipient}: {message}");
        }
    }

    public class SmsSender : INotificationSender
    {
        public void Send(string recipient, string message)
        {
            // Симуляция отправки SMS
            Console.WriteLine($"SMS для {recipient}: {message}");
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("log.txt", message);
        }
    }

    public class NotificationService(INotificationSender sender, ILogger logger)
    {
        private readonly INotificationSender _sender = sender;
        private readonly ILogger _logger = logger;

        public void SendNotification(string message, string recipient)
        {
            // Логика подготовки уведомления
            string formattedMessage = $"Уведомление: {message}";

            // Отправка уведомления
            _sender.Send(recipient, formattedMessage);

            // Логирование
            _logger.Log($"Отправлено уведомление для {recipient}");
        }
    }

    class Program
    {
        static void Main()
        {
            var message = "Ваш заказ готов";
            var recipient = "user@example.com";
            var notificationType = GetNotificationType();

            ServiceCollection services = new();

            services.AddSingleton<ILogger, FileLogger>();

            if (notificationType == "2")
            {
                services.AddSingleton<INotificationSender, SmsSender>();
            }
            else
            {
                services.AddSingleton<INotificationSender, EmailSender>();
            }

            services.AddSingleton<NotificationService>();

            ServiceProvider provider = services.BuildServiceProvider();

            var notificationService = provider.GetRequiredService<NotificationService>();

            notificationService.SendNotification(message, recipient);
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }
        private static string GetNotificationType()
        {
            var isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Выберите тип уведомления:");
                Console.WriteLine("1 - Email");
                Console.WriteLine("2 - SMS");
                Console.Write("Ваш выбор: ");

                var input = Console.ReadLine();
                if (input == "1" || input == "2")
                {
                    isValid = true;
                    return input;
                }
                Console.WriteLine("Введите корректный тип уведомления (1 или 2)");
            }
            return "1";
        }
    }
}
