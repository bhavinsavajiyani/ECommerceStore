using AutoMapper;
using EComm_Store_API.DTOs;
using EComm_Store_Core.Entities;
using EComm_Store_Core.Entities.Basket;
using EComm_Store_Core.Entities.Identity;

namespace EComm_Store_API.Utilities
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(p => p.ProductBrand, q => q.MapFrom(s => s.ProductBrand.Name))
                .ForMember(p => p.ProductType, q => q.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureURL, o => o.MapFrom<ProductURLResolver>());

            CreateMap<Address, AddressDTO>().ReverseMap();

            CreateMap<CustomerBasketDTO, CustomerBasket>();

            CreateMap<BasketItemDTO, BasketItem>();
        }
    }
}