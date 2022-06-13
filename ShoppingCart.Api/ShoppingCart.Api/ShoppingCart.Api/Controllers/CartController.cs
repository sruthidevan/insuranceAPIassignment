﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Models.Data;
using ShoppingCart.Api.Models.Dto;
using ShoppingCart.Api.Models.Dto.Carts;
using ShoppingCart.Api.Models.Dto.Common;
using ShoppingCart.Api.Repositories.Interfaces;

namespace ShoppingCart.Api.Controllers
{

    [Route("api/carts")]
    [Produces("application/json")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartController(ICartRepository cartRepository, 
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new cart
        /// </summary>
        /// <remarks>
        /// Sample request with no cart items:
        ///
        ///     Post /api/carts/
        ///
        /// 
        /// Sample request with cart items:
        ///
        ///     Post /api/carts/
        ///     {
        ///         "cartContents": [
        ///             {
        ///                 "id": "13a9cd0b-dbfc-47d0-ab25-43e6d2aac375",
        ///                 "quantity": 3
        ///             }
        ///         ]
        ///     }
        /// 
        /// </remarks>
        /// <returns>Cart</returns>
        /// <response code="201">Returns the created cart</response>
        [ProducesResponseType(201, Type = typeof(CartResponseDto))]
        [HttpPost]
        public async Task<IActionResult> CreateNewCartAsync(
            [FromBody] CartContentsRequestDto cartContents
            )
        {
            var cart = await _cartRepository.CreateShoppingCartAsync(cartContents);
            var result = _mapper.Map<CartResponseDto>(cart);
            return CreatedAtRoute("GetCartByIdAsync", new { cartId = cart.ProductId }, result);
        }

        /// <summary>
        /// Updates an existing cart (replacing all line items)
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request with cart items:
        ///
        ///     Post /api/carts/{cartId}
        ///     {
        ///         "cartContents": [
        ///             {
        ///                 "id": "13a9cd0b-dbfc-47d0-ab25-43e6d2aac375",
        ///                 "quantity": 3
        ///             }
        ///         ]
        ///     }
        /// 
        /// </remarks>
        /// <returns>Cart</returns>
        /// <response code="200">Returns the updated cart</response>
        /// <response code="404">Cart not found</response>
        [ProducesResponseType(200, Type = typeof(CartResponseDto))]
        [ProducesResponseType(404)]
        [HttpPut("{cartId:int}")]
        public async Task<IActionResult> UpdateCartAsync(
            int cartId,
            [FromBody] CartContentsRequestDto cartContents)
        {
            var cart = await _cartRepository.UpdateShoppingCartAsync(cartId, cartContents);
            if (cart == null)
                return NotFound();

            var result = _mapper.Map<CartResponseDto>(cart);
            return Ok(result);
        }


        /// <summary>
        /// Returns an existing cart
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request with cart items:
        ///
        ///     GET /api/carts/{cartId}
        /// 
        /// </remarks>
        /// <returns>Cart</returns>
        /// <response code="200">Returns the cart</response>
        /// <response code="404">Cart not found</response>
        [ProducesResponseType(200, Type = typeof(CartResponseDto))]
        [ProducesResponseType(404)]
        [HttpGet("{cartId:int}", Name = "GetCartByIdAsync")]
        public async Task<IActionResult> GetCartByIdAsync(int cartId)
        {
            var cart = await _cartRepository.FindByIdAsync(cartId);
            if (cart == null)
                return NotFound();

            var result = _mapper.Map<CartResponseDto>(cart);
            return Ok(result);
        }


        /// <summary>
        /// Removes an existing cart
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        ///
        ///     DELETE /api/carts/{cartId}
        /// 
        /// </remarks>
        /// <returns>Cart</returns>
        /// <response code="204">No Content Response</response>
        /// <response code="404">Cart not found</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("{cartId:int}")]
        public async Task<IActionResult> RemoveCartByIdAsync(int cartId)
        {
            var cart = await _cartRepository.FindByIdAsync(cartId);
            if (cart == null)
                return NotFound();

            await _cartRepository.RemoveShoppingCartAsync(cartId);
            return NoContent();
        }


    }
}
