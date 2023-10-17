using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.Order;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _orderService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList(int supplierId)
        {
            var result = _orderService.FindBy(a => a.SupplierId == supplierId);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchOrderCntxDto SearchCntx)
        {
            var totalCount = _orderService.FindBy(a => a.SupplierId == SearchCntx.SupplierId).Result.Count();
            var result = _orderService.FindBy(a => (a.Date >= SearchCntx.StartDate || SearchCntx.StartDate == null)
            && (a.Date <= SearchCntx.EndDate || SearchCntx.EndDate == null)
            && (a.OrderNumber.Contains(SearchCntx.OrderNumber) || SearchCntx.OrderNumber==null) && (a.OrderStatus==SearchCntx.OrderStatus || SearchCntx.OrderStatus==0)
            && (a.UserId == SearchCntx.UserId || SearchCntx.UserId == 0) &&
            (a.SupplierId == SearchCntx.SupplierId || SearchCntx.SupplierId == 0));
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take).ToList();
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertOrderDto document)
        {
            try
            {
                var result = _orderService.Insert(new Domain.Model.Order()
                {
                    SupplierId = document.SupplierId,
                    UserId = document.UserId,
                    OrderStatus = document.OrderStatus,
                    OrderNumber = document.OrderNumber,
                    Address = document.Address,
                    Date = System.DateTime.Now,
                    Description = document.Description,
                    DiscountCost = document.DiscountCost,
                    LogenticTypeId = document.LogenticTypeId,
                    PayCost = document.PayCost,
                    PaymentTypeId = document.PaymentTypeId,
                    Tax = document.Tax,
                });
                await Task.CompletedTask;
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = _orderService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = _orderService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Cancel/{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var brand = _orderService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            brand.Result.IsCanceled = true;
            _orderService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(true);
        }

    }
}
