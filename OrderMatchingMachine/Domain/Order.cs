namespace OrderMatchingMachine.Domain
{
    public class Order
    {
        public string OrderId { get; set; } 
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public OrderType OrderType { get; set; }
        public int Price { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsTraded { get; set; }
        public Trade Trade { get; set; }
    }
}