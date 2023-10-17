using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class ItemUnitTypeRepository : EFRepositoryBase<SchmDbContext, ItemUnitType>, IItemUnitTypeRepository
    {
        public ItemUnitTypeRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
