namespace SmartInventory.Api.Domain
{
    public sealed class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public string? Sku { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset CreatedAtUtc { get; set; } = DateTimeOffset.UtcNow;

    }
}
