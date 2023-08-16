using Microsoft.AspNetCore.Mvc;
using OrderApp.Domain.Entities;
using OrderApp.Services.Interfaces;

namespace OrderApp.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователями.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IRepository<User> _repository;       
        public UserController(IRepository<User> repository, ILogger <UserController> logger):base(logger) 
        {
            _repository = repository;
        }
        /// <summary>
        /// Получить данные пользователя по логину.
        /// </summary>
        /// <param name="login">Логин пользователя в системе.</param>
        /// <returns></returns>
        [HttpGet()]
        public async Task <ActionResult<User>> GetUserByLogin(string login)
        {
            var result = await _repository.GetByFilterAsync(x=>x.Login == login);
            return Ok(result);
        }
        /// <summary>
        /// Получить все заказы пользователя по его id.
        /// </summary>
        /// <param name="id">id пользователя.</param>
        /// <returns>Коллекция всех заказов пользователя.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Order>> GetUserOrders(string id)
        {
            var user = await _repository.GetByFilterAsync(x => x.Id == id, x=>"Orders");
            return Ok(user.Orders);
        }

    }
}
