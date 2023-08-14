using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrderApp.Client.Infrastructure.Command
{
    /// <summary>
    /// Базовая команда.
    /// </summary>
    internal abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        /// <summary>
        /// Проверка возможности вызова команды.
        /// </summary>       
        public abstract bool CanExecute(object? parameter);
        /// <summary>
        /// Основная логика команды.
        /// </summary>
        public abstract void Execute(object? parameter);
    }
}
