using OrderMatchingMachine.Domain;

namespace OrderMatchingMachine.Services
{
    public interface ITradeService
    {
        public bool TryExecuteTradeForOrder(Order order, out Order updatedOrder);

        //Trade MatchOrder(Order order);
        //List<Trade> MatchOrders(List<Order> orders);
    }
}
