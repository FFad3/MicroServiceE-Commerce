using System.ComponentModel.DataAnnotations;

namespace ProductService.Dtos
{
    public record NewProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
    }
}
