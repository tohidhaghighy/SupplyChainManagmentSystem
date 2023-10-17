using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Controllers
{
    public class BrandController : Controller
    {
        public BrandController(IBrandTypeService brandTypeService)
        {
            BrandTypeService = brandTypeService;
        }

        public IBrandTypeService BrandTypeService { get; }

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
            var result = await BrandTypeService.Get(id);
            return View(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id , string title, string description, IFormFile files)
        {
            try
            {
                var result = await BrandTypeService.Update(new UpdateBrandTypeDto()
                {
                    Id = id,
                    Title = title,
                    Description = description,
                    IsActive=true,
                }, files);
                return Json(new { status = true, message = "ویرایش با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }


        [HttpPost]
        public async Task<IActionResult> Insert(string title,string description,IFormFile files)
        {
            try
            {
                if (files == null)
                {
                    return Json(new { status = false, message = "تصاویر نباید خالی باشد" });
                }
                var result = await BrandTypeService.Insert(new InsertBrandTypeDto()
                {
                    Title = title,
                    Description = description,
                }, files);
                return Json(new { status = true, message = "ثبت با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message =  ex.Message });

            }
        }

        [HttpPost]
        public async Task<IActionResult> Search(int draw, int start, int length)
        {
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var resultList = await BrandTypeService.Search(new Core.SearchContext.SearchBrandCntx()
            {
                Title = searchValue,
                Description = "",
                Skip = start,
                Take = length,
                IsActive = true,
            });
            return Ok(PaginationUtilities.GenerateData(draw, resultList.TotalCount,resultList.Result.Count , resultList.Result.ToList()));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await BrandTypeService.Delete(id);
                return Json(new { status = true, message = "حذف با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }
    }
}
