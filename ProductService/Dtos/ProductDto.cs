using System.ComponentModel.DataAnnotations;

namespace ProductService.Dtos
{
    public record ProductDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
    }
}
