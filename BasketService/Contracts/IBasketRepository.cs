using BasketService.Models;

namespace BasketService.Contracts
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasketAsync(string userId, CancellationToken token);
        Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket, CancellationToken token);
        Task DeleteBasketAsync(string userId, CancellationToken token);
    }
}
