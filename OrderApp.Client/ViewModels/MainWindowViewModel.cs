using OrderApp.Client.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Client.ViewModels
{
    /// <summary>
    /// ViewModel для главного окна.
    /// </summary>
    internal class MainWindowViewModel:ViewModel
    {
        private string _title ="Заказы";
        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);            
        }
    }
}

