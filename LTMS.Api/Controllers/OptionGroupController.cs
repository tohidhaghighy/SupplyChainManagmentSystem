using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.Option;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionGroupController : Controller
    {
        public IOptionGroupTypeService OptionGroupTypeService { get; }

        public OptionGroupController(IOptionGroupTypeService optionGroupTypeService)
        {
            OptionGroupTypeService = optionGroupTypeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = OptionGroupTypeService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var result = OptionGroupTypeService.GetAll();
            await Task.CompletedTask;
            return Ok(result);
        }
        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchOptionTypeCntxDto SearchCntx)
        {
            var totalCount = OptionGroupTypeService.GetAll().Result.Count();
            var result = OptionGroupTypeService.FindBy(a => a.Title.Contains(SearchCntx.Title));
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertOptionTypeDto option)
        {
            var result = OptionGroupTypeService.Insert(new Domain.Model.OptionGroupType()
            {
                Title = option.Title,
                IsActive = true
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateOptionItemTypeDto brandtype)
        {
            var brand = OptionGroupTypeService.FindById(brandtype.Id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }

            brand.Result.Title = brandtype.Title;

            var result = OptionGroupTypeService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = OptionGroupTypeService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = OptionGroupTypeService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Active/{id}")]
        public async Task<IActionResult> Active(int id, bool active)
        {
            var brand = OptionGroupTypeService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            brand.Result.IsActive = active;
            var result = OptionGroupTypeService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
