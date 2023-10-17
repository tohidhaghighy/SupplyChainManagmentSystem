using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class ItemRepository : EFRepositoryBase<SchmDbContext, Item>, IItemRepository
    {
        public ItemRepository(SchmDbContext context) : base(context)
        {
        }

        public async Task<Item> GetItemDeteil(int itemId)
        {
            return _dbContext.Set<Item>().Include(z => z.ItemSubCatagory).Include(a => a.ItemSubCatagory.ItemCatagory).Where(a => (a.Id == itemId)).FirstOrDefault();
        }
    }
}
