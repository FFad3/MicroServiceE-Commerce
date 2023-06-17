using Redis.OM.Modeling;

namespace BasketService.Models
{
    public class ShoppingCartItem
    {
        [Indexed] public string Id { get; set; } = default!;
        [Searchable] public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}