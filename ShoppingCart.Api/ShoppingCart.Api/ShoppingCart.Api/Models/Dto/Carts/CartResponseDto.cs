using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Api.Models.Dto.Common;

namespace ShoppingCart.Api.Models.Dto.Carts
{
    public class CartResponseDto : Resource
    {
        public int Id { get; set; }

        public decimal Total => Products.Sum(x => x.SubTotal);
        public decimal InsuranceTotal => Products.Sum(x => x.InsuranceSubTotal) + AdditionalInsurance;

        public decimal AdditionalInsurance => Products.Any(p => p.ProductTypeName.Trim().Equals("digital cameras", StringComparison.InvariantCultureIgnoreCase)) ? 500m : 0m;

        public List<CartItemResponseDto> Products { get; set; } = new List<CartItemResponseDto>();
    }
}
