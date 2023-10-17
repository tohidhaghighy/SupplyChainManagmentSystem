using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.Model;
using Schm.Core.DTO.SearchContext;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;
using Schm.UI.Infrastructure.Models;

namespace Schm.UI.Controllers
{
    public class ModelController : Controller
    {
        public IModelTypeService ModelTypeService { get; }

        public ModelController(IModelTypeService modelTypeService)
        {
            ModelTypeService = modelTypeService;
        }

        public IActionResult Index(int brandId)
        {
            return View();
        }

        public async Task<IActionResult> Insert(int brandId)
        {
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await ModelTypeService.Get(id);
            return View(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string title,int brandId)
        {
            try
            {
                var result = await ModelTypeService.Update(new UpdateModelTypeDto()
                {
                    Title = title,
                    Id = id,
                    BrandTypeId = brandId
                });
                return Json(new { status = true, message = "ویرایش با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(string title, int brandId)
        {
            try
            {
                var result = await ModelTypeService.Insert(new InsertModelTypeDto()
                {
                    Title = title,
                    BrandTypeId = brandId,
                    IsActive = true,
                });
                return Json(new { status = true, message = "ثبت با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Search(int draw, int start, int length, int brandId)
        {
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var resultList = await ModelTypeService.Search(new SearchModelTypeCntxDto()
            {
                BrandTypeId = brandId,
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
                var result = await ModelTypeService.Delete(id);
                return Json(new { status = true, message = "حذف با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }
        }

        public async Task<PartialViewResult> ModelList(int brandId)
        {
            var resultList = await ModelTypeService.Search(new SearchModelTypeCntxDto()
            {
                BrandTypeId = brandId,
                Title = "",
                Skip = 0,
                Take = int.MaxValue,
                IsActive = true,
            });
            var keyValueList= new List<KeyValue<int>>();
            foreach (var item in resultList.Result)
            {
                keyValueList.Add(new KeyValue<int>()
                {
                    Key=item.Id,
                    Value=item.Title
                });
            }
            return PartialView("~/Views/Item/_SelectOptions.cshtml", keyValueList);
        }

    }
}
