using AutoMapper;
using RetailInMotion.OrdersManagement.Core.DTOs;
using RetailInMotion.OrdersManagement.Core.Entities;

namespace RetailInMotion.OrdersManagement.Core.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ReverseMap();
        }
    }
}
