using System.ComponentModel.DataAnnotations;

namespace ProductService.Dtos
{
    public record NewProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
    }
}
