using System;
using System.Windows.Input;

namespace RevitAPI_Task_8_1_InspectWalls
{
    /// <summary>
    /// Реализация ICommand для привязки команд в представлении.
    /// </summary>
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Событие уведомления об изменении возможности выполнения команды.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Создаёт экземпляр команды с указанным действием и опциональной проверкой возможности выполнения.
        /// </summary>
        /// <param name="execute">Действие, выполняемое командой.</param>
        /// <param name="canExecute">Функция проверки возможности выполнения. Если null, команда всегда доступна.</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Определяет, можно ли выполнить команду с указанным параметром.
        /// </summary>
        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Выполняет действие команды с указанным параметром.
        /// </summary>
        public void Execute(object parameter) => _execute(parameter);
    }
}
