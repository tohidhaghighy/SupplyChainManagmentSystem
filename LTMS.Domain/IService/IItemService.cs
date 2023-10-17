using LTMS.Domain.IService;
using Schm.Domain.Model;
using System.Threading.Tasks;

namespace Schm.Domain.IService
{
    public interface IItemService : IBaseCrudService<Item>
    {
        Task<Item> GetItemDeteil(int itemId);
    }
}
