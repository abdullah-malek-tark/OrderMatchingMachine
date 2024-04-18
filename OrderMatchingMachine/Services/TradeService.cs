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
                var matchedOrder = _orderRepository.GetMatchingSellOrder(order).OrderBy(o => o.AddedAt).FirstOrDefault(o => o.Price <= order.Price);
                return matchedOrder;
            }
            else
            {
                var matchedOrder = _orderRepository.GetMatchingBuyOrder(order).OrderBy(o => o.AddedAt).FirstOrDefault(o => o.Price >= order.Price);
                return matchedOrder;
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

        //private static readonly Dictionary<string, Order> _orderStore = new Dictionary<string, Order>();
        //private static List<Order> _orders = new List<Order>();

        //public Trade MatchOrder(Order order)
        //{
        //    if(order.OrderType == OrderType.BID)
        //    {
        //        var matchingSellOrder = _orders.OrderBy(o => o.AddedAt).FirstOrDefault(o => o.OrderType == OrderType.OFFER && o.Price <= order.Price && o.CompanyName.Equals(order.CompanyName));

        //        if(matchingSellOrder != null)
        //        {
        //            _orders.RemoveAll(o => o.OrderId == matchingSellOrder.OrderId);
        //            return new Trade
        //            {
        //                BuyerOrderId = order.OrderId,
        //                SellerOrderId = matchingSellOrder.OrderId,
        //                CompanyName = matchingSellOrder.CompanyName,
        //                Price = matchingSellOrder.Price,
        //            };
        //        }
        //    }
        //    else
        //    {
        //        var buyOrder = _orders.OrderBy(o => o.AddedAt).FirstOrDefault(o => o.OrderType == OrderType.BID && o.Price >= order.Price && o.CompanyName.Equals(order.CompanyName));

        //        if(buyOrder != null)
        //        {
        //            _orders.RemoveAll(o => o.OrderId == buyOrder.OrderId);
        //            return new Trade
        //            {
        //                BuyerOrderId = buyOrder.OrderId,
        //                SellerOrderId = order.OrderId,
        //                CompanyName = buyOrder.CompanyName,
        //                Price = buyOrder.Price,
        //            };
        //        }
        //    }
        //    _orders.Add(order);
        //    DisplayPlacedOrders();
        //    return null;
        //}

        //public List<Trade> MatchOrders(List<Order> orders)
        //{
        //    return orders.Select(MatchOrder)
        //        .Where(trade => trade != null)
        //        .ToList();
        //}

        //private void DisplayPlacedOrders()
        //{
        //    Console.WriteLine("------------------");
        //    foreach (Order o in _orders)
        //    {
        //        Console.WriteLine($"{o.OrderId}, {o.TraderName}, {o.CompanyName}, {o.OrderType}, {o.Price}, {o.AddedAt}");
        //    }
        //    Console.WriteLine("------------------");
        //}
    }
}
