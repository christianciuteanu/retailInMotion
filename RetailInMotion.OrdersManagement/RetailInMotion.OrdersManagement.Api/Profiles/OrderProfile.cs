using AutoMapper;
using RetailInMotion.OrdersManagement.Api.DTOs;
using RetailInMotion.OrdersManagement.Core.Aggregates;

namespace RetailInMotion.OrdersManagement.Api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ReverseMap();
        }
    }
}
