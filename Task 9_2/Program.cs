using System;
using System.Security.Principal;

namespace Task_9_2
{
    internal class Program
    {
        static void Main()
        {
            var account = new BankAccount(1850.23m);
            var account1 = new BankAccount(123.12m);

            Console.WriteLine($"Средств на счёте #{account.AccountNumber}: {account} руб.");
            Console.WriteLine($"Средств на счёте #{account1.AccountNumber}: {account1} руб.");
            BankAccount.ShowTotalAccounts();
            Console.WriteLine();

            try
            {
                Console.Write($"Пополнить счет #{account.AccountNumber} на (руб.): ");
                decimal deposit = Convert.ToDecimal(Console.ReadLine());

                account.Deposit(deposit);

                Console.Write($"Снять со счёта #{account1.AccountNumber} (руб.): ");
                decimal withdraw = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("\n");

                account1.Withdraw(withdraw);
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\n");
            }

            Console.WriteLine($"Средств на счёте #{account.AccountNumber}: {account} руб.");
            Console.WriteLine($"Средств на счёте #{account1.AccountNumber}: {account1} руб.");


            Console.ReadKey();
        }
        public class BankAccount
        {
            private static int _totalAccounts = 0;

            public int AccountNumber { get; }
            public decimal Balance { get; private set; }

            public BankAccount(decimal balance)
            {
                Balance = balance;
                Random rnd = new Random();
                AccountNumber = rnd.Next(1000, 10000);
                _totalAccounts++;
            }

            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                    throw new ArgumentException("Сумма пополнения должна быть положительной");

                Balance += amount;
            }
            public void Withdraw(decimal amount)
            {
                if (amount <= 0)
                    throw new ArgumentException("Сумма снятия должна быть положительной");

                if (amount > Balance)
                    throw new ArgumentException($"Недостаточно средств на счете #{AccountNumber}");

                Balance -= amount;
            }

            public static void ShowTotalAccounts()
            {
                Console.WriteLine($"Всего счетов создано: {_totalAccounts}");
            }

            public override string ToString()
            {
                return $"{Balance:N2}";
            }
        }
    }
}
