using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class ItemCatagoryRepository : EFRepositoryBase<SchmDbContext, ItemCatagory>, IItemCatagoryRepository
    {
        public ItemCatagoryRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
