using InventoryApp.Models;

namespace InventoryApp.Services
{
  public class InventoryService
  {
    private readonly Dictionary<string, InventoryItem> _inventory = new();

    public IEnumerable<InventoryItem> GetAll()
    {
      return _inventory.Values;
    }

    public InventoryItem GetByProductCode(string productCode)
    {
      _inventory.TryGetValue(productCode, out var item);
      return item;
    }

    public bool Add(InventoryItem newItem)
    {
      if (_inventory.ContainsKey(newItem.ProductCode))
      {
        return false;
      }
      _inventory[newItem.ProductCode] = newItem;
      return true;
    }

    public bool UpdateQuantity(string productCode, int newQuantity)
    {
      if (_inventory.TryGetValue(productCode, out var item))
      {
        item.Quantity = newQuantity;
        return true;
      }
      return false;
    }

    public bool RemoveOne(string productCode)
    {
      if (_inventory.TryGetValue(productCode, out var item))
      {
        if (item.Quantity > 1)
        {
          item.Quantity--;
        }
        else
        {
          _inventory.Remove(productCode);
        }
        return true;
      }
      return false; 
    }
  }
}