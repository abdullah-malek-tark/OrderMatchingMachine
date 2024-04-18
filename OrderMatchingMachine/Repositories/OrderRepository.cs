using OrderMatchingMachine.Domain;

namespace OrderMatchingMachine.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static readonly Dictionary<string, Order> _orders = new Dictionary<string, Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order.OrderId, order);
        }

        public void AddTradeToOrders(Trade trade, List<Order> orders)
        {
            orders.ForEach(order =>
            {
                order.IsTraded = true;
                order.Trade = trade;
            });
        }

        public List<Order> GetMatchingBuyOrder(Order order)
        {
            var matchedOrders = _orders.Where(o => o.Value.OrderType == OrderType.BID && !o.Value.IsTraded && o.Value.CompanyName.Equals(order.CompanyName) && !o.Value.UserName.Equals(order.UserName)).Select(o => o.Value).ToList();

            return matchedOrders;
        }

        public List<Order> GetMatchingSellOrder(Order order)
        {
            var matchedOrders = _orders.Where(o => o.Value.OrderType == OrderType.OFFER && !o.Value.IsTraded && o.Value.CompanyName.Equals(order.CompanyName) && !o.Value.UserName.Equals(order.UserName)).Select(o => o.Value).ToList();

            return matchedOrders;
        }
    }
}
