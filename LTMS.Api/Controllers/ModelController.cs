using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schm.Api.Infrastructure.Common;
using Schm.Core.DTO.Request.Category;
using Schm.Core.DTO.Request.Model;
using Schm.Core.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : Controller
    {
        IModelTypeService _modelTypeService;
        public ModelController(IModelTypeService modelTypeService)
        {
            _modelTypeService = modelTypeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _modelTypeService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var result = _modelTypeService.GetAll();
            await Task.CompletedTask;
            return Ok(result);
        }
        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchModelCntx SearchCntx)
        {
            var totalCount = _modelTypeService.GetAll().Result.Count();
            var result = _modelTypeService.FindBy(a => a.Title.Contains(SearchCntx.Title) && (SearchCntx.BrandTypeId==0 || a.BrandTypeId==SearchCntx.BrandTypeId));
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertModelTypeDto model)
        {
            var result = _modelTypeService.Insert(new Domain.Model.ModelType()
            {
                Title = model.Title,
                IsActive = true,
                BrandTypeId = model.BrandTypeId,
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateModelTypeDto modeltype)
        {
            var brand = _modelTypeService.FindById(modeltype.Id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }

            brand.Result.Title = modeltype.Title;

            var result = _modelTypeService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = _modelTypeService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = _modelTypeService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Active/{id}")]
        public async Task<IActionResult> Active(int id, bool active)
        {
            var brand = _modelTypeService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            brand.Result.IsActive = active;
            var result = _modelTypeService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
