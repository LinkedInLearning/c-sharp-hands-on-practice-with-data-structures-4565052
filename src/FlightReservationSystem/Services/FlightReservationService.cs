using FlightReservationSystem.Models;
using System.Collections.Generic;

namespace FlightReservationSystem.Services
{
  public class FlightReservationService
  {
    private Dictionary<string, Flight> _flights = new();

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
      return BookingStatus.NotBooked;
    }
  }
}