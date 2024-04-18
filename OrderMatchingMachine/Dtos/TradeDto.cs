namespace OrderMatchingMachine.Dtos
{
    public class TradeDto
    {
        public string TradeId { get; set; }
        public string CompanyName { get; set; }
        public string SellerOrderId { get; set; }
        public string BuyerOrderId { get; set; }
        public int Price { get; set; }
        public DateTime TradedAt { get; set; }
    }
}