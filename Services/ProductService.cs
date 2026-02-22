using Microsoft.EntityFrameworkCore;
using SmartInventory.Api.Data;
using SmartInventory.Api.Domain;
using SmartInventory.Api.Dtos;
using SmartInventory.Api.Dtos.Queries;
namespace SmartInventory.Api.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly AppDbContext _db;
        public ProductService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<PagedResult<ProductDtos>> GetAsync(ProductQueryParameters parameters)
        {
            var query = _db.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(parameters.Search))
            {
                query = query.Where(p=>p.Name.Contains(parameters.Search));
            }
            if (parameters.MinPrice.HasValue)
            {
                query = query.Where(p=>p.Price>=parameters.MinPrice.Value);
            }
            if (parameters.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price >= parameters.MaxPrice.Value);
            }
            var totalCount = await query.CountAsync();
            var items =  await query
                .OrderByDescending(p => p.CreatedAtUtc)
                .Skip((parameters.PageNumber - 1)  * parameters.PageSize)
                .Take(parameters.PageSize)
                .Select(p => new ProductDtos(
                    p.Id,
                    p.Name,
                    p.Sku,
                    p.Price,
                    p.Quantity,
                    p.CreatedAtUtc)).ToListAsync();
            return new PagedResult<ProductDtos> {
             Items = items,
             TotalCount = totalCount,
             PageNumber = parameters.PageNumber,
             PageSize = parameters.PageSize,
            
            };
        }
        public async Task<ProductDtos?> GetByIdAsync(Guid id)
        {
            var p = await _db.Products.FindAsync(id);
            return p is null ? null : new ProductDtos(p.Id, p.Name, p.Sku, p.Price, p.Quantity, p.CreatedAtUtc);

        }
        public async Task<ProductDtos> CreateAsync(CreatedProductRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentNullException("Name is required");
            }
            if (request.Price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            if (request.Quantity < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            var product = new Product
            {
                Name = request.Name.Trim(),
                Sku = string.IsNullOrWhiteSpace(request.Sku) ? null : request.Sku.Trim(),
                Price = request.Price,
                Quantity = request.Quantity,
            };
            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return new ProductDtos(
                product.Id,
                product.Name,
                product.Sku,
                product.Price,
                product.Quantity,
                product.CreatedAtUtc);
        }
        public async Task<ProductDtos?> UpdateAsync(Guid id, UpdateProductRequest request)
        {
            var product = await _db.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (product == null) { return null; };
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Name is Required");
            }
            product.Name = request.Name.Trim();
            product.Sku = string.IsNullOrWhiteSpace(request.Sku) ? null : request.Sku.Trim();
            product.Price = request.Price;
            product.Quantity = request.Quantity;

            await _db.SaveChangesAsync();

            return new ProductDtos(
                product.Id,
                product.Name,
                product.Sku,
                product.Price,
                product.Quantity,
                product.CreatedAtUtc);
        }
        public async Task<bool> DeleteAsync(Guid id) {
            var product = await _db.Products.FindAsync(id);
            if(product is null) { return false; }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        
        }
    }
}
