using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request;
using Schm.Core.DTO.Request.Item;
using Schm.UI.Common;
using Schm.UI.Infrastructure.Contracts;
using Schm.UI.Infrastructure.ViewModels;

namespace Schm.UI.Controllers
{
    public class ItemController : Controller
    {
        public ItemController(IBrandTypeService brandTypeService,IItemService itemService,IItemCategoryService itemCategoryService,IItemUnitTypeService itemUnitTypeService,IModelTypeService modelTypeService,IItemSubCatagoryService itemSubCatagoryService)
        {
            BrandTypeService = brandTypeService;
            ItemService = itemService;
            ItemCategoryService = itemCategoryService;
            ItemUnitTypeService = itemUnitTypeService;
            ModelTypeService = modelTypeService;
            ItemSubCatagoryService = itemSubCatagoryService;
        }

        public IBrandTypeService BrandTypeService { get; }
        public IItemService ItemService { get; }
        public IItemCategoryService ItemCategoryService { get; }
        public IItemUnitTypeService ItemUnitTypeService { get; }
        public IModelTypeService ModelTypeService { get; }
        public IItemSubCatagoryService ItemSubCatagoryService { get; }

        public async Task<IActionResult> Index()
        {
            var itemInfo = new ItemViewModel();
            itemInfo.BrandList = BrandTypeService.GetList().Result.Result;
            itemInfo.CategoryList = ItemCategoryService.GetList().Result.Result;
            itemInfo.UnitList = ItemUnitTypeService.GetList().Result.Result;


            itemInfo.ModelTypeList = ModelTypeService.Search(new Core.DTO.SearchContext.SearchModelTypeCntxDto()
            {
                BrandTypeId = itemInfo.BrandId,
                Title = "",
                Take = 25
            }).Result.Result;

            itemInfo.SubCategoryList = ItemSubCatagoryService.Search(new Core.DTO.SearchContext.SearchItemSubCatagoryCntxDto()
            {
                ItemCategoryId = itemInfo.CategoryId,
                Title = "",
                Take = 25
            }).Result.Result;

            return View(itemInfo);
        }

        public async Task<IActionResult> Insert()
        {
            var itemInfo = new ItemViewModel();
            itemInfo.BrandList = BrandTypeService.GetList().Result.Result;
            itemInfo.CategoryList = ItemCategoryService.GetList().Result.Result;
            itemInfo.UnitList = ItemUnitTypeService.GetList().Result.Result;
            return View(itemInfo);
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await ItemService.Get(id);
            var itemInfo = new ItemViewModel();
            itemInfo.BrandList = BrandTypeService.GetList().Result.Result;
            itemInfo.CategoryList = ItemCategoryService.GetList().Result.Result;
            itemInfo.UnitList = ItemUnitTypeService.GetList().Result.Result;
            itemInfo.Title=result.Result.Title;
            itemInfo.Id=result.Result.Id;   
            itemInfo.StandardCode=result.Result.StandardCode;
            itemInfo.InternalCode=result.Result.InternalCode;
            itemInfo.Description=result.Result.Description;
            itemInfo.SubCategoryId = result.Result.ItemSubCatagoryId;
            itemInfo.ModelId = result.Result.ModelTypeId;
            itemInfo.UnitId = result.Result.ItemUnitTypeId;

            itemInfo.BrandId = ModelTypeService.Get(result.Result.ModelTypeId).Result.Result.BrandTypeId;
            itemInfo.CategoryId = ItemSubCatagoryService.Get(result.Result.ItemSubCatagoryId).Result.Result.ItemCatagoryId;

            itemInfo.ModelTypeList = ModelTypeService.Search(new Core.DTO.SearchContext.SearchModelTypeCntxDto()
            {
                BrandTypeId = itemInfo.BrandId,
                Title = "",
                Take = 25
            }).Result.Result;

            itemInfo.SubCategoryList = ItemSubCatagoryService.Search(new Core.DTO.SearchContext.SearchItemSubCatagoryCntxDto()
            {
                ItemCategoryId= itemInfo.CategoryId,
                Title="",
                Take=25
            }).Result.Result;

            return View(itemInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string title, string standardCode, string internalCode, int modelId, int subCategoryId, int unitId, string description)
        {
            try
            {
                var result = await ItemService.Update(new UpdateItemDto()
                {
                    Id = id,
                    Title = title,
                    InternalCode = internalCode,
                    StandardCode = standardCode,
                    ItemSubCatagoryId = subCategoryId,
                    ItemUnitTypeId = unitId,
                    ModelTypeId = modelId,
                    Description = description,
                });
                return Json(new { status = true, message = "ویرایش با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }


        [HttpPost]
        public async Task<IActionResult> Insert(string title, string standardCode, string internalCode, int modelId, int SubCategoryId , int unitId,string description)
        {
            try
            {
                var result = await ItemService.Insert(new InsertItemDto()
                {
                    Title = title,
                    InternalCode = internalCode,
                    StandardCode=standardCode,
                    ItemSubCatagoryId=SubCategoryId,
                    ItemUnitTypeId=unitId,
                    ModelTypeId=modelId,
                    Description=description
                });
                return Json(new { status = true, message = "ثبت با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }
        }

        [HttpPost]
        public async Task<IActionResult> Search(int draw, int start, int length, string title="",string standardCode="",string internalCode="",string model="",string subCategory="",string unit="")
        {
            var modelList = ModelTypeService.GetList().Result.Result;
            var subCategoryList = ItemSubCatagoryService.GetList().Result.Result;
            var UnitList= ItemUnitTypeService.GetList().Result.Result;
            var ViewModelResultList= new List<ItemViewModel>();
            var resultList = await ItemService.Search(new Core.DTO.SearchContext.SearchItemCntxDto()
            {
                Title = title,
                StandardCode = standardCode,
                InternalCode=internalCode,
                ItemSubCatagory=subCategory,
                ItemUnitType=unit,
                ModelType=model,
                Description = "",
                Skip = start,
                Take = length,
                IsActive = true,
            });

            foreach (var item in resultList.Result)
            {
                ViewModelResultList.Add(new ItemViewModel()
                {
                    Id=item.Id,
                    Title=item.Title,
                    Description=item.Description,
                    StandardCode=item.StandardCode,
                    InternalCode=item.InternalCode,
                    ModelName=modelList.Where(a=>a.Id==item.ModelTypeId).FirstOrDefault().Title,
                    ModelId=item.ModelTypeId,
                    SubCategoryId=item.ItemSubCatagoryId,
                    SubCategoryName=subCategoryList.Where(a=>a.Id==item.ItemSubCatagoryId).FirstOrDefault().Title,
                    UnitId=item.ItemUnitTypeId,
                    UnitName=UnitList.Where(a => a.Id == item.ItemUnitTypeId).FirstOrDefault().Title,
                    IsActive=item.IsActive,
                });
            }
            return Ok(PaginationUtilities.GenerateData(draw, resultList.TotalCount,resultList.Result.Count, ViewModelResultList));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await ItemService.Delete(id);
                return Json(new { status = true, message = "حذف با موفقیت انجام شد کمی بعد به لیست کاربران منتقل می شوید" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });

            }

        }

    }
}
