using Framework.Persistance;
using Schm.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schm.Domain.IRepositroy
{
    public interface ISupplierItemRepository : IRepository<SupplierItem>
    {
        Task<List<SupplierItem>> GetSupplierItems(int supplierId);
        Task<List<SupplierItem>> GetSupplierItemsExistInInventory(int supplierId);
        Task<List<SupplierItem>> GetItemsSupplierList(int itemId);
    }
}
