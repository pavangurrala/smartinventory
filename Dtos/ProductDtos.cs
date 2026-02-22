namespace SmartInventory.Api.Dtos
{
    public sealed record ProductDtos(
     Guid Id,
     string Name,
     string?Sku,
     decimal Price,
     int Quantity,
     DateTimeOffset CreatedAtUtc
     );
    public sealed record CreatedProductRequest(
     string Name,
     string?Sku,
     decimal Price,
     int Quantity
    );
    public sealed record UpdateProductRequest(
     string Name,
     string?Sku,
     decimal Price,
     int Quantity
    );
}
