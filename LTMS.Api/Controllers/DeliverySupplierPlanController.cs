using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.DeliverySupplierPlan;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliverySupplierPlanController : Controller
    {
        IDeliverySupplierPlanService _deliverySupplierPlanService;
        public DeliverySupplierPlanController(IDeliverySupplierPlanService deliverySupplierPlanService)
        {
            _deliverySupplierPlanService = deliverySupplierPlanService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _deliverySupplierPlanService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList(int supplierId)
        {
            var result = _deliverySupplierPlanService.FindBy(a => a.SupplierId == supplierId);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchDeliverySupplierPlanCntxDto SearchCntx)
        {
            var totalCount = _deliverySupplierPlanService.GetAll().Result.Count();
            var result = _deliverySupplierPlanService.GetAll();
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take).ToList();
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertDeliverySupplierPlanDto deliverySupplierPlan)
        {
            var result = _deliverySupplierPlanService.Insert(new Domain.Model.DeliverySupplierPlan()
            {
                MaxDayLimitation = deliverySupplierPlan.MaxDayLimitation,
                MinDayLimitation = deliverySupplierPlan.MinDayLimitation,
                OrderCountLimitation = deliverySupplierPlan.OrderCountLimitation,
                RangeOfDailyTime = deliverySupplierPlan.RangeOfDailyTime,
                SupplierId = deliverySupplierPlan.SupplierId,
                IsActive = true
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateDeliverySupplierPlanDto deliverySupplierPlan)
        {
            var plan = _deliverySupplierPlanService.FindById(deliverySupplierPlan.Id);
            if (plan.IsSuccess == false)
            {
                return Ok(plan);
            }

            plan.Result.RangeOfDailyTime = deliverySupplierPlan.RangeOfDailyTime;
            plan.Result.MinDayLimitation = deliverySupplierPlan.MinDayLimitation;
            plan.Result.MaxDayLimitation = deliverySupplierPlan.MaxDayLimitation;
            plan.Result.OrderCountLimitation = deliverySupplierPlan.OrderCountLimitation;

            var result = _deliverySupplierPlanService.Update(plan.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = _deliverySupplierPlanService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = _deliverySupplierPlanService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Active/{id}")]
        public async Task<IActionResult> Active(int id, bool active)
        {
            var brand = _deliverySupplierPlanService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            brand.Result.IsActive = active;
            var result = _deliverySupplierPlanService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
