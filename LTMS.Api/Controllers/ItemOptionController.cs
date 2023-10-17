using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.ItemOption;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemOptionController : Controller
    {
        public IItemOptionService itemOptionService { get; }

        public ItemOptionController(IItemOptionService itemOptionService)
        {
            this.itemOptionService = itemOptionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = itemOptionService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList(int itemId)
        {
            var result = itemOptionService.GetAll();
            result.Result = result.Result.Where(a => a.ItemId == itemId).ToList();
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchItemOptionCntxDto SearchCntx)
        {
            var totalCount = itemOptionService.GetAll().Result.Count();
            var result = itemOptionService.FindBy(a => (SearchCntx.Title == null || a.OptionValue.Contains(SearchCntx.Title)) && (SearchCntx.ItemId==0 || a.ItemId == SearchCntx.ItemId));  
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertItemOptionTypeDto ItemOption)
        {
            var result = itemOptionService.Insert(new Domain.Model.ItemOption()
            {
                OptionGroupTypeId=ItemOption.OptionGroupTypeId,
                ItemId = ItemOption.ItemId,
                OptionValue = ItemOption.OptionValue,
                OptionTypeId=ItemOption.OptionTypeId,
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = itemOptionService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = itemOptionService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
