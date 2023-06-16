using System.ComponentModel.DataAnnotations;
using BasketService.Models;

namespace BasketService.Dtos
{
    public record ShoppingCartDto
    {
        [Required]
        public string Id { get; set; } = string.Empty;

        public List<ShoppingCartItemDto> Items { get; set; } = new List<ShoppingCartItemDto>();

        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    }
}
