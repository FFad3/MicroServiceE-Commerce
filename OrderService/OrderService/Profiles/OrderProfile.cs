using AutoMapper;
using OrderService.Models;

namespace OrderService.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<ECommerce.Common.OrderPlaced, Order>();
        }
    }
}

