using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Schm.EndUser.UI.Infrastructure.Config;
using Schm.EndUser.UI.Infrastructure.Contracts;

namespace Schm.EndUser.UI.Controllers
{
    public class PanelController : Controller
    {
        public PanelController(IOptions<Config> options,IOrderService orderService)
        {
            Options = options;
            OrderService = orderService;
        }

        public IOptions<Config> Options { get; }
        public IOrderService OrderService { get; }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return Redirect(Options.Value.LoginUrl);
            }
            var orderList= await OrderService.Search(new Core.DTO.SearchContext.SearchOrderCntxDto()
            {
                UserId = (int)HttpContext.Session.GetInt32("UserId"),
                Skip=0,
                Take=30
            });
            return View(orderList.Result);
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
