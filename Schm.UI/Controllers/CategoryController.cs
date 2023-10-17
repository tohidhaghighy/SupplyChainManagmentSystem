using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request;
using Schm.Core.DTO.Request.Category;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;
using Schm.UI.Infrastructure.Services;

namespace Schm.UI.Controllers
{
    public class CategoryController : Controller
    {
        public IItemCategoryService ItemCategoryService { get; }

        public CategoryController(IItemCategoryService itemCategoryService)
        {
            ItemCategoryService = itemCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Insert()
        {
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await ItemCategoryService.Get(id);
            return View(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string title,IFormFile files)
        {
            try
            {
                var result = await ItemCategoryService.Update(new UpdateCategoryDto()
                {
                    Id = id,
                    Title = title,
                }, files);
                return Json(new { status = true, message = "ویرایش با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }

        [HttpPost]
        public async Task<IActionResult> Insert(string title, IFormFile files)
        {
            try
            {
                if (files == null)
                {
                    return Json(new { status = false, message = "تصاویر نباید خالی باشد" });
                }
                var result = await ItemCategoryService.Insert(new InsertCategoryDto()
                {
                    Title = title,
                }, files);
                return Json(new { status = true, message = "ثبت با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }

        [HttpPost]
        public async Task<IActionResult> Search(int draw, int start, int length)
        {
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var resultList = await ItemCategoryService.Search(new Core.SearchContext.SearchItemCategoryCntx()
            {
                Title = searchValue,
                Skip = start,
                Take = length,
                IsActive = true,
            });
            return Ok(PaginationUtilities.GenerateData(draw, resultList.TotalCount, resultList.Result.Count, resultList.Result.ToList()));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await ItemCategoryService.Delete(id);
                return Json(new { status = true, message = "حذف با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }
    }
}
