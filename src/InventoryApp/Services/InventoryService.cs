using InventoryApp.Models;

namespace InventoryApp.Services
{
  public class InventoryService
  {
    private readonly Dictionary<string, InventoryItem> _inventory = new();

    // Retrieve all items in the inventory
    public IEnumerable<InventoryItem> GetAll()
    {
      return _inventory.Values;
    }

    // Retrieve a specific item by product code
    public InventoryItem GetByProductCode(string productCode)
    {
      _inventory.TryGetValue(productCode, out var item);
      return item;
    }

    // Add a new item to the inventory
    public bool Add(InventoryItem newItem)
    {
      if (_inventory.ContainsKey(newItem.ProductCode))
      {
        return false; // Item with this product code already exists
      }
      _inventory[newItem.ProductCode] = newItem;
      return true;
    }

    // Update the quantity of an existing item
    public bool UpdateQuantity(string productCode, int newQuantity)
    {
      if (_inventory.TryGetValue(productCode, out var item))
      {
        item.Quantity = newQuantity;
        return true;
      }
      return false; // Item not found
    }

    // Remove one quantity of the item; remove the item if quantity becomes zero
    public bool RemoveOne(string productCode)
    {
      if (_inventory.TryGetValue(productCode, out var item))
      {
        if (item.Quantity > 1)
        {
          item.Quantity--; // Decrease the quantity by one
        }
        else
        {
          _inventory.Remove(productCode); // Remove the item completely if quantity is zero
        }
        return true;
      }
      return false; // Item not found
    }
  }
}