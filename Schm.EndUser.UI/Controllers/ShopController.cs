using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Schm.EndUser.UI.Infrastructure.Config;
using Schm.EndUser.UI.Infrastructure.Contracts;

namespace Schm.EndUser.UI.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<Config> _options;
        private readonly IShopService _shopService;
        private readonly IBrandTypeService _brandTypeService;
        private readonly IItemCategoryService _itemCategoryService;
        private readonly ISupplierItemService _supplierItemService;
        

        public ShopController(ILogger<HomeController> logger, IOptions<Config> options,IShopService shopService, IBrandTypeService brandTypeService, IItemCategoryService itemCategoryService, ISupplierItemService supplierItemService)
        {
            _logger = logger;
            _options = options;
            _shopService = shopService;
            _brandTypeService = brandTypeService;
            _itemCategoryService = itemCategoryService;
            _supplierItemService = supplierItemService;
        }

        public IActionResult Index(int categoryId,int subCategoryId,int brandId,string search="",double min=0,double max=double.MaxValue)
        {
            var itemresult = _shopService.Search(new Core.DTO.SearchContext.SearchShopCntxDto()
            {
                CategoryId = categoryId,
                SubCategoryId = subCategoryId,
                BrandId = brandId,
                Text = search,
                MinCost=min,
                MaxCost=max,
                Skip = 0,
                Take = 20
            }).Result.Result;
            return View(itemresult);
        }

        public IActionResult Item(int itemId,int supplierId)
        {
            var itemresult = _shopService.Get(itemId).Result.Result;
            if (itemresult==null)
            {
                return NotFound();
            }
            itemresult.DefaultSupplierId = supplierId;
            return View(itemresult);
        }
    }
}
