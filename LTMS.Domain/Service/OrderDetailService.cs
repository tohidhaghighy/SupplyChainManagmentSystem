using LTMS.Domain.Service;
using Microsoft.Extensions.Logging;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;

namespace Schm.Domain.Service
{
    public class OrderDetailService : BaseCrudService<OrderDetail>, IOrderDetailService
    {
        private IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository repository) : base(repository)
        {
            _orderDetailRepository = repository;
        }
    }
}
