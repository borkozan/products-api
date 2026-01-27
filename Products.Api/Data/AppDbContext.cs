using Microsoft.EntityFrameworkCore;
using Products.Api.Models;
namespace Products.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Product> Products => Set<Product>();
}