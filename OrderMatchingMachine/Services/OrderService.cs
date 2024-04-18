using OrderMatchingMachine.Domain;
using OrderMatchingMachine.Repositories;

namespace OrderMatchingMachine.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITradeService _tradeService;

        public OrderService(IOrderRepository orderRepository, ITradeService tradeService)
        {
            _orderRepository = orderRepository;
            _tradeService = tradeService;
        }

        public List<Order> ProcessOrder(List<Order> orders)
        {
            var processedOrders = new List<Order>();

            foreach (var order in orders)
            {
                _orderRepository.AddOrder(order);
                _tradeService.TryExecuteTradeForOrder(order, out var updatedOrder);
                processedOrders.Add(updatedOrder);
            }

            return processedOrders;
        }
    }
}
