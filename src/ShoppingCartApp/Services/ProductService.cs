using ShoppingCartApp.Models;

namespace ShoppingCartApp.Services
{
  public class ProductService
  {
    private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200.00M },
            new Product { Id = 2, Name = "Smartphone", Price = 800.00M },
            new Product { Id = 3, Name = "Headphones", Price = 150.00M },
            new Product { Id = 4, Name = "Keyboard", Price = 70.00M },
            new Product { Id = 5, Name = "Monitor", Price = 300.00M }
        };

    public IEnumerable<Product> GetAllProducts()
    {
      return _products;
    }

    public Product GetProductById(int id)
    {
      return _products.FirstOrDefault(p => p.Id == id);
    }
  }
}