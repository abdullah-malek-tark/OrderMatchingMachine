using OrderMatchingMachine.Domain;

namespace OrderMatchingMachine.Repositories
{
    public interface IOrderRepository
    {
        public void AddOrder(Order order);
        public List<Order> GetMatchingSellOrder(Order order);
        public List<Order> GetMatchingBuyOrder(Order order);
        public void AddTradeToOrders(Trade trade, List<Order> orders);
    }
}
