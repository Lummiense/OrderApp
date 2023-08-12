using System;
using System.Collections.Generic;

namespace OrderApp.Domain.Entities;

/// <summary>
/// Роль пользователя в системе.
/// </summary>
public partial class Role:BaseEntity
{
    /// <summary>
    /// Название роли.
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Коллекция пользователей системы, которым присвоена данная роль.
    /// </summary>
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
