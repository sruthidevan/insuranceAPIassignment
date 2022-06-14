using AutoMapper;
using InsuranceCalculator.Api.Models.Data;
using InsuranceCalculator.Api.Models.Dto.Carts;

namespace InsuranceCalculator.Api.Infrastructure.Mappers
{
    public class CartMaps : Profile
    {
        public CartMaps()
        {
            CreateMap<Cart, CartResponseDto>();
            CreateMap<CartItemRequestDto, CartItem>().ForMember(dest => dest.CatalogItemId, opt => opt.MapFrom(src => src.Id));
            CreateMap<CartItem, CartItemResponseDto>().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.CatalogItemId));
        }
    }
}
