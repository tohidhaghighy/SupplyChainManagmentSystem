using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.SubDocument;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Controllers
{
    public class SubDocumentController : Controller
    {
        public ISubDocumentService SubDocumentService { get; }
        public IDocumentService DocumentService { get; }
        public ISupplierItemService SupplierItemService { get; }
        public IItemService ItemService { get; }

        public SubDocumentController(ISubDocumentService subDocumentService , IDocumentService documentService, ISupplierItemService supplierItemService, IItemService itemService)
        {
            SubDocumentService = subDocumentService;
            DocumentService = documentService;
            SupplierItemService = supplierItemService;
            ItemService = itemService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Insert(int supplierId,int documentId)
        {
            var docinfo= await DocumentService.Get(documentId);
            var resultlist = new List<Item>();
            var supplierItem = await SupplierItemService.GetList(supplierId);
            var itemList = await ItemService.GetList();
            foreach (var item in supplierItem.Result)
            {
                var oneitem = itemList.Result.Where(a => a.Id == item.ItemId).FirstOrDefault();
                resultlist.Add(oneitem);
            }
            ViewData["IsFinal"] = docinfo.Result.IsFinal;
            return View(resultlist);
        }

        public async Task<IActionResult> InsertFinal(int supplierId, int documentId)
        {
            var docinfo = await DocumentService.Get(documentId);
            var resultlist = new List<Item>();
            var supplierItem = await SupplierItemService.GetList(supplierId);
            var itemList = await ItemService.GetList();
            foreach (var item in supplierItem.Result)
            {
                var oneitem = itemList.Result.Where(a => a.Id == item.ItemId).FirstOrDefault();
                resultlist.Add(oneitem);
            }
            return View(resultlist);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(int count, int documentId,int itemId,double price)
        {
            try
            {
                var subdocinfo = await SubDocumentService.GetList(documentId);
                if (subdocinfo != null)
                {
                    if (subdocinfo.Result.Where(a => a.ItemId == itemId).Count() > 0)
                    {
                        return Json(new { status = false, message = "این کالا قبلا در این سند ثبت شده است" });
                    }
                }
                var result = await SubDocumentService.Insert(new InsertSubDocumentDto()
                {
                    Count = count,
                    DocumentId = documentId,
                    InsertedDate = DateTime.Now,
                    IsDeleted = false,
                    ItemId = itemId,
                    Price=price
                });
                return Json(new { status = true, message = "ثبت با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }

        [HttpPost]
        public async Task<IActionResult> Search(int draw, int start, int length,int documentId)
        {
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var resultList = await SubDocumentService.Search(new SearchSubDocumentCntxDto()
            {
                DocumentId=documentId,
                Skip = start,
                Take = length,
            });
            return Ok(PaginationUtilities.GenerateData(draw, resultList.TotalCount, resultList.Result.Count, resultList.Result.ToList()));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await SubDocumentService.Delete(id);
                return Json(new { status = true, message = "حذف با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }
        }
    }
}
