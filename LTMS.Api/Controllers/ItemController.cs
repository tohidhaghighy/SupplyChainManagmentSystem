using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Schm.Core.DTO.Request.Item;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public IItemService ItemService { get; }

        public ItemController(IItemService itemService,ILogger<ItemController> logger)
        {
            ItemService = itemService;
            logger.LogInformation("ItemController is fired");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = ItemService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var result = ItemService.GetAll();
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchItemCntxDto SearchCntx)
        {
            var totalCount = ItemService.GetAll().Result.Count();
            var result = ItemService.FindBy(a => (SearchCntx.Title==null || a.Title.Contains(SearchCntx.Title)) && (SearchCntx.Description==null || a.Description.Contains(SearchCntx.Description))
            && (SearchCntx.InternalCode==null || a.InternalCode.Contains(SearchCntx.InternalCode)) && (SearchCntx.StandardCode==null || a.StandardCode.Contains(SearchCntx.StandardCode)));
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] InsertItemDto item)
        {
            var result = ItemService.Insert(new Domain.Model.Item()
            {
                Title = item.Title,
                StandardCode = item.StandardCode,
                InternalCode = item.InternalCode,
                Description = item.Description,
                ItemSubCatagoryId=item.ItemSubCatagoryId,
                ItemUnitTypeId=item.ItemUnitTypeId,
                ModelTypeId=item.ModelTypeId,
                IsActive = true
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateItemDto item)
        {
            var brand = ItemService.FindById(item.Id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }

            brand.Result.Title = item.Title;
            brand.Result.Description = item.Description;
            brand.Result.InternalCode = item.InternalCode;
            brand.Result.StandardCode = item.StandardCode;
            brand.Result.ItemSubCatagoryId = item.ItemSubCatagoryId;
            brand.Result.ItemUnitTypeId = item.ItemUnitTypeId;
            brand.Result.ModelTypeId = item.ModelTypeId;

            var result = ItemService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = ItemService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = ItemService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Active/{id}")]
        public async Task<IActionResult> Active(int id, bool active)
        {
            var brand = ItemService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            brand.Result.IsActive = active;
            var result = ItemService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
