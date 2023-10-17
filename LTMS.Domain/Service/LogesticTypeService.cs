using LTMS.Domain.Service;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;

namespace Schm.Domain.Service
{
    public class LogesticTypeService : BaseCrudService<LogesticType>, ILogesticTypeService
    {
        private ILogesticTypeRepository _logesticTypeRepository;
        public LogesticTypeService(ILogesticTypeRepository repository) : base(repository)
        {
            _logesticTypeRepository = repository;
        }
    }
}
