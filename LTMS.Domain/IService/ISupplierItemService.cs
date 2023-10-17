using LTMS.Domain.IService;
using Schm.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schm.Domain.IService
{
    public interface ISupplierItemService : IBaseCrudService<SupplierItem>
    {
        Task<List<SupplierItem>> GetSupplierItems(int supplierId);
        Task<List<SupplierItem>> GetSupplierItemsExistInInventory(int supplierId);
        Task<List<SupplierItem>> GetItemsSupplierList(int itemId);
    }
}
