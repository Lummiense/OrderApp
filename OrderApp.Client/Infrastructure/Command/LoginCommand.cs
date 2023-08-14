using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Client.Infrastructure.Command
{
    /// <summary>
    /// Команда отправки логина и пароля из формы.
    /// </summary>
    internal class LoginCommand : BaseCommand
    {
        public override bool CanExecute(object? parameter) => true;
       

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
