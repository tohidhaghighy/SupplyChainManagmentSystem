using Schm.Core.DTO.Request.Document;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IDocumentService
    {
        Task<ResponseBody<List<Document>>> GetList(int supplierId);
        Task<ResponseBody<List<Document>>> Search(SearchDocumentCntxDto SearchCntx);
        Task<ResponseBody<Document>> Get(int id);
        Task<ResponseBody<Document>> Insert(InsertDocumentDto option);
        Task<ResponseBody<bool>> Update(UpdateDocumentDto option);
        Task<ResponseBody<bool>> Delete(int id);
        Task<ResponseBody<bool>> Final(int id);
    }
}
