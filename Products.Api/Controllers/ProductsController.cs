using Microsoft.AspNetCore.Mvc;
using Products.Api.Models;

namespace Products.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        var products = new List<Product>
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
            }
        };

        return Ok(products);
    }
}