using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Client.Infrastructure.Command
{
    /// <summary>
    /// Главный класс команды.
    /// </summary>
    internal class LambdaCommand : BaseCommand
    {
        private readonly Action<Object> _execute;
        private readonly Func<object,bool> _canExecute;
        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute=null)
        {
            _execute = execute?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        /// <summary>
        /// Проверка на возможность вызова команды.
        /// </summary>
        public override bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;
        
        /// <summary>
        /// Вызов команды.
        /// </summary>
        public override void Execute(object? parameter)=>_execute(parameter);
        
    }
}
