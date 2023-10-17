using Schm.Core.DTO.Request.ItemImage;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IItemImageService
    {
        Task<ResponseBody<List<ItemImage>>> GetList(int itemId);
        Task<ResponseBody<ItemImage>> Get(int id);
        Task<ResponseBody<ItemImage>> Insert(InsertItemImageDto itemImage, IFormFile image);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
