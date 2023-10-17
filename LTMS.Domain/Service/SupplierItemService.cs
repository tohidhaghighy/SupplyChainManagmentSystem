using LTMS.Domain.Service;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schm.Domain.Service
{
    public class SupplierItemService : BaseCrudService<SupplierItem>, ISupplierItemService
    {
        private ISupplierItemRepository _supplierItemRepository;
        public SupplierItemService(ISupplierItemRepository repository) : base(repository)
        {
            _supplierItemRepository = repository;
        }

        public async Task<List<SupplierItem>> GetItemsSupplierList(int itemId)
        {
            return await _supplierItemRepository.GetItemsSupplierList(itemId);
        }

        public async Task<List<SupplierItem>> GetSupplierItems(int supplierId)
        {
          return  await _supplierItemRepository.GetSupplierItems(supplierId);
        }

        public async Task<List<SupplierItem>> GetSupplierItemsExistInInventory(int supplierId)
        {
            return await _supplierItemRepository.GetSupplierItemsExistInInventory(supplierId);
        }
    }
}
