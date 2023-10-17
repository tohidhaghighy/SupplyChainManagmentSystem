using LTMS.Domain.Service;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;

namespace Schm.Domain.Service
{
    public class SupplierService : BaseCrudService<Supplier>, ISupplierService
    {
        private ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository repository) : base(repository)
        {
            _supplierRepository = repository;
        }
    }
}
