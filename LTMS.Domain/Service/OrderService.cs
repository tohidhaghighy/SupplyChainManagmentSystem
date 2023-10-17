using LTMS.Domain.Service;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;

namespace Schm.Domain.Service
{
    public class OrderService : BaseCrudService<Order>, IOrderService
    {
        private IOrderRepository _orderRepository;
        public OrderService(IOrderRepository repository) : base(repository)
        {
            _orderRepository = repository;
        }
    }
}
