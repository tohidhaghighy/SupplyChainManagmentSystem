using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.OrderDetail;
using Schm.Domain.IService;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : Controller
    {
        IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _orderDetailService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List/{orderId}")]
        public async Task<IActionResult> GetList(int orderId)
        {
            var result = _orderDetailService.FindBy(a => a.OrderId == orderId);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertOrderDetailDto document)
        {
            var result = _orderDetailService.Insert(new Domain.Model.OrderDetail()
            {
                OrderId = document.OrderId,
                Count = document.Count,
                Discount = document.Discount,
                ItemId = document.ItemId,
                Price = document.Price
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = _orderDetailService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = _orderDetailService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
