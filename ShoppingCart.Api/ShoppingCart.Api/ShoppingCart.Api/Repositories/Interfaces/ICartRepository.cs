using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Api.Models.Data;
using ShoppingCart.Api.Models.Dto.Carts;

namespace ShoppingCart.Api.Repositories.Interfaces
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Task<Cart> CreateShoppingCartAsync(CartContentsRequestDto cartContentsRequest);
        Task<Cart> UpdateShoppingCartAsync(int cartId, CartContentsRequestDto cartContentsRequest);
        Task RemoveShoppingCartAsync(int cartId);
        Task<Cart> RemoveShoppingCartItemAsync(int cartId, int itemId);
        Task<Cart> IncreaseShoppingCartItemAsync(int cartId, int itemId, int quantity);
        Task<Cart> DecreaseShoppingCartItemAsync(int cartId, int itemId, int quantity);
    }
}
