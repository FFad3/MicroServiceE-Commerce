namespace ECommerce.Common.Settings
{
    public class DbContextSettings
    {
        public bool UseInMemoryDB { get; init; }
        public string InMemoryDBName { get; init; } = null!;
        public string Connection { get; init; } = null!;
    }
}