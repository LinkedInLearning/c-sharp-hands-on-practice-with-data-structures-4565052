using System;
using System.Collections.Generic;

namespace FlightReservationSystem.Models
{

  public class Flight
  {
    public string FlightNumber { get; }
    public string Destination { get; }
    public int TotalSeats { get; }
    private /* TODO: Add data structure */  _passengers;
    private /* TODO: Add data structure */ > _waitlist;

    public Flight(string flightNumber, string destination, int totalSeats)
    {
      FlightNumber = flightNumber;
      Destination = destination;
      TotalSeats = totalSeats;
      _passengers = /* Initialize passengers attribute */
      _waitlist = /* Initialize waitlist attribute */
    }

    public bool BookSeat(Passenger passenger)
    {

    }

    public void AddToWaitlist(Passenger passenger)
    {

    }

    public /* TODO: Add data structure */ Passengers => _passengers;

    public /* TODO: Add data structure */ Waitlist => _waitlist;
  }
}