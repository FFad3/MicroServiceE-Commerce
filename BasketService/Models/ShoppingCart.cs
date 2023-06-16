namespace BasketService.Models
{
    public class ShoppingCart
    {
        public string Id { get; set; } = string.Empty;

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    }
}