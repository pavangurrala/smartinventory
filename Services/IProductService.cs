using SmartInventory.Api.Dtos;
using SmartInventory.Api.Dtos.Queries;
namespace SmartInventory.Api.Services
{
    public interface IProductService
    {
        Task<PagedResult<ProductDtos>> GetAsync(ProductQueryParameters parameters);
        Task<ProductDtos?> GetByIdAsync(Guid id);
        Task<ProductDtos> CreateAsync(CreatedProductRequest request);
        Task<ProductDtos?> UpdateAsync(Guid id, UpdateProductRequest request);
        Task<bool> DeleteAsync(Guid id);
    }
}
