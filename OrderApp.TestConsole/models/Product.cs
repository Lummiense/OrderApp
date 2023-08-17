using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.TestConsole.models
{
    internal class Product
    {
        /// <summary>
        /// ID товара.
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// Название продукта.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Цена продукта.
        /// </summary>
        public double? Price { get; set; }
    }
}
