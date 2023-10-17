using LTMS.Core.GenericDataResponse;
using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Response.Shop;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : Controller
    {
        IItemOptionService _itemOptionService;
        IItemService _itemService;
        ISupplierItemService _supplierItemService;
        IItemImageService _itemImageService;

        public ShopController(IItemOptionService itemOptionService ,IItemService itemService,ISupplierItemService supplierItemService, IItemImageService itemImageService)
        {
            _itemOptionService = itemOptionService;
            _itemService = itemService;
            _supplierItemService = supplierItemService;
            _itemImageService = itemImageService;
        }

        [HttpGet("{itemId}")]
        public async Task<IActionResult> Get(int itemId)
        {
            var response = new ShopItemResponseDto();
            var result = _itemService.GetItemDeteil(itemId);
            if (result.Result == null)
            {
                return NotFound();
            }
            response.Id = result.Result.Id;
            response.Title = result.Result.Title;
            response.Code = result.Result.InternalCode;
            response.CategoryName = result.Result.ItemSubCatagory.ItemCatagory.Title;
            response.SubCategoryName = result.Result.ItemSubCatagory.Title;
            response.Image = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value.ToString() +
                    "/img/defaultImage.png";
            var imageresult = _itemImageService.FindBy(a => a.ItemId == itemId);
            if (imageresult.Result.Count() > 0)
                response.Image = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value.ToString() + imageresult.Result.FirstOrDefault().ImageUrl;
            var supplierList = _supplierItemService.GetItemsSupplierList(itemId);
            var SupplierItemList = new List<SupplierItemResponseDto>();
            foreach (var supplier in supplierList.Result)
            {
                SupplierItemList.Add(new SupplierItemResponseDto()
                {
                    Cost=supplier.Price,
                    InventoryCount=supplier.InventoryCount,
                    SupplierId=supplier.SupplierId,
                    SupplierName=supplier.Supplier.Name
                });
            }
            response.SupplierItem = SupplierItemList;
            var responseOptionList=new List<string>();
            var optionList = _itemOptionService.GetItemOption(itemId);
            foreach (var item in optionList.Result)
            {
                responseOptionList.Add(item.OptionGroupType.Title+" : "+item.OptionType.Title);
            }
            response.Options = responseOptionList;
            await Task.CompletedTask;
            return Ok(response);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchShopCntxDto SearchCntx)
        {
            var responseList=new List<ShopItemResponseDto>();
            var result = await _supplierItemService.GetSupplierItemsExistInInventory(0);
            result = result.Where(a=>a.IsExist && a.IsActive && a.Item.Title.Contains(SearchCntx.Text) &&
            (a.Item.ModelType.BrandType.Id==SearchCntx.BrandId || SearchCntx.BrandId==0) && 
            (a.Item.ItemSubCatagoryId==SearchCntx.SubCategoryId || SearchCntx.SubCategoryId==0) &&
            (a.Item.ItemSubCatagory.ItemCatagory.Id == SearchCntx.CategoryId || SearchCntx.CategoryId == 0) &&
            (a.Price>SearchCntx.MinCost)).ToList();
            if (SearchCntx.MaxCost>0)
            {
                result = result.Where(a => a.Price < SearchCntx.MaxCost).ToList();
            }
            int TotalCount = result.Count;
            result = result.OrderByDescending(a => a.Id).Skip(SearchCntx.Skip).Take(SearchCntx.Take).ToList();
            var searchList = new DataResponse<dynamic>();
            searchList.TotalCount = TotalCount;
            foreach (var item in result)
            {
                string image = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value.ToString() +
                    "/img/defaultImage.png";
                var imageresult = _itemImageService.FindBy(a => a.ItemId == item.Id);
                if (imageresult.Result.Count() > 0)
                    image = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value.ToString() + imageresult.Result.FirstOrDefault().ImageUrl;
                item.DefaultImage = image;
            }
            searchList.Result = result.Select(a => new
            {
                a.Id,
                SupplierName = a.Supplier.Name,
                ItemName = a.Item.Title,
                ItemCode = a.Item.InternalCode,
                Price = a.Price,
                InventoryCount = a.InventoryCount,
                a.SupplierId,
                a.ItemId,
                a.IsActive,
                a.IsExist,
                a.ViewerCount,
                a.UpdatedDate,
                a.DefaultImage
            });
            await Task.CompletedTask;
            return Ok(searchList);
        }
    }
}
