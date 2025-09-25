using DependencyInjection.Domain;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.Infrastructure.Context;
public sealed class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDb");
    }

    public DbSet<Product> Products { get; set; }
}
