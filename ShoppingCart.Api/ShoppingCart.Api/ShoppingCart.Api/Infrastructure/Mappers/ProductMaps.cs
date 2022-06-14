using AutoMapper;
using InsuranceCalculator.Api.Models.Data;
using InsuranceCalculator.Api.Models.Dto.Products;

namespace InsuranceCalculator.Api.Infrastructure.Mappers
{
    public class ProductMaps : Profile
    {
        public ProductMaps()
        {
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
