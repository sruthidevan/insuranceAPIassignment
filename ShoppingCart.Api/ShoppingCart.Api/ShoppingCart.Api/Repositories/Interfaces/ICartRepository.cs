using System.Threading.Tasks;
using InsuranceCalculator.Api.Models.Data;
using InsuranceCalculator.Api.Models.Dto.Carts;

namespace InsuranceCalculator.Api.Repositories.Interfaces
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
