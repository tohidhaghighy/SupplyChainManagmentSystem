using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class SupplierRepository : EFRepositoryBase<SchmDbContext, Supplier>, ISupplierRepository
    {
        public SupplierRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
