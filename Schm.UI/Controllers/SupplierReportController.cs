using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.SearchContext;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Controllers
{
    public class SupplierReportController : Controller
    {
        public ISupplierItemService SupplierItemService { get; }
        public IItemService ItemService { get; }

        public SupplierReportController(ISupplierItemService supplierItemService, IItemService itemService)
        {
            SupplierItemService = supplierItemService;
            ItemService = itemService;
        }

        public async Task<IActionResult> Index(int supplierId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(int draw, int start, int length, int supplierId, string code, string startdate, string enddate, int docTypeId)
        {
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var model = new SearchDocumentCntxDto()
            {
                Code = (code == null ? "" : code),
                supplierId = supplierId,
                Skip = start,
                Take = length,
            };
            if (!string.IsNullOrEmpty(startdate))
            {
                model.StartDate = DateConvertor.ConvertToMiladi(startdate);
            }
            if (!string.IsNullOrEmpty(enddate))
            {
                model.EndDate = DateConvertor.ConvertToMiladi(enddate);
            }
            if (docTypeId != 0)
            {
                model.DocType = docTypeId;
            }
            var resultList = await SupplierItemService.GetList(supplierId);

            return Ok(PaginationUtilities.GenerateData(draw, resultList.Result.Count , length , resultList.Result.Select(a=>new
            {
                ItemName= a.ItemName,
                ItemCode= a.ItemCode,
                ItemCount = a.InventoryCount,
                ItemPrice = a.Price
            })));
        }

    }
}
