using LTMS.Domain.Service;
using Microsoft.Extensions.Logging;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;
using System.Threading.Tasks;

namespace Schm.Domain.Service
{
    public class ItemService : BaseCrudService<Item>, IItemService
    {
        private IItemRepository _itemRepository;
        public ItemService(IItemRepository repository, ILogger<ItemService> logger) : base(repository)
        {
            _itemRepository = repository;
        }

        public Task<Item> GetItemDeteil(int itemId)
        {
            return _itemRepository.GetItemDeteil(itemId);
        }
    }
}
