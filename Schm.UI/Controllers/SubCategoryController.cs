using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.SubCategory;
using Schm.Core.DTO.SearchContext;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;
using Schm.UI.Infrastructure.Models;

namespace Schm.UI.Controllers
{
    public class SubCategoryController : Controller
    {

        public IItemSubCatagoryService ItemSubCatagoryService { get; }

        public SubCategoryController(IItemSubCatagoryService itemSubCatagoryService)
        {
            ItemSubCatagoryService = itemSubCatagoryService;
        }

        public IActionResult Index(int categoryId)
        {
            return View();
        }

        public async Task<IActionResult> Insert(int categoryId)
        {
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await ItemSubCatagoryService.Get(id);
            return View(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string title)
        {
            try
            {
                var result = await ItemSubCatagoryService.Update(new UpdateSubCategoryDto()
                {
                    Title = title,
                    Id  = id,
                });
                return Json(new { status = true, message = "ویرایش با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }

        [HttpPost]
        public async Task<IActionResult> Insert(string title,int categoryId)
        {
            try
            {
                var result = await ItemSubCatagoryService.Insert(new InsertSubCategoryDto()
                {
                    Title = title,
                    ItemCategoryId = categoryId,
                    IsActive=true,
                });
                return Json(new { status = true, message = "ثبت با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }

        [HttpPost]
        public async Task<IActionResult> Search(int draw, int start, int length,int categoryId)
        {
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var resultList = await ItemSubCatagoryService.Search(new SearchItemSubCatagoryCntxDto()
            {
                ItemCategoryId= categoryId,
                Title = searchValue,
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
                var result = await ItemSubCatagoryService.Delete(id);
                return Json(new { status = true, message = "حذف با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }

        public async Task<PartialViewResult> SubCategoryList(int categoryId)
        {
            var resultList = await ItemSubCatagoryService.Search(new SearchItemSubCatagoryCntxDto()
            {
                ItemCategoryId = categoryId,
                Title = "",
                Skip = 0,
                Take = int.MaxValue,
                IsActive = true,
            });
            var keyValueList = new List<KeyValue<int>>();
            foreach (var item in resultList.Result)
            {
                keyValueList.Add(new KeyValue<int>()
                {
                    Key = item.Id,
                    Value = item.Title
                });
            }
            return PartialView("~/Views/Item/_SelectOptions.cshtml", keyValueList);
        }
    }
}
