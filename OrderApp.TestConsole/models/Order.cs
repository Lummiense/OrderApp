using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.TestConsole.models
{
    internal class Order
    {
        /// <summary>
        /// id покупателя, который делает заказ.
        /// </summary>
        public string? UserId { get; set; }
        /// <summary>
        /// Словарь для ввода id товара и его количества.
        /// </summary>
        public Dictionary<string, int> items { get; set; }
    }
}
