using BasketService.Dtos;
using BasketService.Models;

namespace BasketService.Contracts
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasketAsync(string userId);

        Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket);

        Task DeleteBasketAsync(ShoppingCart basket);

        Task UpdateProductDataAsync(UpdateProductDto dto);

        Task RemoveProductDataAsync(string Id);
    }
}