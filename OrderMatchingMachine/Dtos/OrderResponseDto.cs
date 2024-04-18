using OrderMatchingMachine.Domain;
using System.Text.Json.Serialization;

namespace OrderMatchingMachine.Dtos
{
    public class OrderResponseDto
    {
        public string OrderId { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string OrderType { get; set; }
        public int Price { get; set; }
        public TradeDto Trade { get; set; }
    }
}
