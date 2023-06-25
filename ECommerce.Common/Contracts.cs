using System.Reflection;

namespace ECommerce.Common
{
    public abstract record MessageBase()
    {
        public string Sender => Assembly.GetEntryAssembly()?.GetName().Name ?? "";
    }
    public record ProductItemUpdated(int Id, string Name, decimal Price) : MessageBase;

    public record ProductItemDeleted(int Id) : MessageBase;

    public record OrderPlaced(string UserId, OrderItem[] Items, DateTime OrderDate) : MessageBase
    {
        public decimal TotalPrice => Items.Sum(x => x.SubTotal);
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal => Price * Quantity;
    }
}