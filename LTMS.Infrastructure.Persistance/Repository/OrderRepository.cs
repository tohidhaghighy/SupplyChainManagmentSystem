using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class OrderRepository : EFRepositoryBase<SchmDbContext, Order>, IOrderRepository
    {
        public OrderRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
