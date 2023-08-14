using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Client.Models
{
    internal class Order : BaseEntity
    {
        /// <summary>
        /// id покупателя, который делает заказ.
        /// </summary>
        public string? UserId { get; set; }
        /// <summary>
        /// Дата заказа.
        /// </summary>
        public DateTime? OrderDate { get; set; }
        /// <summary>
        /// Общая сумма заказа.
        /// </summary>
        public double? TotalOrderPrice { get; set; }
        /// <summary>
        /// Список позиций заказа.
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        /// <summary>
        /// Покупатель, который делает заказ.
        /// </summary>
        public virtual User? User { get; set; }
    }
}
