using AutoMapper;
using BasketService.Dtos;
using BasketService.Models;

namespace BasketService.Profiles
{
    public class MappingsProfile :Profile
    {
        public MappingsProfile()
        {
            CreateMap<ShoppingCartItem, ShoppingCartItemDto>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();
        }
    }
}
