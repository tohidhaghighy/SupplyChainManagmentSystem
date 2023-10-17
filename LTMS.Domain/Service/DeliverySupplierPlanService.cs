using LTMS.Domain.Service;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;

namespace Schm.Domain.Service
{
    public class DeliverySupplierPlanService : BaseCrudService<DeliverySupplierPlan>, IDeliverySupplierPlanService
    {
        private IDeliverySupplierPlanRepository _deliverySupplierPlanRepository;
        public DeliverySupplierPlanService(IDeliverySupplierPlanRepository repository) : base(repository)
        {
            _deliverySupplierPlanRepository = repository;
        }
    }
}
