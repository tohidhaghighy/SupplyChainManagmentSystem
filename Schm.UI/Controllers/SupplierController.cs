using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.Supplier;
using Schm.Core.DTO.SearchContext;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Controllers
{
    public class SupplierController : Controller
    {
        public ISupplierService SupplierService { get; }

        public SupplierController(ISupplierService supplierService)
        {
            SupplierService = supplierService;
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
            var result = await SupplierService.Get(id);
            return View(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string title,string token)
        {
            try
            {
                var result = await SupplierService.Update(new UpdateSupplierDto()
                {
                    Id = id,
                    Name = title,
                    Token = token
                });
                return Json(new { status = true, message = "ویرایش با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }

        [HttpPost]
        public async Task<IActionResult> Insert(string title,string token)
        {
            try
            {
                var result = await SupplierService.Insert(new InsertSupplierDto()
                {
                    Name = title,
                    IsActive=true,
                    Token=token
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
            var resultList = await SupplierService.Search(new SearchSupplierCntxDto()
            {
                Name = searchValue,
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
                var result = await SupplierService.Delete(id);
                return Json(new { status = true, message = "حذف با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }
        }
    }
}
