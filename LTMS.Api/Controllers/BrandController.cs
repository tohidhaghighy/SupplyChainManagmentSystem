using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schm.Api.Infrastructure.Common;
using Schm.Core.DTO.Request;
using Schm.Core.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        IBrandTypeService _brandTypeService;
        public BrandController(IBrandTypeService brandTypeService)
        {
            _brandTypeService = brandTypeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _brandTypeService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var result = _brandTypeService.GetAll();
            await Task.CompletedTask;
            return Ok(result);
        }
        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchBrandCntx SearchCntx)
        {
            var totalCount = _brandTypeService.GetAll().Result.Count();
            var result = _brandTypeService.FindBy(a => a.Title.Contains(SearchCntx.Title));
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromForm] InsertBrandTypeDto brand,IFormFile Image=null)
        {
            string ImageSrc = "";
            if (Image != null)
            {
                ImageSrc = await UploadImage.Upload(Image);
            }
            var result = _brandTypeService.Insert(new Domain.Model.BrandType()
            {
                Description = brand.Description,
                ImageUrl = ImageSrc,
                Title = brand.Title,
                IsActive= true
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm]UpdateBrandTypeDto brandtype,IFormFile Image=null)
        {
            var brand = _brandTypeService.FindById(brandtype.Id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            if (Image !=null)
            {
                brand.Result.ImageUrl = await UploadImage.Upload(Image);
            }
            
            brand.Result.Description = brandtype.Description;
            brand.Result.Title = brandtype.Title;

            var result = _brandTypeService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = _brandTypeService.FindById(id);
            if (brand.IsSuccess==false)
            {
                return Ok(brand);
            }
            var result = _brandTypeService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Active/{id}")]
        public async Task<IActionResult> Active(int id,bool active)
        {
            var brand = _brandTypeService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            brand.Result.IsActive = active;
            var result = _brandTypeService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
