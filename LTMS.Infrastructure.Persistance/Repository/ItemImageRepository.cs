using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class ItemImageRepository : EFRepositoryBase<SchmDbContext, ItemImage>, IItemImageRepository
    {
        public ItemImageRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
