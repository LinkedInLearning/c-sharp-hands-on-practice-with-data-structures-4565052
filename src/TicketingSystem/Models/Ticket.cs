namespace TicketingSystem.Models
{
  public enum TicketPriority
  {
    High = 1,
    Medium = 2,
    Low = 3
  }

  public class Ticket
  {
    public string Owner { get; set; }
    public string IssueDescription { get; set; }
    public TicketPriority Priority { get; set; }
    public string PriorityAsString => Priority.ToString();
  }
}
