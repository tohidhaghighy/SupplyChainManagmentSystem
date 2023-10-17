using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.Transaction;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _transactionService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var result = _transactionService.GetAll();
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchTransactionCntxDto SearchCntx)
        {
            var totalCount = _transactionService.GetAll().Result.Count();
            var result = _transactionService.FindBy(a=>(a.Date >= SearchCntx.StartDate || SearchCntx.StartDate==null)
            && (a.Date <= SearchCntx.EndDate || SearchCntx.EndDate == null) 
            && a.ReferenceCode.Contains(SearchCntx.Code));
            result.TotalCount = totalCount;
            result.Result = result.Result.Skip(SearchCntx.Skip).Take(SearchCntx.Take).ToList();
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertTransactionDto item)
        {
            var result = _transactionService.Insert(new Domain.Model.Transaction()
            {
                ReferenceCode = item.ReferenceCode,
                Date=System.DateTime.Now,
                Error = item.Error,
                OrderId = item.OrderId,
                PaymentStatus = item.PaymentStatus,
                TrackingCode= item.TrackingCode
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = _transactionService.FindById(id);
            if (brand.IsSuccess == false)
            {
                return Ok(brand);
            }
            var result = _transactionService.Remove(brand.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
