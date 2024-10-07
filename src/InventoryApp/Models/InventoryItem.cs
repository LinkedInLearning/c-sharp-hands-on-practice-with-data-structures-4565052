namespace InventoryApp.Models
{
  public class InventoryItem
  {
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public InventoryItem(string productCode, string name,
      string description, int quantity, decimal price)
    {
      ProductCode = productCode;
      Name = name;
      Description = description;
      Quantity = quantity;
      Price = price;
    }
  }
}
