using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class ItemOptionRepository : EFRepositoryBase<SchmDbContext, ItemOption>, IItemOptionRepository
    {
        public ItemOptionRepository(SchmDbContext context) : base(context)
        {
        }

        public async Task<List<ItemOption>> GetItemOption(int itemId)
        {
            return _dbContext.Set<ItemOption>().Include(z => z.Item).Include(a => a.OptionType).Include(a=>a.OptionGroupType).Where(a => a.ItemId == itemId).ToList();
        }
    }
}
