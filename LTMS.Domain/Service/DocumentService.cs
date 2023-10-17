using LTMS.Domain.Service;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;

namespace Schm.Domain.Service
{
    public class DocumentService : BaseCrudService<Document>, IDocumentService
    {
        private IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository repository) : base(repository)
        {
            _documentRepository = repository;
        }
    }
}
