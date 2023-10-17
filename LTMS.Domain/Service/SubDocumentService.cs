using LTMS.Domain.Service;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schm.Domain.Service
{
    public class SubDocumentService : BaseCrudService<SubDocument>, ISubDocumentService
    {
        private ISubDocumentRepository _subDocumentRepository;
        public SubDocumentService(ISubDocumentRepository repository) : base(repository)
        {
            _subDocumentRepository = repository;
        }


        public async Task<List<SubDocument>> GetSubDocumentwithItem(int documentId)
        {
            return await _subDocumentRepository.GetSubDocumentwithItem(documentId);
        }
    }
}
