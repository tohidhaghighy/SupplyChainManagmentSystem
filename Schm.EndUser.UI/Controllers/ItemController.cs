using Microsoft.AspNetCore.Mvc;

namespace Schm.EndUser.UI.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index(int ItemId)
        {
            return View();
        }
    }
}
