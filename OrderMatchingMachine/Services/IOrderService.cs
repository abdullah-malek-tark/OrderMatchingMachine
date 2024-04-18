using OrderMatchingMachine.Domain;

namespace OrderMatchingMachine.Services
{
    public interface IOrderService
    {
        public List<Order> ProcessOrder(List<Order> orders);
    }
}
