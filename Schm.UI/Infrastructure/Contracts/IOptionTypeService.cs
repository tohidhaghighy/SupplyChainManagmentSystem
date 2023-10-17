using Schm.Core.DTO.Request.Option;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IOptionTypeService
    {
        Task<ResponseBody<List<OptionType>>> GetList();
        Task<ResponseBody<List<OptionType>>> Search(SearchOptionTypeCntxDto SearchCntx);
        Task<ResponseBody<OptionType>> Get(int id);
        Task<ResponseBody<OptionType>> Insert(InsertOptionTypeDto option);
        Task<ResponseBody<bool>> Update(UpdateOptionItemTypeDto option);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
