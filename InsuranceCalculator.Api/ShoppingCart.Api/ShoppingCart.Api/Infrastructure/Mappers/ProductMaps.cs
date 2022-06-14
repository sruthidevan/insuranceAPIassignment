using AutoMapper;
using ShoppingCart.Api.Models.Data;
using ShoppingCart.Api.Models.Dto.Products;

namespace ShoppingCart.Api.Infrastructure.Mappers
{
    public class ProductMaps : Profile
    {
        public ProductMaps()
        {
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
