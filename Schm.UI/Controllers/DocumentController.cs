using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.Document;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;
using Schm.UI.Infrastructure.ViewModels;
using System.Globalization;

namespace Schm.UI.Controllers
{
    public class DocumentController : Controller
    {
        public IDocumentService DocumentService { get; }
        public ISupplierItemService SupplierItemService { get; }
        public IItemService ItemService { get; }

        public DocumentController(IDocumentService documentService,ISupplierItemService supplierItemService,IItemService itemService)
        {
            DocumentService = documentService;
            SupplierItemService = supplierItemService;
            ItemService = itemService;
        }

        public IActionResult EnterDoc()
        {
            return View();
        }

        public IActionResult ExitDoc()
        {
            return View();
        }

        public async Task<IActionResult> Insert(int supplierId,int documentType)
        {
            var document = await DocumentService.Insert(new InsertDocumentDto()
            {
                IsDeleted=false,
                InsertDate=DateTime.Now,
                DocumentCode = Guid.NewGuid().ToString(),
                DocumentType = documentType,
                InsertedUserId = 1,
                SupplierId=supplierId,
            });
            return Redirect("/SubDocument/Insert?supplierId="+supplierId+"&documentId=" + document.Result.Id+"&docType="+documentType);
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await DocumentService.Get(id);
            return View(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string documentCode)
        {
            try
            {
                var result = await DocumentService.Update(new UpdateDocumentDto()
                {
                    DocumentCode=documentCode,
                    Id = id,
                });
                return Json(new { status = true, message = "ویرایش با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(int supplierId, int documentType, string documentCode)
        {
            try
            {
                var result = await DocumentService.Insert(new InsertDocumentDto()
                {
                    InsertDate = DateTime.Now,
                    DocumentType=documentType,
                    DocumentCode=documentCode,
                    IsDeleted=false,
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
        public async Task<IActionResult> Search(int draw, int start, int length, int supplierId,string code,string startdate,string enddate,int docTypeId)
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
            if (docTypeId!=0)
            {
                model.DocType = docTypeId;
            }
            var resultList = await DocumentService.Search(model);
            PersianCalendar pc = new PersianCalendar();
            var documentList= new List<DocumentViewModel>();
            foreach (var item in resultList.Result)
            {
                string docType = "ورود";
                if (item.DocumentType == 2) docType = "خروج";
                documentList.Add(new DocumentViewModel()
                {
                    Id=item.Id,
                    DocumentCode =item.DocumentCode,
                    DocumentType = docType,
                    InsertDate = string.Format("{0}/{1}/{2}", pc.GetYear(item.InsertDate), pc.GetMonth(item.InsertDate), pc.GetDayOfMonth(item.InsertDate)),
                    InsertedUsername="",
                    IsDeleted=item.IsDeleted,
                    SupplierId=item.SupplierId,
                    IsFinal=item.IsFinal,
                });
            }

            return Ok(PaginationUtilities.GenerateData(draw, resultList.TotalCount, documentList.Count, documentList));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var docInfo = await DocumentService.Get(id);
                if (docInfo.Result!=null)
                {
                    if (docInfo.Result.IsFinal==false)
                    {
                        var result = await DocumentService.Delete(id);
                        return Json(new { status = true, message = "حذف با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });
                    }
                    else
                    {
                        return Json(new { status = false, message = "اسناد نهایی شدن قابلیت حذف ندارند" });
                    }
                }
                else
                {
                    return Json(new { status = false, message = "سند مورد نظر یافت نشد" });
                }

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }
        }

        [HttpPost]
        public async Task<IActionResult> Final(int id)
        {
            try
            {
                var result = await DocumentService.Final(id);
                return Json(new { status = true, message = "اتمام با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }
    }
}
