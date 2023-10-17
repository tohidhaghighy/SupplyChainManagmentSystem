using LTMS.Domain.IService;
using Schm.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schm.Domain.IService
{
    public interface IItemOptionService : IBaseCrudService<ItemOption>
    {
        Task<List<ItemOption>> GetItemOption(int itemId);
    }
}
