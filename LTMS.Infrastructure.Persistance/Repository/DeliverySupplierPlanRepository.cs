using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class DeliverySupplierPlanRepository : EFRepositoryBase<SchmDbContext, DeliverySupplierPlan>, IDeliverySupplierPlanRepository
    {
        public DeliverySupplierPlanRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
