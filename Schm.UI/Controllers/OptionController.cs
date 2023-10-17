using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.Model;
using Schm.Core.DTO.Request.Option;
using Schm.Core.DTO.SearchContext;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Controllers
{
    public class OptionController : Controller
    {
        public IOptionTypeService OptionTypeService { get; }

        public OptionController(IOptionTypeService optionTypeService)
        {
            OptionTypeService = optionTypeService;
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
            var result = await OptionTypeService.Get(id);
            return View(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string title)
        {
            try
            {
                var result = await OptionTypeService.Update(new UpdateOptionItemTypeDto()
                {
                    Id = id,
                    Title = title,
                });
                return Json(new { status = true, message = "ویرایش با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }

        [HttpPost]
        public async Task<IActionResult> Insert(string title)
        {
            try
            {
                var result = await OptionTypeService.Insert(new InsertOptionTypeDto()
                {
                    Title = title,
                });
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
            var resultList = await OptionTypeService.Search(new SearchOptionTypeCntxDto()
            {
                Title = searchValue,
                Skip = start,
                Take = length,
                IsActive = true,
            });
            return Ok(PaginationUtilities.GenerateData(draw, resultList.TotalCount,resultList.Result.Count, resultList.Result.ToList()));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await OptionTypeService.Delete(id);
                return Json(new { status = true, message = "حذف با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }
    }
}
