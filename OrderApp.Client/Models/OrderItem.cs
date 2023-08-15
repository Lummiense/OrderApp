using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Client.Models
{
    internal class OrderItem
    {
        /// <summary>
        /// ID позиции в заказе.
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// id товара.
        /// </summary>
        public string? ProductId { get; set; }
        /// <summary>
        /// id заказа.
        /// </summary>
        public string? OrderId { get; set; }
        /// <summary>
        /// Колличество товаров позиции.
        /// </summary>
        public int? ItemCount { get; set; }
        /// <summary>
        /// Общая стоимость товаров в позиции.
        /// </summary>
        public double? Price { get; set; }
        /// <summary>
        /// Заказ, в котором размещена позиция.
        /// </summary>
        public virtual Order? Order { get; set; }
        /// <summary>
        /// Продукт, который размещается в позиции.
        /// </summary>
        public virtual Product? Product { get; set; }
    }
}
