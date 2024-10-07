using ShoppingCartApp.Models;

namespace ShoppingCartApp.Services
{
  public class CartService
  {
    private readonly List<CartItem> _cart = new();

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