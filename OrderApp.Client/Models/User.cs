using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Client.Models
{
    internal class User:BaseEntity
    {
        /// <summary>
        /// id роли пользователя.
        /// </summary>
        public string? RoleId { get; set; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Логин пользователя в системе.
        /// </summary>
        public string? Login { get; set; }
        /// <summary>
        /// Пароль от учетной записи в системе.
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// Коллекция заказов пользователя в системе.
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        /// <summary>
        /// Роль пользователя в системе.
        /// </summary>
        public virtual Role? Role { get; set; }
    }
}
