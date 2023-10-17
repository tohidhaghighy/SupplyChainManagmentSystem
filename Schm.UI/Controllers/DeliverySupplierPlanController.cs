using Microsoft.AspNetCore.Mvc;

namespace Schm.UI.Controllers
{
    public class DeliverySupplierPlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Insert()
        {
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            return View();
        }
    }
}
