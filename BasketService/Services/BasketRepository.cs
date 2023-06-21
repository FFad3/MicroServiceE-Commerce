using AutoMapper;
using BasketService.Contracts;
using BasketService.Dtos;
using BasketService.Models;
using Redis.OM;
using Redis.OM.Searching;

namespace BasketService.Services
{

    public class BasketRepository : IBasketRepository
    {
        private readonly RedisCollection<ShoppingCart> _carts;
        private readonly RedisConnectionProvider _provider;
        private readonly IMapper _mapper;

        public BasketRepository(RedisConnectionProvider provider, IMapper mapper)
        {
            _provider = provider;
            _carts = (RedisCollection<ShoppingCart>)provider.RedisCollection<ShoppingCart>();
            _mapper = mapper;
        }

        public async Task DeleteBasketAsync(ShoppingCart basket)
        {
            await _carts.DeleteAsync(basket);
        }

        public async Task<ShoppingCart> GetBasketAsync(string userId)
        {
            var basket = await _carts.FindByIdAsync(userId);

            if (basket is null)
            {
                return new ShoppingCart { Id = userId };
            }

            return basket;
        }


        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket)
        {
            await _carts.UpdateAsync(basket);

            return await GetBasketAsync(basket.Id);
        }

        public async Task UpdateProductDataAsync(UpdateProductDto dto)
        {
            var carts = await _carts.Where(c => c.ItemsIds.Contains(dto.Id)).ToListAsync();
            foreach (var cart in carts)
            {
                var item = cart.Items.Find(i => i.Id == dto.Id);
                _mapper.Map(dto, item);
            }
            var result = await _carts.InsertAsync(carts);
        }

        public async Task RemoveProductDataAsync(string Id)
        {
            var carts = await _carts.Where(c => c.ItemsIds.Contains(Id)).ToListAsync();
            foreach (var cart in carts)
            {
                var item = cart.Items.RemoveAll(x=>x.Id==Id);
            }
            var result = await _carts.InsertAsync(carts);
        }
    }
}