using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Api.Models.Dto.Carts
{
    public class CartItemRequestDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
