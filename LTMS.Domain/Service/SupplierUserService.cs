using LTMS.Domain.Service;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;

namespace Schm.Domain.Service
{
    public class SupplierUserService : BaseCrudService<SupplierUser>, ISupplierUserService
    {
        private ISupplierUserRepository _supplierUserRepository;
        public SupplierUserService(ISupplierUserRepository repository) : base(repository)
        {
            _supplierUserRepository = repository;
        }
    }
}
