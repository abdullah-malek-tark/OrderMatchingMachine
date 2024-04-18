﻿using OrderMatchingMachine.Domain;
using System.Text.Json.Serialization;

namespace OrderMatchingMachine.Dtos
{
    public class OrderRequestDto
    {
        public string OrderId { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderType OrderType { get; set; }
        public int Price { get; set; }
    }
}
