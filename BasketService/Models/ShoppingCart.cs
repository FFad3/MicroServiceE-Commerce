using Redis.OM.Modeling;

namespace BasketService.Models
{
    [Document(StorageType = StorageType.Json)]
    public class ShoppingCart
    {
        [RedisIdField][Indexed] public string UserId { get; set; } = string.Empty;

        [Indexed] public string[] ItemsIds { get; set; } = default!;

        [Indexed(CascadeDepth = 1)] public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

    }
}