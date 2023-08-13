using OrderApp.Domain.Entities;
using OrderApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Product> _productRepository;
        public OrderService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Order> CreateOrder(string userId, Dictionary<string, int> items)
        {
            Order order = new Order();
            var id = Guid.NewGuid().ToString();
            order.Id = id;
            order.TotalOrderPrice = 0;
            foreach (var item in items)
            {
                order.UserId = userId;
                var product = await _productRepository.GetByFilterAsync(x => x.Id == item.Key);
                if (product == null)
                {
                    Exception ex = new Exception();                   
                    throw new ArgumentNullException("Товар не найден");
                }

                order.OrderItems.Add(new OrderItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = item.Key,
                    ItemCount = item.Value,
                    OrderId = id,
                    Price = product.Price * item.Value,
                });
                order.TotalOrderPrice += product.Price * item.Value;
            }
            order.OrderDate = DateTime.Now;
            return order;            
        }
    }
}
