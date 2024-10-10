using FlightReservationSystem.Models;

namespace FlightReservationSystem.Services
{
  public class FlightReservationService
  {
    private Dictionary<string, Flight> _flights;

    public FlightReservationService()
    {
      _flights = new Dictionary<string, Flight>();
    }

    public IEnumerable<Flight> GetAllFlights()
    {
      return _flights.Values;
    }

    public Flight GetFlight(String flightNumber)
    {
      if (_flights.TryGetValue(flightNumber, out Flight flight))
      {
        return flight;
      }
      return null;
    }

    public void AddFlight(Flight flight)
    {
      _flights[flight.FlightNumber] = flight;
    }

    public BookingStatus BookFlight(string flightNumber, Passenger passenger)
    {
      if (_flights.ContainsKey(flightNumber))
      {
        var flight = _flights[flightNumber];
        if (flight.BookSeat(passenger))
        {
          return BookingStatus.BookedOnFlight;
        }
        else
        {
          flight.AddToWaitlist(passenger);
          return BookingStatus.AddedToWaitlist;
        }
      }
      return BookingStatus.BadRequest;
    }

    public void ShowBookings(string flightNumber)
    {
      if (_flights.TryGetValue(flightNumber, out var flight))
      {
        Console.WriteLine($"Current Bookings for flight {flightNumber}:");
        foreach (var passenger in flight.Passengers)
        {
          Console.WriteLine($"Passenger: {passenger.Name}");
        }
      }
      else
      {
        Console.WriteLine("Flight not found.");
      }
    }

    public void ShowWaitlist(string flightNumber)
    {
      if (_flights.TryGetValue(flightNumber, out var flight))
      {
        Console.WriteLine($"Current Waitlist for flight {flightNumber}:");
        foreach (var waitlistedPassenger in flight.Waitlist)
        {
          Console.WriteLine($"Passenger: {waitlistedPassenger.Name}");
        }
      }
      else
      {
        Console.WriteLine("Flight not found.");
      }
    }

    public void CheckWaitlist(string flightNumber)
    {
      if (_flights.TryGetValue(flightNumber, out var flight))
      {
        while (flight.Waitlist.Count > 0)
        {
          var nextInQueue = flight.Waitlist.Dequeue();
          if (flight.BookSeat(nextInQueue))
          {
            Console.WriteLine($"Successfully booked {nextInQueue.Name} from waitlist on flight {flightNumber}.");
          }
          else
          {
            // If no seats are available, they remain in the waitlist
            flight.AddToWaitlist(nextInQueue);
            break;
          }
        }
      }
      else
      {
        Console.WriteLine("Flight not found.");
      }
    }
  }
}