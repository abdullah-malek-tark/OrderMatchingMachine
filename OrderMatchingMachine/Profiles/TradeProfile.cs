using AutoMapper;
using OrderMatchingMachine.Domain;
using OrderMatchingMachine.Dtos;

namespace OrderMatchingMachine.Profiles
{
    public class TradeProfile : Profile
    {
        public TradeProfile()
        {
            CreateMap<Trade, TradeDto>();
        }
    }
}
