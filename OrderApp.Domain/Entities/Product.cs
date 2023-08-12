using System;
using System.Collections.Generic;

namespace OrderApp.Domain.Entities;

/// <summary>
/// Продукт.
/// </summary>
public partial class Product:BaseEntity
{
    /// <summary>
    /// Название продукта.
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Цена продукта.
    /// </summary>
    public double? Price { get; set; }
    /// <summary>
    /// Коллекция позиций заказов, куда был добавлен продукт.
    /// </summary>
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
