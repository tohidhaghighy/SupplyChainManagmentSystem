using Schm.Core.DTO.Request.Option;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IOptionGroupTypeService
    {
        Task<ResponseBody<List<OptionGroupType>>> GetList();
        Task<ResponseBody<List<OptionGroupType>>> Search(SearchOptionTypeCntxDto SearchCntx);
        Task<ResponseBody<OptionGroupType>> Get(int id);
        Task<ResponseBody<OptionGroupType>> Insert(InsertOptionTypeDto option);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
