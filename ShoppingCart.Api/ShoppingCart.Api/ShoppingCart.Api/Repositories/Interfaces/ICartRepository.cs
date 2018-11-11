﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Api.Models.Data;
using ShoppingCart.Api.Models.Dto.Cart;

namespace ShoppingCart.Api.Repositories.Interfaces
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Task<Cart> CreateShoppingCartAsync(CartContentsRequestDto cartContentsRequest);
        Task<Cart> UpdateShoppingCartAsync(Guid cartId, CartContentsRequestDto cartContentsRequest);
        Task RemoveShoppingCartAsync(Guid cartId);
        Task<Cart> RemoveShoppingCartItemAsync(Guid cartId, Guid itemId);
        Task<Cart> IncreaseShoppingCartItemAsync(Guid cartId, Guid itemId, decimal quantity);
        Task<Cart> DecreaseShoppingCartItemAsync(Guid cartId, Guid itemId, decimal quantity);
    }
}
