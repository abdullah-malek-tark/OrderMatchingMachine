using OrderMatchingMachine.Domain;

namespace OrderMatchingMachine.Repositories
{
    public interface ITradeRepository
    {
        public void AddTrade(Trade trade);
    }
}
