namespace CustomerApp.Models
{
  public class Ticket
  {
    public string Id { get; set; }
    public string CustomerName { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } // open, in-progress, or closed
    public string Priority { get; set; } // low, medium, or high
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdated { get; set; }

    public Ticket(string customerName, string description, string priority)
    {
      Id = Guid.NewGuid().ToString();
      CustomerName = customerName;
      Description = description;
      Status = "open"; // default status
      Priority = priority; // low, medium, or high
      CreatedAt = DateTime.UtcNow;
      LastUpdated = CreatedAt;
    }

    public void UpdateStatus(string newStatus)
    {
      Status = newStatus;
      LastUpdated = DateTime.UtcNow;
    }

    public void UpdatePriority(string newPriority)
    {
      Priority = newPriority;
      LastUpdated = DateTime.UtcNow;
    }
  }
}
