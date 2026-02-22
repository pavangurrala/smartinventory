using Microsoft.EntityFrameworkCore;
using SmartInventory.Api.Dtos;
using SmartInventory.Api.Dtos.Queries;
using SmartInventory.Api.Services;

namespace SmartInventory.Api.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            app.MapGet("/api/products", async ([AsParameters] ProductQueryParameters parameters ,IProductService service) => {
                var result = await service.GetAsync(parameters);
                return Results.Ok(result);
            });
            app.MapGet("/api/products/{id:guid}", async (Guid id, IProductService service) => {

                var product = await service.GetByIdAsync(id);
                return product is null? Results.NotFound(): Results.Ok(product);
            });

            app.MapPost("/api/products", async (CreatedProductRequest req, IProductService service) => {
                
                    var result = await service.CreateAsync(req);
                    return Results.Created($"/api/products/{result.Id}", result);
            });
            app.MapPut("/api/products/{id:guid}", async(Guid id, UpdateProductRequest req, IProductService service) =>
            {
                try
                {
                    var result = await service.UpdateAsync(id, req);
                    return result is null ? Results.NotFound() : Results.Ok(result);
                }
                catch(ArgumentException ex) 
                {
                    return Results.BadRequest(new {error = ex.Message });
                }
            });
            app.MapDelete("/api/products/{id:guid}", async(Guid id, IProductService service) =>
            {
                var deleted = await service.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            });

        }
    }
}
