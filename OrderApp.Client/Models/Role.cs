using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Client.Models
{
    internal class Role:BaseEntity
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
}
