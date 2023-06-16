using BasketService.Contracts;
using BasketService.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace BasketService.Services
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task DeleteBasketAsync(string userId, CancellationToken token)
        {
            await _redisCache.RemoveAsync(userId,token);
        }

        public async Task<ShoppingCart> GetBasketAsync(string userId, CancellationToken token)
        {
            var basket = await _redisCache.GetStringAsync(userId, token);

            if (string.IsNullOrEmpty(basket))
                return new ShoppingCart { Id = userId };

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket, CancellationToken token)
        {
            var jsonBasket = JsonConvert.SerializeObject(basket);

            await _redisCache.SetStringAsync(basket.Id, jsonBasket, token); 

            return await GetBasketAsync(basket.Id, token);
        }
    }
}