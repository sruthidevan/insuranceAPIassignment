using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Api.Models.Dto.Carts;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Api.Controllers
{
    [ApiController]
    [Route("api/insurances/")]
    public class InsurancesController : ControllerBase
    {
        public InsurancesController()
        {
        }

        /// <summary>
        /// Calculates and updates the insurance based on business rules on cart contents.
        /// </summary>
        /// <param name="cartContents">The cart data containing products list.</param>
        /// <returns>Updated cart contents with insurance values.</returns>

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(CartResponseDto))]
        public async Task<IActionResult> CalculateInsurance([FromBody] CartContentsRequestDto cartContents)
        {
            var products = new List<CartItemResponseDto>();
            foreach (var item in cartContents.Products)
            {
                var cartItemData = await BusinessRules.GetProductAsync(item.Id, item.Quantity);
                products.Add(cartItemData);
            }

            var hasDigitalCamera = products.Any(p => p.ProductTypeName.Trim().Equals("digital cameras", StringComparison.InvariantCultureIgnoreCase));

            var result = new CartResponseDto
            {
                Products = products
            };

            return Ok(result);
        }
    }
}