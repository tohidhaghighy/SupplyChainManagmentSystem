using Schm.Core.DTO.Request.Model;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IModelTypeService
    {
        Task<ResponseBody<List<ModelType>>> GetList();
        Task<ResponseBody<List<ModelType>>> Search(SearchModelTypeCntxDto SearchCntx);
        Task<ResponseBody<ModelType>> Get(int id);
        Task<ResponseBody<ModelType>> Insert(InsertModelTypeDto category);
        Task<ResponseBody<bool>> Update(UpdateModelTypeDto category);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
