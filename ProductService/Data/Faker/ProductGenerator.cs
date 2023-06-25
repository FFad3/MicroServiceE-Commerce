using Bogus;
using ProductService.Models;

namespace ProductService.Data.Faker
{
    public class ProductGenerator : Faker<Product>
    {
        public ProductGenerator()
        {
            var id = 1;
            UseSeed(1969)
                .RuleFor(p => p.Id, _ => id++)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => f.Commerce.Price(1).First());
        }
    }
}
