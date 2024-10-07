using InventoryApp.Models;

namespace InventoryApp.Services
{
  public class CartService
  {
    private readonly List<CartItem> _cart = new();

    public IEnumerable<CartItem> GetAll()
    {
      return _cart;
    }

    public CartItem AddToCart(InventoryItem product)
    {
      var existingItem = _cart.FirstOrDefault(i => i.Id.Equals(product.ProductCode));

      if (existingItem != null)
      {
        existingItem.Quantity++;
        return existingItem;
      }
      else
      {
        var newItem = new CartItem
        {
          Id = product.ProductCode,
          ProductName = product.Name,
          Description = product.Description,
          Price = product.Price,
          Quantity = 1
        };
        _cart.Add(newItem);
        return newItem;
      }
    }
    public CartItem RemoveFromCart(string id)
    {
      var item = _cart.FirstOrDefault(i => i.Id.Equals(id));
      if (item != null)
      {
        item.Quantity--;

        if (item.Quantity == 0)
        {
          _cart.Remove(item);
        }
      }
      return item;
    }

    public decimal GetCartTotal()
    {
      return _cart.Sum(i => i.TotalPrice);
    }
  }
}

