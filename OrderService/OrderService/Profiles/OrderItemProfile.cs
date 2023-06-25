using AutoMapper;
using OrderService.Models;

namespace OrderService.Profiles
{
    public class OrderItemProfile:Profile
    {
        public OrderItemProfile()
        {
            CreateMap<ECommerce.Common.OrderItem, OrderItem>();
        }
    }
}
