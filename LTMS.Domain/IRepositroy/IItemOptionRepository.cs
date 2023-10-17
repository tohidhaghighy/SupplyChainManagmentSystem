using Framework.Persistance;
using Schm.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schm.Domain.IRepositroy
{
    public interface IItemOptionRepository : IRepository<ItemOption>
    {
        Task<List<ItemOption>> GetItemOption(int itemId);
    }
}
