using System.ComponentModel.DataAnnotations;

namespace BasketService.Dtos
{
    public record ShoppingCartWriteDto
    {
        [Required]
        public string Id { get; set; } = default!;

        public List<ShoppingCartItemDto> Items { get; set; } = new List<ShoppingCartItemDto>();

        public string[] ItemsIds => Items.Select(x => x.Id).ToArray();
    }
}
