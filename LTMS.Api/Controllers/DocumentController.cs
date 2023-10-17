using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.Document;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : Controller
    {
        IDocumentService _documentService;
        private readonly ISubDocumentService _subDocumentService;
        private readonly ISupplierItemService _supplierItemService;

        public DocumentController(IDocumentService documentService,ISubDocumentService subDocumentService,ISupplierItemService supplierItemService)
        {
            _documentService = documentService;
            _subDocumentService = subDocumentService;
            _supplierItemService = supplierItemService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _documentService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList(int supplierId)
        {
            var result = _documentService.FindBy(a=>a.SupplierId==supplierId);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchDocumentCntxDto SearchCntx)
        {
            var totalCount = _documentService.FindBy(a => a.SupplierId == SearchCntx.supplierId).Result.Count();
            var result = _documentService.FindBy(a => a.SupplierId == SearchCntx.supplierId && a.DocumentCode.Contains(SearchCntx.Code) 
            && (a.InsertDate>=SearchCntx.StartDate || SearchCntx.StartDate == null) 
            && (a.InsertDate <= SearchCntx.EndDate || SearchCntx.EndDate == null)
            && (a.DocumentType==SearchCntx.DocType || SearchCntx.DocType==0));
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take).ToList();
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertDocumentDto document)
        {
            var result = _documentService.Insert(new Domain.Model.Document()
            {
                DocumentType = document.DocumentType,
                DocumentCode = document.DocumentCode,
                SupplierId = document.SupplierId,
                InsertDate=document.InsertDate,
                InsertedUserId=document.InsertedUserId
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateDocumentDto document)
        {
            var plan = _documentService.FindById(document.Id);
            if (plan.IsSuccess == false)
            {
                return Ok(plan);
            }

            plan.Result.DocumentCode = document.DocumentCode;

            var result = _documentService.Update(plan.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = _documentService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = _documentService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Final/{id}")]
        public async Task<IActionResult> Final(int id)
        {
            try
            {
                var document = _documentService.FindById(id);
                if (document.IsSuccess == false)
                {
                    return Ok(document);
                }

                var subDocList = await _subDocumentService.GetSubDocumentwithItem(id);
                if (subDocList.Count()==0)
                {
                    return BadRequest("سند خالی است");
                }
                foreach (var item in subDocList)
                {
                    var supplierItem = _supplierItemService.FindBy(a => a.ItemId == item.ItemId && a.SupplierId == document.Result.SupplierId);
                    if (supplierItem.Result.Count()==0)
                    {
                        return BadRequest("کالای مورد نظر برای این تامین کننده ثبت نشده است");
                    }
                    var supitem = supplierItem.Result.FirstOrDefault();
                    if (document.Result.DocumentType == 2 && supitem.InventoryCount<item.Count)
                    {
                        return BadRequest("تعداد سند خر.ج کالا بیشتر از موجودی انبار است");
                    }
                    if (document.Result.DocumentType==1)
                        supitem.InventoryCount += item.Count;
                    else if (document.Result.DocumentType == 2)
                        supitem.InventoryCount -= item.Count;
                    supitem.Price = item.Price;
                    _supplierItemService.Update(supitem);
                }
                
                document.Result.IsFinal = true;
                var result = _documentService.Update(document.Result);
                await Task.CompletedTask;
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
