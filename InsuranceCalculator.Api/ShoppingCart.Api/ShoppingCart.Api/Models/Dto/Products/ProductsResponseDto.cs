using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Api.Models.Dto.Products
{
    public class ProductsResponseDto
    {
        public List<ProductResponseDto> Products { get; }

        public ProductsResponseDto(IEnumerable<ProductResponseDto> products)
        {
            Products = products.ToList();
        }
    }
}
