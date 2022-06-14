using System.Collections.Generic;

namespace InsuranceCalculator.Api.Models.Dto.Carts
{
    public class CartContentsRequestDto
    {
        public List<CartItemRequestDto> Products { get; set; } = new List<CartItemRequestDto>();
    }
}
