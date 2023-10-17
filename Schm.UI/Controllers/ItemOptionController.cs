using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.SearchContext;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;
using Schm.UI.Infrastructure.ViewModels;

namespace Schm.UI.Controllers
{
    public class ItemOptionController : Controller
    {
        public IOptionTypeService OptionTypeService { get; }
        public IOptionGroupTypeService OptionGroupTypeService { get; }
        public IItemOptionService ItemOptionService { get; }

        public ItemOptionController(IOptionTypeService optionTypeService,IOptionGroupTypeService optionGroupTypeService,IItemOptionService itemOptionService)
        {
            OptionTypeService = optionTypeService;
            OptionGroupTypeService = optionGroupTypeService;
            ItemOptionService = itemOptionService;
        }

        public async Task<IActionResult> Index(int itemId)
        {
            return View();
        }

        public async Task<IActionResult> Insert(int itemId)
        {
            var resultViewModel = new ItemOptionViewModel();
            resultViewModel.OptionTypeList =  OptionTypeService.GetList().Result.Result;
            resultViewModel.OptionGroupTypeList =  OptionGroupTypeService.GetList().Result.Result;
            return View(resultViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Search(int draw, int start, int length, int itemId)
        {

            var optionTypeList = await OptionTypeService.GetList();
            var optionGroupTypeList = await OptionGroupTypeService.GetList();

            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var resultList = await ItemOptionService.Search(new SearchItemOptionCntxDto()
            {
                ItemId= itemId,
                Title = searchValue,
                Skip = start,
                Take = length,
            });

            var resultViewModel = new List<ItemOptionViewModel>();
            foreach (var item in resultList.Result)
            {
                resultViewModel.Add(new ItemOptionViewModel()
                {
                    Id = item.Id,
                    Title=item.OptionValue,
                    OptionName=optionTypeList.Result.Where(a=>a.Id==item.OptionTypeId).FirstOrDefault()?.Title,
                    OptionGroupName= optionGroupTypeList.Result.Where(a => a.Id == item.OptionGroupTypeId).FirstOrDefault()?.Title,
                });
            }

            return Ok(PaginationUtilities.GenerateData(draw, resultList.TotalCount,resultList.Result.Count, resultViewModel));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await ItemOptionService.Delete(id);
                return Json(new { status = true, message = "حذف با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }

        [HttpPost]
        public async Task<IActionResult> Insert(int itemId, string title, int optionType,int optionGroupType)
        {
            try
            {
                var result = await ItemOptionService.Insert(new Core.DTO.Request.ItemOption.InsertItemOptionTypeDto()
                {
                    ItemId = itemId,
                    OptionGroupTypeId = optionGroupType,
                    OptionTypeId = optionType,
                    OptionValue=title
                });
                return Json(new { status = true, message = "ثبت با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }
        }

    }
}
