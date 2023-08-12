using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderApp.WebAPI.Controllers
{    
    /// <summary>
    /// Базовая конфигурация контроллера.
    /// </summary>
    public class BaseController : ControllerBase
    {
        protected ILogger _logger;
        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}
