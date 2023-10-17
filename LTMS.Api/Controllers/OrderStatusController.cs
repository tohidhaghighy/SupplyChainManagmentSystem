using Microsoft.AspNetCore.Mvc;
using Schm.Domain.IService;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : Controller
    {
        IOrderStatusService _orderStatusService;
        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _orderStatusService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var result = _orderStatusService.GetAll();
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
