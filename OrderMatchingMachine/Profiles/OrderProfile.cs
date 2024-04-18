using AutoMapper;
using OrderMatchingMachine.Domain;
using OrderMatchingMachine.Dtos;

namespace OrderMatchingMachine.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderRequestDto, Order>()
                .ForMember(d => d.AddedAt, mce => mce.MapFrom(s => DateTime.Now));

            CreateMap<Order, OrderResponseDto>()
                .ForMember(d => d.OrderType, mce => mce.MapFrom(src => src.OrderType.ToString()))
                .ForMember(d => d.Trade, mce => mce.MapFrom(s => s.IsTraded ? s.Trade : null));
        }
    }
}
