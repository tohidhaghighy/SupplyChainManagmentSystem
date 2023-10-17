using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.Supplier;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _supplierService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var result = _supplierService.GetAll();
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchSupplierCntxDto SearchCntx)
        {
            var totalCount = _supplierService.GetAll().Result.Count();
            var result = _supplierService.FindBy(a => a.Name.Contains(SearchCntx.Name));
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] InsertSupplierDto supplier)
        {
            var result = _supplierService.Insert(new Domain.Model.Supplier()
            {
                Name = supplier.Name,
                Token = supplier.Token,
                IsActive = true
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierDto supplier)
        {
            var brand = _supplierService.FindById(supplier.Id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }

            brand.Result.Name = supplier.Name;
            brand.Result.Token = supplier.Token;

            var result = _supplierService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = _supplierService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = _supplierService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Active/{id}")]
        public async Task<IActionResult> Active(int id, bool active)
        {
            var brand = _supplierService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            brand.Result.IsActive = active;
            var result = _supplierService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
