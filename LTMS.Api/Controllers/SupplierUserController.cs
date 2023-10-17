using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.SupplierUser;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierUserController : Controller
    {
        ISupplierUserService _supplierUserService;
        public SupplierUserController(ISupplierUserService supplierUserService)
        {
            _supplierUserService = supplierUserService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _supplierUserService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList(int supplierId)
        {
            var result = _supplierUserService.FindBy(a=>a.SupplierId==supplierId);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchSupplierUserCntxDto SearchCntx)
        {
            var totalCount = _supplierUserService.GetAll().Result.Count();
            var result = _supplierUserService.FindBy(a => a.SupplierId == SearchCntx.SupplierId);
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] InsertSupplierUserDto supplier)
        {
            var result = _supplierUserService.Insert(new Domain.Model.SupplierUser()
            {
                SupplierId=supplier.SupplierId,
                UserId=supplier.UserId,
                IsActive = true
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = _supplierUserService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = _supplierUserService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Active/{id}/{active}")]
        public async Task<IActionResult> Active(int id, bool active)
        {
            var brand = _supplierUserService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            brand.Result.IsActive = active;
            var result = _supplierUserService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
