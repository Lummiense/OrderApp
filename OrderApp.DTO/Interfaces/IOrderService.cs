using OrderApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для сервиса создания заказа.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Формирование заказа.
        /// </summary>
        /// <param name="userId">id покупателя</param>
        /// <param name="items">Коллекция товаров с их колличеством, которые будут добавлены в заказ.</param>
        /// <returns>Сформированный заказ.</returns>
        Task<Order> CreateOrder(string userId, Dictionary<string, int> items);
    }
}
