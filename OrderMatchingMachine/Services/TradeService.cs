using OrderMatchingMachine.Domain;
using OrderMatchingMachine.Repositories;

namespace OrderMatchingMachine.Services
{
    public class TradeService : ITradeService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITradeRepository _tradeRepository;

        public TradeService(IOrderRepository orderRepository, ITradeRepository tradeRepository)
        {
            _orderRepository = orderRepository;
            _tradeRepository = tradeRepository;
        }

        public bool TryExecuteTradeForOrder(Order order, out Order updatedOrder)
        {
            var matchedOrder = GetMatchingOrder(order);

            if (matchedOrder != null)
            {
                var trade = BuildNewTrade(order, matchedOrder);
                _tradeRepository.AddTrade(trade);
                _orderRepository.AddTradeToOrders(trade, new List<Order> { order, matchedOrder });
            }

            updatedOrder = order;
            return matchedOrder != null;
        }

        private Order GetMatchingOrder(Order order)
        {
            if(order.OrderType == OrderType.BID)
            {
                return _orderRepository.GetMatchingSellOrder(order).OrderBy(o => o.AddedAt).FirstOrDefault(o => o.Price <= order.Price);
            }
            else
            {
                return _orderRepository.GetMatchingBuyOrder(order).OrderBy(o => o.AddedAt).FirstOrDefault(o => o.Price >= order.Price);
            }
        }

        private Trade BuildNewTrade(Order order1, Order order2)
        {
            var buyOrder = order1.OrderType == OrderType.BID ? order1 : order2;
            var sellOrder = order1.OrderType == OrderType.OFFER ? order1 : order2;
            var tradePrice = order1.AddedAt < order2.AddedAt ? order1.Price : order2.Price;

            var trade = new Trade(order1.CompanyName, buyOrder.OrderId, sellOrder.OrderId, tradePrice);

            return trade;
        }
    }
}
