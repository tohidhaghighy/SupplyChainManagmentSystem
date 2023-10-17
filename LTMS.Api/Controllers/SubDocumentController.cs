using LTMS.Core.GenericDataResponse;
using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.SubDocument;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubDocumentController : Controller
    {
        ISubDocumentService _subDocumentService;
        public SubDocumentController(ISubDocumentService subDocumentService)
        {
            _subDocumentService = subDocumentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _subDocumentService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList(int documentId)
        {
            var result = _subDocumentService.GetSubDocumentwithItem(documentId);
            var searchList = new DataResponse<dynamic>();
            searchList.Result = result.Result.Select(a => new
            {
                a.DocumentId,
                ItemId = a.Item.Id,
                a.Item.Title,
                a.Document.DocumentCode,
                a.Document.DocumentType,
                a.Price,
                a.Count,
                a.Id
            }).ToList();
            await Task.CompletedTask;
            return Ok(searchList);
        }
        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchSubDocumentCntxDto SearchCntx)
        {
            var totalCount = _subDocumentService.FindBy(a=>a.DocumentId==SearchCntx.DocumentId).Result.Count();
            var result = _subDocumentService.GetSubDocumentwithItem(SearchCntx.DocumentId);
            var searchList = new DataResponse<dynamic>();
            searchList.TotalCount = totalCount;
            searchList.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take).Select(a=>new
            {
                a.DocumentId,
                a.Item.Title,
                a.Document.DocumentCode,
                a.Document.DocumentType,
                a.Price,
                a.Count,
                a.Id
            }).ToList();
            await Task.CompletedTask;
            return Ok(searchList);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertSubDocumentDto subDocument)
        {
            var result = _subDocumentService.Insert(new Domain.Model.SubDocument()
            {
                DocumentId = subDocument.DocumentId,
                Count = subDocument.Count,
                InsertedDate= subDocument.InsertedDate,
                IsDeleted= subDocument.IsDeleted,
                ItemId= subDocument.ItemId,
                Price= subDocument.Price,
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateSubDocumentDto subDocument)
        {
            var brand = _subDocumentService.FindById(subDocument.Id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }

            brand.Result.Price = subDocument.Price;
            brand.Result.Count = subDocument.Count;

            var result = _subDocumentService.Update(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subDocument = _subDocumentService.FindById(id);
            if (subDocument.IsSuccess == false)
            {
                return Ok(subDocument);
            }
            var result = _subDocumentService.Remove(subDocument.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
