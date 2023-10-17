using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Schm.EndUser.UI.Infrastructure.Model;

namespace Schm.EndUser.UI.Controllers
{
    public class CartController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var BasketList = new List<Basket>();
            var basketlist = HttpContext.Session.GetString("Basket");
            if (basketlist != null)
                BasketList = JsonConvert.DeserializeObject<List<Basket>>(basketlist);
            return View(BasketList);
        }

        public async Task<PartialViewResult> List()
        {
            var BasketList = new List<Basket>();
            var basketlist = HttpContext.Session.GetString("Basket");
            if (basketlist != null)
                BasketList = JsonConvert.DeserializeObject<List<Basket>>(basketlist);
            return PartialView("_SelectedCartList", BasketList);
        }
    }
}
