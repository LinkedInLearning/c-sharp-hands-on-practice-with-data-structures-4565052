using ShoppingCartApp.Models;

namespace ShoppingCartApp.Services
{
  public class CartService
  {

    public IEnumerable<CartItem> GetAll()
    {
      return null;
    }

    public CartItem AddToCart(Product product)
    {
      return null;
    }

    public bool RemoveFromCart(int id)
    {
      return false;
    }

    public decimal GetCartTotal()
    {
      return 0;
    }
  }
}