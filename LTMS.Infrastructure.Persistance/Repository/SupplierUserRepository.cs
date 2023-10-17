using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class SupplierUserRepository : EFRepositoryBase<SchmDbContext, SupplierUser>, ISupplierUserRepository
    {
        public SupplierUserRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
