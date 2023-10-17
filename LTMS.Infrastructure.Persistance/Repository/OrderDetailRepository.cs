using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class OrderDetailRepository : EFRepositoryBase<SchmDbContext, OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
