using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using FlightReservationSystem.Models;
using FlightReservationSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();

var flightReservationService = new FlightReservationService();

flightReservationService.AddFlight(new Flight("AA123", "New York", 2));
flightReservationService.AddFlight(new Flight("BB456", "Los Angeles", 3));

app.MapPost("/api/flights/book", (FlightBookingRequest request) =>
{
  var passenger = new Passenger(request.PassengerName, request.PassengerEmail);
  BookingStatus bookingStatus = flightReservationService.BookFlight(request.FlightNumber, passenger);

  return bookingStatus switch
  {
    BookingStatus.BookedOnFlight => Results.Ok(new { message = "Booking successful. You are booked on the flight.", status = bookingStatus.ToString() }),
    BookingStatus.AddedToWaitlist => Results.Ok(new { message = "Flight is full. You are added to the waitlist.", status = bookingStatus.ToString() }),
    _ => Results.BadRequest(new { message = "Booking failed. Bad request.", status = BookingStatus.NotBooked.ToString() })
  };
});


app.MapGet("/api/flights/{flightNumber}/bookings", (string flightNumber) =>
{
  var flight = flightReservationService.GetFlight(flightNumber);
  return flight != null ? Results.Ok(flight.Passengers) : Results.NotFound();
});

app.MapGet("/api/flights/{flightNumber}/waitlist", (string flightNumber) =>
{
  var flight = flightReservationService.GetFlight(flightNumber);
  return flight != null ? Results.Ok(flight.Waitlist) : Results.NotFound();
});

app.MapGet("/api/flights", () =>
{
  var flights = flightReservationService.GetAllFlights();
  return Results.Ok(flights);
});

app.MapFallbackToFile("index.html");

app.Run();


