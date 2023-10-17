using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schm.Api.Infrastructure.Common;
using Schm.Core.DTO.Request;
using Schm.Core.DTO.Request.Category;
using Schm.Core.SearchContext;
using Schm.Domain.IService;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        IItemCatagoryService _itemCategoryService;
        public CategoryController(IItemCatagoryService itemCategoryService)
        {
            _itemCategoryService = itemCategoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _itemCategoryService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var result = _itemCategoryService.GetAll();
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchItemCategoryCntx SearchCntx)
        {
            var totalCount = _itemCategoryService.GetAll().Result.Count();
            var result = _itemCategoryService.FindBy(a => a.Title.Contains(SearchCntx.Title));
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromForm] InsertCategoryDto category, IFormFile Image = null)
        {
            string ImageSrc = "";
            if (Image != null)
            {
                ImageSrc = await UploadImage.Upload(Image);
            }
            var result = _itemCategoryService.Insert(new Domain.Model.ItemCatagory()
            {
                Title = category.Title,
                IsActive = true,
                ImageUrl = ImageSrc,
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDto brandtype, IFormFile Image = null)
        {
            var brand = _itemCategoryService.FindById(brandtype.Id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            if (Image != null)
            {
                brand.Result.ImageUrl = await UploadImage.Upload(Image);
            }

            brand.Result.Title = brandtype.Title;

            var result = _itemCategoryService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = _itemCategoryService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = _itemCategoryService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Active/{id}")]
        public async Task<IActionResult> Active(int id, bool active)
        {
            var brand = _itemCategoryService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            brand.Result.IsActive = active;
            var result = _itemCategoryService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
