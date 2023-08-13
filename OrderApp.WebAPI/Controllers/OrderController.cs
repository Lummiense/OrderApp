using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Domain.Entities;
using OrderApp.Services.Interfaces;

namespace OrderApp.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер для работы с заказами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IRepository<Order> _repository;
        private readonly IOrderService _orderService;        
        public OrderController(IRepository<Order> repository,IOrderService orderService, ILogger<OrderController> logger):base(logger)
        {
            _repository = repository;
            _orderService = orderService;           
        }
        /// <summary>
        /// Добавить новый заказ в базу данных.
        /// </summary>
        /// <param name="order">Экземпляр заказа.</param>
        /// <returns>id созданного заказа.</returns>
        [HttpPost("Add")]
        public async Task<ActionResult<string>> CreateNewOrder(string userId,Dictionary<string,int> items)
        {        
            var order =await _orderService.CreateOrder(userId, items);
            try
            {
                await _repository.AddAsync(order);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return Ok(order.Id);
        }
        /// <summary>
        /// Обновить данные заказа.
        /// </summary>
        /// <param name="order">Отредактированный экземпляр заказа.</param>
        [HttpPut()]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            try
            {
                await _repository.UpdateAsync(order);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return Ok("Изменения в заказ внесены.");
        }
        /// <summary>
        /// Удаление заказа из базы данных.
        /// </summary>
        /// <param name="id">id заказа, который нужно удалить.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrder(string id)
        {
            try
            {
                await _repository.RemoveAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return Ok("Заказ удалён.");
        }



    }
}
