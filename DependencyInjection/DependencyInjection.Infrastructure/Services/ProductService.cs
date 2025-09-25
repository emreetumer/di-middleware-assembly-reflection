using DependencyInjection.Application;
using DependencyInjection.Domain;
using DependencyInjection.Infrastructure.Context;

namespace DependencyInjection.Infrastructure.Services;
public sealed class ProductService : IProductService
{
    public void Create(string name)
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        Product product = new Product()
        {
            Name = name
        };
        applicationDbContext.Products.Add(product);
        applicationDbContext.SaveChanges();
    }
}
