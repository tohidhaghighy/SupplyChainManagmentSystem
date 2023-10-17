using Microsoft.AspNetCore.Mvc;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Controllers
{
    public class GalleryController : Controller
    {
        public IItemImageService ItemImageService { get; }

        public GalleryController(IItemImageService itemImageService)
        {
            ItemImageService = itemImageService;
        }


        public async Task<IActionResult> Index(int itemId)
        {
            var result = await ItemImageService.GetList(itemId);
            return View(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(int itemId, IFormFile files)
        {
            try
            {
                var result = await ItemImageService.Insert(new Core.DTO.Request.ItemImage.InsertItemImageDto()
                {
                    ItemId=itemId,
                }, files);
                return Json(new { status = true, message = "ثبت با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await ItemImageService.Delete(id);
                return Json(new { status = true, message = "حذف با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }
    }
}
