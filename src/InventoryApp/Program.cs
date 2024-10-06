using InventoryApp.Models;
using InventoryApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InventoryService>();

var app = builder.Build();

app.UseStaticFiles(); // Serve static files from wwwroot

// Map root URL to index.html
app.MapGet("/", () => Results.Redirect("/index.html"));

// Get all items in the inventory
app.MapGet("/api/inventory", (InventoryService inventoryService) =>
{
  return inventoryService.GetAll();
});

// Get a specific item by product code
app.MapGet("/api/inventory/{productCode}", (InventoryService inventoryService, string productCode) =>
{
  var item = inventoryService.GetByProductCode(productCode);
  return item != null ? Results.Ok(item) : Results.NotFound();
});

// Add a new item to the inventory
app.MapPost("/api/inventory", (InventoryService inventoryService, InventoryItem newItem) =>
{
  if (inventoryService.Add(newItem))
  {
    return Results.Created($"/api/inventory/{newItem.ProductCode}", newItem);
  }
  return Results.Conflict("Item with this product code already exists.");
});

// Update the quantity of an existing item
app.MapPut("/api/inventory/{productCode}/quantity", (InventoryService inventoryService, string productCode, int quantity) =>
{
  if (inventoryService.UpdateQuantity(productCode, quantity))
  {
    return Results.Ok();
  }
  return Results.NotFound("Item not found.");
});

// Remove one unit of an item or the item itself if quantity reaches zero
app.MapDelete("/api/inventory/{productCode}", (InventoryService inventoryService, string productCode) =>
{
  if (inventoryService.RemoveOne(productCode))
  {
    return Results.NoContent();
  }
  return Results.NotFound("Item not found.");
});

app.MapFallbackToFile("index.html"); // Serve index.html for all other routes

app.Run();