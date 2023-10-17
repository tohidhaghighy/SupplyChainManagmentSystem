using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.SupplierItem;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Controllers
{
    public class SupplierItemController : Controller
    {
        public ISupplierItemService SupplierItemService { get; }
        public IItemService ItemService { get; }

        public SupplierItemController(ISupplierItemService supplierItemService,IItemService itemService)
        {
            SupplierItemService = supplierItemService;
            ItemService = itemService;
        }

        public async Task<IActionResult> Index(int supplierId)
        {
            return View();
        }

        public async Task<IActionResult> Insert(int supplierId)
        {
            var supplierItem= await SupplierItemService.GetList(supplierId);
            var itemList=await ItemService.GetList();
            foreach (var item in supplierItem.Result)
            {
                var oneitem = itemList.Result.Where(a => a.Id == item.ItemId).FirstOrDefault();
                itemList.Result.Remove(oneitem);
            }
            return View(itemList.Result);
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await SupplierItemService.Get(id);
            return View(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(int itemId,int supplierId)
        {
            try
            {
                var result = await SupplierItemService.Insert(new InsertSupplierItemDto()
                {
                    InventoryCount = 0,
                    IsActive = true,
                    IsExist=true,
                    ItemId=itemId,
                    Price=0,
                    SupplierId=supplierId
                });
                return Json(new { status = true, message = "ثبت با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }

        [HttpPost]
        public async Task<IActionResult> Search(int draw, int start, int length,int supplierId)
        {
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var resultList = await SupplierItemService.Search(new SearchSupplierItemCntxDto()
            {
                SupplierId = supplierId,
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
                var result = await SupplierItemService.Delete(id);
                return Json(new { status = true, message = "حذف با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }
        }
    }
}
