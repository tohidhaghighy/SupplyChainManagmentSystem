using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.Category;
using Schm.Core.DTO.Request.SubCategory;
using Schm.Core.DTO.SearchContext;
using Schm.Core.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : Controller
    {
        public IItemSubCatagoryService ItemSubCatagoryService { get; }

        public SubCategoryController(IItemSubCatagoryService itemSubCatagoryService)
        {
            ItemSubCatagoryService = itemSubCatagoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = ItemSubCatagoryService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList(int categoryId)
        {
            var result = ItemSubCatagoryService.GetAll();
            result.Result = result.Result.Where(a => (categoryId == 0 || a.ItemCatagoryId == categoryId)).ToList();
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchItemSubCatagoryCntxDto SearchCntx)
        {
            var totalCount = ItemSubCatagoryService.GetAll().Result.Where(a=>a.ItemCatagoryId==SearchCntx.ItemCategoryId).Count();
            var result = ItemSubCatagoryService.FindBy(a => a.Title.Contains(SearchCntx.Title) && a.ItemCatagoryId==SearchCntx.ItemCategoryId);
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] InsertSubCategoryDto category)
        {
            var result = ItemSubCatagoryService.Insert(new Domain.Model.ItemSubCatagory()
            {
                Title = category.Title,
                ItemCatagoryId=category.ItemCategoryId,
                IsActive = true
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSubCategoryDto category)
        {
            var brand = ItemSubCatagoryService.FindById(category.Id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }

            brand.Result.Title = category.Title;

            var result = ItemSubCatagoryService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = ItemSubCatagoryService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = ItemSubCatagoryService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Active/{id}")]
        public async Task<IActionResult> Active(int id, bool active)
        {
            var brand = ItemSubCatagoryService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            brand.Result.IsActive = active;
            var result = ItemSubCatagoryService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
