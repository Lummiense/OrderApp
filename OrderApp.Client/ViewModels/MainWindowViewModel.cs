using OrderApp.Client.Models;
using OrderApp.Client.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OrderApp.Client.ViewModels
{    
    /// <summary>
    /// ViewModel для главного окна с заказами покупателя.
    /// </summary>
    internal class MainWindowViewModel:ViewModel
    {
        #region Свойства элементов окна
        private string _title ="Заказы";
        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);            
        }
        private string _orders = "Вывести все заказы.";
        /// <summary>
        /// Свойство кнопки вывода списка всех заказов.
        /// </summary>
        public string Orders
        {
            get => _orders;
            set => Set(ref _orders, value);
        }
        private string _newOrder = "Создать новый заказ.";
        /// <summary>
        /// Свойства кнопки создания новый заказов.
        /// </summary>
        public string NewOrder
        {
            get => _newOrder;
            set => Set(ref _newOrder, value);
        }
        #endregion
        private Order _selectedOrder;
        /// <summary>
        /// Получение выбранного заказа.
        /// </summary>
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set => Set(ref _selectedOrder, value);
        }

        public MainWindowViewModel()
        {
            var i = 1;
           /* //var orders = Enumerable.Select();
            var Orders = new ObservableCollection<Order>(orders);*/

            
        }
    }
}

