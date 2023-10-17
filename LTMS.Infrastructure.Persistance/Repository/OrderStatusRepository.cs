using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class OrderStatusRepository : EFRepositoryBase<SchmDbContext, OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
