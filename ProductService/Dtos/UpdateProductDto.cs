using System.ComponentModel.DataAnnotations;

namespace ProductService.Dtos
{
    public record UpdateProductDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public decimal? Price { get; set; }
    }
}