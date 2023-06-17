using BasketService.Dtos;
using BasketService.Models;

namespace BasketService.Contracts
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasketAsync(string userId, CancellationToken token);
        Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket, CancellationToken token);
        Task DeleteBasketAsync(ShoppingCart basket, CancellationToken token);

        //Move to message handler
        Task UpdateProductDataAsync(UpdateProductDto dto, CancellationToken token);
    }
}
