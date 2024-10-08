using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TicketingSystem.Models;
using TicketingSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TicketService>();

var app = builder.Build();
app.UseStaticFiles();

app.MapPost("/ticket/add", (Ticket ticket, TicketService ticketService) =>
{
  ticketService.AddTicket(ticket);
  return Results.Ok(ticket);
});

app.MapGet("/ticket/next", (TicketService ticketService) =>
{
  var nextTicket = ticketService.GetNextTicket();
  return nextTicket != null ? Results.Ok(nextTicket) : Results.NotFound("No tickets available.");
});

app.MapDelete("/ticket/dequeue", (TicketService ticketService) =>
{
  var ticket = ticketService.DequeueTicket();
  return ticket != null ? Results.Ok(ticket) : Results.NotFound("No tickets available to dequeue.");
});

app.MapFallbackToFile("index.html");


app.Run();
