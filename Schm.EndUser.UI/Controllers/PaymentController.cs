using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Schm.EndUser.UI.Infrastructure.Config;
using Schm.EndUser.UI.Infrastructure.Model;

namespace Schm.EndUser.UI.Controllers
{
    public class PaymentController : Controller
    {
        public IOptions<Config> Options { get; }

        public PaymentController(IOptions<Config> options)
        {
            Options = options;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username")==null)
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
                totalPrice+=(basket.Price*basket.Count);
            }
            ViewBag.TotalPrice = totalPrice;
            return View(BasketList);
        }
    }
}
