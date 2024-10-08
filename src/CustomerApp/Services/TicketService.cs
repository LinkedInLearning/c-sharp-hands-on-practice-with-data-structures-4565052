using CustomerApp.Models;

namespace CustomerApp.Services
{
  public class TicketService
  {
    private readonly List<Ticket> _ticketQueue = new();

    public List<Ticket> GetAllTickets()
    {
      AutoUpgradePriority();
      return _ticketQueue
          .OrderBy(t => GetPriorityValue(t.Priority)) // high, medium, low
          .ThenBy(t => t.CreatedAt) // oldest first within same priority
          .ToList();
    }

    private int GetPriorityValue(string priority)
    {
      return priority switch
      {
        "high" => 1,
        "medium" => 2,
        "low" => 3,
        _ => 4 // If priority is not recognized, put it last
      };
    }

    public Ticket GetHighestPriorityTicket()
    {
      return _ticketQueue
          .Where(t => t.Status == "open" || t.Status == "in-progress")
          .OrderByDescending(t => t.Priority)
          .ThenBy(t => t.CreatedAt) // Sort by priority and time of arrival
          .FirstOrDefault();
    }

    public void AddTicket(Ticket newTicket)
    {
      newTicket.Id = Guid.NewGuid().ToString();
      _ticketQueue.Add(newTicket);
    }

    public bool UpdateStatus(string id, string newStatus)
    {
      var ticket = _ticketQueue.FirstOrDefault(t => t.Id == id);
      if (ticket != null)
      {
        ticket.Status = newStatus;
        return true;
      }
      return false;
    }

    public bool UpgradePriority(string id)
    {
      var ticket = _ticketQueue.FirstOrDefault(t => t.Id == id);
      if (ticket != null && ticket.Priority != "high")
      {
        if (ticket.Priority == "low")
        {
          ticket.Priority = "medium";
        }
        else if (ticket.Priority == "medium")
        {
          ticket.Priority = "high";
        }
        return true;
      }
      return false;
    }

    public void AutoUpgradePriority()
    {
      foreach (var ticket in _ticketQueue)
      {
        var timeSinceCreated = DateTime.UtcNow - ticket.CreatedAt;

        // After 10 seconds, upgrade low to medium, medium to high
        if (timeSinceCreated.TotalSeconds > 10 && ticket.Priority == "low")
        {
          ticket.UpdatePriority("medium");
        }
        else if (timeSinceCreated.TotalSeconds > 20 && ticket.Priority == "medium")
        {
          ticket.UpdatePriority("high");
        }
      }
    }
  }
}
