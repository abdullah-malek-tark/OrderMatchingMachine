using OrderMatchingMachine.Domain;

namespace OrderMatchingMachine.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private static readonly Dictionary<string, Trade> _trades = new Dictionary<string, Trade>();

        public void AddTrade(Trade trade)
        {
            _trades.Add(trade.TradId, trade);
        }
    }
}
