using ShoppingCartApp.Models;

namespace ShoppingCartApp.Services
{
  public class CartService
  {
    private readonly List<CartItem> _cart = new();
    public IEnumerable<CartItem> GetAll()
    {
      return _cart;
    }

    public CartItem AddToCart(Product product)
    {
      var existingItem = _cart.FirstOrDefault(i => i.ProductName == product.Name);
      if (existingItem != null)
      {
        existingItem.Quantity++;
        return existingItem;
      }
      else
      {
        var newItem = new CartItem
        {
          Id = product.Id,
          ProductName = product.Name,
          Price = product.Price,
          Quantity = 1
        };
        _cart.Add(newItem);
        return newItem;
      }
    }

    public bool RemoveFromCart(int id)
    {
      var item = _cart.FirstOrDefault(i => i.Id == id);
      if (item != null)
      {
        item.Quantity--;
        if (item.Quantity == 0)
        {
          _cart.Remove(item);
        }
        return true;
      }
      else
      {
        return false;
      }
    }

    public decimal GetCartTotal()
    {
      return _cart.Sum(i => i.TotalPrice);
    }
  }
}