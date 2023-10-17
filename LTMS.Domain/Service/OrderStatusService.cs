using LTMS.Domain.Service;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;

namespace Schm.Domain.Service
{
    public class OrderStatusService : BaseCrudService<OrderStatus>, IOrderStatusService
    {
        private IOrderStatusRepository _orderStatusRepository;
        public OrderStatusService(IOrderStatusRepository repository) : base(repository)
        {
            _orderStatusRepository = repository;
        }
    }
}
