using LTMS.Domain.Service;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;

namespace Schm.Domain.Service
{
    public class PaymentTypeService : BaseCrudService<PaymentType>, IPaymentTypeService
    {
        private IPaymentTypeRepository _paymentTypeRepository;
        public PaymentTypeService(IPaymentTypeRepository repository) : base(repository)
        {
            _paymentTypeRepository = repository;
        }
    }
}
