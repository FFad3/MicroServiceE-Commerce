using AutoMapper;
using Messages.Messages;
using ProductService.Dtos;
using ProductService.Models;

namespace ProductService.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<NewProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<Product, UpdateProductMessage>();
        }
    }
}