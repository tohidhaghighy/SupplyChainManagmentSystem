using LTMS.Domain.IService;
using Schm.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schm.Domain.IService
{
    public interface ISubDocumentService : IBaseCrudService<SubDocument>
    {
        Task<List<SubDocument>> GetSubDocumentwithItem(int documentId);
    }
}
