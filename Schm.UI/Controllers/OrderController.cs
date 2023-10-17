using Microsoft.AspNetCore.Mvc;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;
using System.Globalization;

namespace Schm.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(int draw, int start, int length, string code, string startdate, string enddate)
        {
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var model = new Core.DTO.SearchContext.SearchOrderCntxDto()
            {
                SupplierId= (int)HttpContext.Session.GetInt32("SupplierId"),
                OrderNumber = code,
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
            var resultList = await _orderService.Search(model);
            PersianCalendar pc = new PersianCalendar();

            return Ok(PaginationUtilities.GenerateData(draw, resultList.TotalCount, resultList.Result.Count, resultList.Result.Select(a=>new
            {
                a.OrderNumber,
                a.Id,
                OrderStatus ="پرداخت شده",
                Date = string.Format("{0}/{1}/{2}", pc.GetYear(a.Date), pc.GetMonth(a.Date), pc.GetDayOfMonth(a.Date))
            }).ToList()));
        }

    }
}
