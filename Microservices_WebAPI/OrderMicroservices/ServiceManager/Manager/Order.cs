using DataAccess.IRepository;
using Model;
using ServiceManager.IManager;

namespace ServiceManager.Manager
{
    public class Order : IOrder
    {
        private readonly IOrderRepository _orderRepository;
        public Order(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderModel> GetOrdersForUser(Guid userId)
        {
            dynamic result = _orderRepository.GetOrderForUser(userId);
            return result;
        }


    }
}
