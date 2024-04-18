namespace OrderMatchingMachine.Domain
{
    public class Trade
    {
        public string TradId { get; set; }
        public string CompanyName { get; set; }
        public string SellerOrderId { get; set; }
        public string BuyerOrderId { get; set; }
        public int Price { get; set; }
        public DateTime TradedAt { get; set; }

        public Trade(string companyName, string buyerOrderId, string sellerOrderId, int price)
        {
            CompanyName = companyName;
            BuyerOrderId = buyerOrderId;
            SellerOrderId = sellerOrderId;
            Price = price;
            TradedAt = DateTime.Now;
            TradId = Guid.NewGuid().ToString();
        }
    }
}
