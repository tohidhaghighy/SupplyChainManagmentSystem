using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Controllers
{
    public class SupplierUserController : Controller
    {
        public ISupplierUserService SupplierUserService { get; }

        public SupplierUserController(ISupplierUserService supplierUserService)
        {
            SupplierUserService = supplierUserService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(int draw, int start, int length,int supplierId)
        {
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var resultList = await SupplierUserService.Search(new SearchSupplierUserCntxDto()
            {
                SupplierId=supplierId,
                UserName=searchValue,
                Skip = start,
                Take = length,
                IsActive = true,
            });
            return Ok(PaginationUtilities.GenerateData(draw, resultList.TotalCount, resultList.Result.Count, resultList.Result.ToList()));
        }

        [HttpPost]
        public async Task<IActionResult> Active(int id,bool active)
        {
            try
            {
                var result = await SupplierUserService.Active(id,active);
                return Json(new { status = true, message = "ویرایش با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }
        }
    }
}
