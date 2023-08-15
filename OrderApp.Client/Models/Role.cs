using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Client.Models
{
    internal class Role
    {
        /// <summary>
        /// ID роли.
        /// </summary>
        public string? Id { get; set; }
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
