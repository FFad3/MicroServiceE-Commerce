using System.ComponentModel.DataAnnotations;

namespace OrderService.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = default!;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        [Required]
        public DateTime OrderDate { get; set; }
    }
}
