namespace BasketService.Dtos
{
    public record ShoppingCartItemDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
