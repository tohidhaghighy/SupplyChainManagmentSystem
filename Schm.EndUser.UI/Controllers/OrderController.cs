using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Schm.EndUser.UI.Infrastructure.Config;
using Schm.EndUser.UI.Infrastructure.Contracts;
using Schm.EndUser.UI.Infrastructure.Model;

namespace Schm.EndUser.UI.Controllers
{
    public class OrderController : Controller
    {
        public OrderController(IOrderService orderService, IOptions<Config> options)
        {
            OrderService = orderService;
            Options = options;
        }

        public IOrderService OrderService { get; }
        public IOptions<Config> Options { get; }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return Redirect(Options.Value.LoginUrl);
            }
            var BasketList = new List<Basket>();
            var basketlist = HttpContext.Session.GetString("Basket");
            if (basketlist != null)
                BasketList = JsonConvert.DeserializeObject<List<Basket>>(basketlist);
            double totalPrice = 0;
            foreach (var basket in BasketList)
            {
                totalPrice += (basket.Price * basket.Count);
            }
            ViewBag.TotalPrice = totalPrice;
            var code = DateTime.Now.ToString("yyyyMMddHHmmss");
            var order =await OrderService.Insert(new Core.DTO.Request.Order.InsertOrderDto()
            {
                Address="",
                Description="",
                DiscountCost=0,
                LogenticTypeId=1,
                OrderNumber=code,
                OrderStatus=1,
                PayCost=totalPrice,
                PaymentTypeId=1,
                SupplierId= (int)HttpContext.Session.GetInt32("SupplierId"),
                Tax=0,
                UserId = (int)HttpContext.Session.GetInt32("UserId"),
            });
            if (order.IsSuccess)
            {
                return RedirectToAction("PaymentIsOk", new {code = code});
            }
            return RedirectToAction("ErrorInPayment", new { code = code });
        }

        public IActionResult PaymentIsOk(string code)
        {
            var BasketList = new List<Basket>();
            var basketlist = HttpContext.Session.GetString("Basket");
            if (basketlist != null)
                BasketList = JsonConvert.DeserializeObject<List<Basket>>(basketlist);
            double totalPrice = 0;
            foreach (var basket in BasketList)
            {
                totalPrice += (basket.Price * basket.Count);
            }
            ViewBag.TotalPrice = totalPrice;
            ViewBag.Code = code;
            return View(BasketList);
        }

        public IActionResult ErrorInPayment(string code)
        {
            var BasketList = new List<Basket>();
            var basketlist = HttpContext.Session.GetString("Basket");
            if (basketlist != null)
                BasketList = JsonConvert.DeserializeObject<List<Basket>>(basketlist);
            double totalPrice = 0;
            foreach (var basket in BasketList)
            {
                totalPrice += (basket.Price * basket.Count);
            }
            ViewBag.TotalPrice = totalPrice;
            ViewBag.Code = code;
            return View(BasketList);
        }
    }
}
