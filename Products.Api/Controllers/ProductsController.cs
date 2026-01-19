using Microsoft.AspNetCore.Mvc;
using Products.Api.Models;

namespace Products.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> AllProducts = new()
    {
        new Product
        {
            Id = 1,
            Title = "iPhone 15",
            Description = "Latest Apple smartphone",
            Price = 999.99m,
            Thumbnail = "https://dummyjson.com/image/i/products/1/thumbnail.jpg"
        },
        new Product
        {
            Id = 2,
            Title = "MacBook Pro",
            Description = "Apple laptop for professionals",
            Price = 1999.99m,
            Thumbnail = "https://dummyjson.com/image/i/products/6/thumbnail.png"
        },
        new Product
        {
            Id = 3,
            Title = "Samsung Galaxy S24",
            Description = "Flagship Android phone",
            Price = 899.99m,
            Thumbnail = "https://dummyjson.com/image/i/products/3/thumbnail.jpg"
        }
    };
    
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts(
        [FromQuery] int page = 1,
        [FromQuery] int limit = 12,
        [FromQuery] string? search = null
    )
    {
        var query = AllProducts.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p =>
                p.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                p.Description.Contains(search, StringComparison.OrdinalIgnoreCase));
        }
        var totalItems = query.Count();
        var products = query
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToList();
        return Ok(
            new {
                page,
                limit,
                totalItems,
                products
            }
        );
    }
}