using Microsoft.AspNetCore.Mvc;

namespace Schm.UI.Controllers
{
    public class SubOptionController : Controller
    {
        public IActionResult Index(int optionId)
        {
            return View();
        }
    }
}
