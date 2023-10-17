using Microsoft.AspNetCore.Mvc;
using Schm.Domain.Model;
using Schm.EndUser.UI.Infrastructure.Contracts;
using Schm.EndUser.UI.Infrastructure.ViewModels;

namespace Schm.EndUser.UI.Controllers
{
    public class ItemCategoryController : Controller
    {
        IItemCategoryService _itemCategoryService;

        IItemSubCategoryService _itemSubCatagoryService;

        public ItemCategoryController(IItemCategoryService itemCategoryService, IItemSubCategoryService itemSubCatagoryService)
        {
            _itemCategoryService = itemCategoryService;
            _itemSubCatagoryService = itemSubCatagoryService;
        }

        public async Task<JsonResult> GetCategory()
        {
            return Json(new {data = _itemCategoryService.GetList()});
        }

        public async Task<JsonResult> GetSubCategory()
        {
            return Json(new { data = _itemSubCatagoryService.GetList() });
        }

        public async Task<PartialViewResult> MenuList(string type)
        {
            var categoryViewModel = new CategoryViewModel();
            categoryViewModel.ItemCatagoryList = _itemCategoryService.GetList().Result.Result;
            categoryViewModel.ItemSubCatagoryList = _itemSubCatagoryService.GetList().Result.Result;
            return PartialView((type=="desktop"?"_CategoryMenuList": "_CategoryMobileMenuList"), categoryViewModel);
        }

    }
}
