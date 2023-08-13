using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Domain.Entities;
using OrderApp.Services.Interfaces;

namespace OrderApp.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер для работы с товарами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IRepository<Product> _repository;
        public ProductController(IRepository<Product> repository,ILogger <ProductController> logger):base(logger) 
        {
            _repository = repository;
        }
        /// <summary>
        /// Добавить в базу новый товар.
        /// </summary>
        /// <param name="product">Экземпляр товара.</param>
        /// <returns>id добавленного товара.</returns>
        [HttpPost()]
        public async Task<ActionResult<string>> AddProduct(Product product)
        {
            product.Id = Guid.NewGuid().ToString();
            try
            {
                await _repository.AddAsync(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return Ok(product.Id);
        }
        /// <summary>
        /// Изменить данные товара.
        /// </summary>
        /// <param name="product">Отредактированный экземпляр товара.</param>
        [HttpPut()]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                await _repository.UpdateAsync(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return Ok("Данные товара изменены.");
        }
    }
}
