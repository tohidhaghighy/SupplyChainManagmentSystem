using Schm.Core.DTO.Request.SubDocument;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.ViewModels;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface ISubDocumentService
    {
        Task<ResponseBody<List<SubDocumentViewModel>>> GetList(int documentId);
        Task<ResponseBody<List<SubDocumentViewModel>>> Search(SearchSubDocumentCntxDto SearchCntx);
        Task<ResponseBody<SubDocument>> Get(int id);
        Task<ResponseBody<SubDocument>> Insert(InsertSubDocumentDto option);
        Task<ResponseBody<bool>> Update(UpdateSubDocumentDto option);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
