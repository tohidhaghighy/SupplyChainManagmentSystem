using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class SupplierItemRepository : EFRepositoryBase<SchmDbContext, SupplierItem>, ISupplierItemRepository
    {
        public SupplierItemRepository(SchmDbContext context) : base(context)
        {
        }
        public async Task<List<SupplierItem>> GetSupplierItems(int supplierId)
        {
          return  _dbContext.Set<SupplierItem>().Include(z => z.Supplier).Include(a=>a.Item).Where(a=>(a.SupplierId==supplierId || supplierId==0)).ToList();
        }

        public async Task<List<SupplierItem>> GetSupplierItemsExistInInventory(int supplierId)
        {
            return _dbContext.Set<SupplierItem>().Include(z => z.Supplier).Include(a => a.Item).Include(a=>a.Item.ModelType).Include(a=>a.Item.ItemSubCatagory).Include(a=>a.Item.ModelType.BrandType)
                .Include(a=>a.Item.ItemSubCatagory.ItemCatagory).Where(a => (a.SupplierId == supplierId || supplierId == 0) && a.InventoryCount>0 && a.Price>0).ToList();
        }

        public async Task<List<SupplierItem>> GetItemsSupplierList(int itemId)
        {
            return _dbContext.Set<SupplierItem>().Include(z => z.Supplier).Include(a => a.Item).Where(a => (a.ItemId == itemId) && a.InventoryCount > 0 && a.Price > 0).ToList();
        }
    }
}
