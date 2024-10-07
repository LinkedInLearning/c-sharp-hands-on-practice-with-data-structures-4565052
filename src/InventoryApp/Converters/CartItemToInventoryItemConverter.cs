using InventoryApp.Models;

namespace InventoryApp.Converters
{
  public class CartItemToInventoryItemConverter
  {
    public InventoryItem Convert(CartItem cartItem)
    {
      return new InventoryItem(cartItem.Id, cartItem.ProductName, cartItem.Description, cartItem.Quantity, cartItem.Price);
    }
  }
}