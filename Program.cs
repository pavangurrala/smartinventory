using SmartInventory.Api.Endpoints;
using SmartInventory.Api.Services;
using SmartInventory.Api.Data;
using Microsoft.EntityFrameworkCore;
using SmartInventory.Api.Middlewares;
using Microsoft.AspNetCore.HttpOverrides;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAuthorization();
//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sql"));
});
var app = builder.Build();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedProto,
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Staging"))
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}


app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

//app.MapControllers();

app.MapProductEndpoints();

app.Run();
