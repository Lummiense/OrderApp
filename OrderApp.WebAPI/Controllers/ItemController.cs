using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Domain.Entities;
using OrderApp.Services.Interfaces;

namespace OrderApp.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер для работы с позициями заказа.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : BaseController
    {
        private readonly IRepository<OrderItem> _itemsRepository;
        private readonly IRepository<Product> _productsRepository;
        public ItemController(IRepository<OrderItem> itemsRepository, IRepository<Product> productRepository, ILogger<ItemController> logger):base(logger) 
        {
            _itemsRepository = itemsRepository;
            _productsRepository = productRepository;
        }
        /// <summary>
        /// Добавить новую позицию в заказ.
        /// </summary>
        /// <param name="orderId">id заказа.</param>
        /// <param name="productId">id товара.</param>
        /// <param name="productCount">Колличество товара, которое добавляется в заказ.</param>
        /// <returns>id позиции заказа.</returns>
        [HttpPost()]
        public async Task <ActionResult<string>> AddNewItem (string orderId, string productId, int productCount)
        {
            var product = await _productsRepository.GetByFilterAsync(x=>x.Id==productId);
            if(productCount<=0)
            {
                throw new ArgumentException("Колличество товара не может быть отрицательным или равно нулю");
            }
            var item = new OrderItem
            {
                Id=Guid.NewGuid().ToString(),
                ProductId = productId,
                ItemCount = productCount,
                Price = product.Price * productCount,
                OrderId = orderId
            };
            try
            {
                await _itemsRepository.AddAsync(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Добавить позицию не удалось.");
                throw;
            }
            return Ok(item.Id);
        }
    }
}
