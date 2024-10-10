using System;
using System.Collections.Generic;

namespace FlightReservationSystem.Models
{

  public class Flight
  {
    public string FlightNumber { get; }
    public string Destination { get; }
    public int TotalSeats { get; }
    private List<Passenger> _passengers;
    private Queue<Passenger> _waitlist;

    public Flight(string flightNumber, string destination, int totalSeats)
    {
      FlightNumber = flightNumber;
      Destination = destination;
      TotalSeats = totalSeats;
      _passengers = new List<Passenger>();
      _waitlist = new Queue<Passenger>();
    }

    public bool BookSeat(Passenger passenger)
    {
      if (_passengers.Count < TotalSeats)
      {
        _passengers.Add(passenger); // Add passenger to the flight
        return true;
      }
      return false; // No available seats
    }

    public void AddToWaitlist(Passenger passenger)
    {
      _waitlist.Enqueue(passenger); // Add passenger to the waitlist
    }

    public int AvailableSeats => TotalSeats - _passengers.Count;

    public List<Passenger> Passengers => _passengers; // Property to get booked passengers

    public Queue<Passenger> Waitlist => _waitlist; // Property to get the waitlist
  }
}