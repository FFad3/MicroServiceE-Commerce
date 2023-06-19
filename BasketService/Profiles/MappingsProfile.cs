using AutoMapper;
using BasketService.Dtos;
using BasketService.Models;
using Messages.Messages;

namespace BasketService.Profiles
{
    public class MappingsProfile :Profile
    {
        public MappingsProfile()
        {
            CreateMap<ShoppingCartItem, ShoppingCartItemDto>().ReverseMap();
            CreateMap<ShoppingCartWriteDto, ShoppingCart>();
            CreateMap<ShoppingCart, ShoppingCartReadDto>();
            CreateMap<UpdateProductDto,ShoppingCartItem>();
            CreateMap<UpdateProductMessage, UpdateProductDto>();
        }
    }
}
