using LTMS.Core.GenericDataResponse;
using Microsoft.AspNetCore.Mvc;
using Schm.Core.DTO.Request.SupplierItem;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.IService;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierItemController : Controller
    {
        ISupplierItemService _supplierItemService;
        IItemImageService _itemImageService;

        public SupplierItemController(ISupplierItemService supplierItemService, IItemImageService itemImageService)
        {
            _supplierItemService = supplierItemService;
            _itemImageService = itemImageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _supplierItemService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList(int supplierId)
        {
            var result = await _supplierItemService.GetSupplierItems(supplierId);
            var searchList = new DataResponse<dynamic>();
            searchList.TotalCount = _supplierItemService.GetAll().TotalCount;
            searchList.Result = result.OrderByDescending(a => a.Id).Select(a => new
            {
                a.Id,
                SupplierName = a.Supplier.Name,
                ItemName = a.Item.Title,
                ItemCode = a.Item.InternalCode,
                Price= a.Price,
                InventoryCount = a.InventoryCount,
                a.SupplierId,
                a.ItemId,
                a.IsActive,
                a.IsExist,
                a.ViewerCount,
                a.UpdatedDate
            });
            await Task.CompletedTask;
            return Ok(searchList);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchSupplierItemCntxDto SearchCntx)
        {
            var result = await _supplierItemService.GetSupplierItems(SearchCntx.SupplierId);
            int TotalCount = result.Count;
            result = result.OrderByDescending(a=>a.Id).Skip(SearchCntx.Skip).Take(SearchCntx.Take).ToList();
            var searchList= new DataResponse<dynamic>();
            searchList.TotalCount = TotalCount;
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
                a.UpdatedDate
            });
            await Task.CompletedTask;
            return Ok(searchList);
        }


        [HttpPost("SearchForStore")]
        public async Task<IActionResult> SearchForStore(SearchSupplierItemCntxDto SearchCntx)
        {
            var result = await _supplierItemService.GetSupplierItemsExistInInventory(SearchCntx.SupplierId);
            int TotalCount = result.Count;
            result = result.OrderByDescending(a => a.Id).Skip(SearchCntx.Skip).Take(SearchCntx.Take).ToList();
            var searchList = new DataResponse<dynamic>();
            searchList.TotalCount = TotalCount;
            foreach (var item in result)
            {
               string image = HttpContext.Request.Scheme +"://" + HttpContext.Request.Host.Value.ToString() +
                    "/img/defaultImage.png";
                var imageresult = _itemImageService.FindBy(a => a.ItemId == item.ItemId);
                if (imageresult.Result.Count() >  0)
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
                Image=a.DefaultImage
            });
            
            await Task.CompletedTask;
            return Ok(searchList);
        }


        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertSupplierItemDto SupplierItem)
        {
            var result = _supplierItemService.Insert(new Domain.Model.SupplierItem()
            {
                SupplierId = SupplierItem.SupplierId,
                Price = SupplierItem.Price,
                InventoryCount= SupplierItem.InventoryCount,
                IsActive= SupplierItem.IsActive,
                IsExist= SupplierItem.IsExist,
                ItemId = SupplierItem.ItemId,   
            });
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateSupplierItemDto SupplierItem)
        {
            var item = _supplierItemService.FindById(SupplierItem.Id);
            if (item.IsSuccess == false)
            {
                return Ok(item);
            }

            item.Result.Price = SupplierItem.Price;
            item.Result.InventoryCount = SupplierItem.InventoryCount;

            var result = _supplierItemService.Update(item.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = _supplierItemService.FindById(id);
            if (item.IsSuccess == false)
            {
                return Ok(item);
            }
            var result = _supplierItemService.Remove(item.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Active/{id}")]
        public async Task<IActionResult> Active(int id)
        {
            var item = _supplierItemService.FindById(id);
            if (item.IsSuccess == false)
            {
                return Ok(item);
            }
            item.Result.IsActive = !item.Result.IsActive;
            var result = _supplierItemService.Update(item.Result);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpPost("Exist/{id}")]
        public async Task<IActionResult> Exist(int id)
        {
            var item = _supplierItemService.FindById(id);
            if (item.IsSuccess == false)
            {
                return Ok(item);
            }

            item.Result.IsExist = !item.Result.IsExist;
            var result = _supplierItemService.Update(item.Result);
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
