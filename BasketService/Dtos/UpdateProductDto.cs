using System.ComponentModel.DataAnnotations;

namespace BasketService.Dtos
{
    public class UpdateProductDto
    {
        [Required]
        public string Id { get; set; } = default!;

        [Required]
        public string? Name { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}