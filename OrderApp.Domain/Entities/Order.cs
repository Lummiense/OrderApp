using System;
using System.Collections.Generic;

namespace OrderApp.Domain.Entities;

/// <summary>
/// Заказ.
/// </summary>
public partial class Order:BaseEntity
{ 
    /// <summary>
    /// id покупателя, который делает заказ.
    /// </summary>
    public string? UserId { get; set; }
    /// <summary>
    /// Дата заказа.
    /// </summary>
    public string? OrderDate { get; set; }
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
