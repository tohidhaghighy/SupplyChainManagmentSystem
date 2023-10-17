using Framework.Persistance;
using Schm.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schm.Domain.IRepositroy
{
    public interface ISubDocumentRepository : IRepository<SubDocument>
    {
        Task<List<SubDocument>> GetSubDocumentwithItem(int documentId);
    }
}
