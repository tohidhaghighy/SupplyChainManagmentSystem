using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Schm.EndUser.UI.Infrastructure.Config;
using Schm.EndUser.UI.Infrastructure.Contracts;
using Schm.EndUser.UI.Infrastructure.ViewModels;
using Schm.EndUser.UI.Models;
using System.Diagnostics;

namespace Schm.EndUser.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<Config> options;
        private readonly IBrandTypeService _brandTypeService;
        private readonly IItemCategoryService _itemCategoryService;
        private readonly ISupplierItemService _supplierItemService;

        public HomeController(ILogger<HomeController> logger, IOptions<Config> options, IBrandTypeService brandTypeService,IItemCategoryService itemCategoryService,ISupplierItemService supplierItemService)
        {
            _logger = logger;
            this.options = options;
            _brandTypeService = brandTypeService;
            _itemCategoryService = itemCategoryService;
            _supplierItemService = supplierItemService;
        }

        public async Task<IActionResult> Index()
        {
            var HomeInfo = new HomeViewModel();
            var categoryResult = _itemCategoryService.GetList().Result.Result;
            foreach (var item in categoryResult)
            {
                item.ImageUrl = options.Value.ApiSchmUrl + item.ImageUrl;
            }
            HomeInfo.CategoryList = categoryResult;
            var brandResult = _brandTypeService.GetList().Result.Result;
            foreach (var item in brandResult)
            {
                item.ImageUrl = options.Value.ApiSchmUrl + item.ImageUrl;
            }
            HomeInfo.BrandList=brandResult;
            var itemresult = _supplierItemService.Search(new Core.DTO.SearchContext.SearchSupplierItemCntxDto()
            {
                Skip = 0,
                Take = 20
            }).Result.Result;
            HomeInfo.ItemList = itemresult;
            return View(HomeInfo);
        }

        public IActionResult CallUs()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
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