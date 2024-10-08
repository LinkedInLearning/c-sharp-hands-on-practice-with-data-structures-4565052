using TicketingSystem.Models;
namespace TicketingSystem.Services
{
  public class TicketService
  {
    private readonly Queue<Ticket> _highPriorityQueue = new Queue<Ticket>();
    private readonly Queue<Ticket> _mediumPriorityQueue = new Queue<Ticket>();
    private readonly Queue<Ticket> _lowPriorityQueue = new Queue<Ticket>();

    public TicketService()
    {
    }

    public void AddTicket(Ticket ticket)
    {
      switch (ticket.Priority)
      {
        case TicketPriority.High:
          _highPriorityQueue.Enqueue(ticket);
          break;
        case TicketPriority.Medium:
          _mediumPriorityQueue.Enqueue(ticket);
          break;
        case TicketPriority.Low:
          _lowPriorityQueue.Enqueue(ticket);
          break;
      }
    }

    public Ticket GetNextTicket()
    {
      if (_highPriorityQueue.Count > 0)
      {
        return _highPriorityQueue.Peek();
      }
      else if (_mediumPriorityQueue.Count > 0)
      {
        return _mediumPriorityQueue.Peek();
      }
      else if (_lowPriorityQueue.Count > 0)
      {
        return _lowPriorityQueue.Peek();
      }
      return null;
    }

    public Ticket DequeueTicket()
    {
      if (_highPriorityQueue.Count > 0)
      {
        return _highPriorityQueue.Dequeue();
      }
      else if (_mediumPriorityQueue.Count > 0)
      {
        return _mediumPriorityQueue.Dequeue();
      }
      else if (_lowPriorityQueue.Count > 0)
      {
        return _lowPriorityQueue.Dequeue();
      }
      return null;
    }
  }
}
