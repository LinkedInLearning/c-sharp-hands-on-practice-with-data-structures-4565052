using CustomerApp.Models;
using CustomerApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<TicketService>();

var app = builder.Build();

app.UseStaticFiles();

// API to get all tickets
app.MapGet("/api/tickets", (TicketService ticketService) =>
{
  return Results.Ok(ticketService.GetAllTickets());
});

// API to add a new ticket
app.MapPost("/api/tickets", (TicketService ticketService, Ticket ticket) =>
{
  Ticket newTicket = new Ticket(ticket.CustomerName, ticket.Description, ticket.Priority);
  ticketService.AddTicket(newTicket);
  return Results.Created($"/api/tickets/{newTicket.Id}", newTicket);
});

// API to update the status of a ticket
app.MapPut("/api/tickets/{id}/status/{status}", (TicketService ticketService, string id, string status) =>
{
  var updated = ticketService.UpdateStatus(id, status);
  if (updated)
  {
    return Results.Ok();
  }
  return Results.NotFound("Ticket not found");
});

// API to upgrade the priority of a ticket
app.MapPut("/api/tickets/{id}/priority", (TicketService ticketService, string id) =>
{
  var upgraded = ticketService.UpgradePriority(id);
  if (upgraded)
  {
    return Results.Ok();
  }
  return Results.NotFound("Ticket not found");
});

app.MapFallbackToFile("index.html");

app.Run();