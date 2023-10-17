using Microsoft.AspNetCore.Mvc;
using Schm.UI.Infrastructure.Contracts;
using Schm.UI.Models;
using System.Diagnostics;

namespace Schm.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBrandTypeService _brandTypeService;
        private readonly IItemCategoryService _itemCategoryService;
        private readonly IItemService _itemService;
        private readonly ISupplierService _supplierService;

        public HomeController(ILogger<HomeController> logger,IBrandTypeService brandTypeService,IItemCategoryService itemCategoryService,IItemService itemService,ISupplierService supplierService)
        {
            _logger = logger;
            _brandTypeService = brandTypeService;
            _itemCategoryService = itemCategoryService;
            _itemService = itemService;
            _supplierService = supplierService;
        }

        public IActionResult Index()
        {
            var ListMenu=new Dictionary<string, int>();
            ListMenu.Add("برند",_brandTypeService.GetList().Result.Result.Count);
            ListMenu.Add("دسته بندی", _itemCategoryService.GetList().Result.Result.Count);
            ListMenu.Add("محصولات", _itemService.GetList().Result.Result.Count);
            ListMenu.Add("تامین کننده", _itemService.GetList().Result.Result.Count);
            return View(ListMenu);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}