using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schm.Api.Infrastructure.Common;
using Schm.Core.DTO.Request.ItemImage;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemImageController : Controller
    {
        public IItemImageService ItemImageService { get; }

        public ItemImageController(IItemImageService itemImageService)
        {
            ItemImageService = itemImageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = ItemImageService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList(int itemId)
        {
            var result = ItemImageService.GetAll();
            result.Result = result.Result.Where(a => a.ItemId == itemId).ToList();
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromForm] InsertItemImageDto imageItem, IFormFile Image = null)
        {
            string ImageSrc = "";
            if (Image != null)
            {
                ImageSrc = await UploadImage.Upload(Image);
            }
            var result = ItemImageService.Insert(new Domain.Model.ItemImage()
            {
                ImageUrl = ImageSrc,
                ItemId = imageItem.ItemId,
                IsActive = true
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = ItemImageService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = ItemImageService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
