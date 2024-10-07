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

    public void Add(InventoryItem newItem)
    {
      if (_inventory.TryGetValue(newItem.ProductCode, out var item))
      {
        item.Quantity = item.Quantity + newItem.Quantity;
      }
      else
      {
        _inventory[newItem.ProductCode] = newItem;
      }
    }

    public void RemoveOne(string productCode)
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
      }
    }
  }
}
