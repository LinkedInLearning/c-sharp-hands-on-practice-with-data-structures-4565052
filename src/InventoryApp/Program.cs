using InventoryApp.Models;
using InventoryApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InventoryService>();

var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/api/inventory", (InventoryService inventoryService) =>
{
  return inventoryService.GetAll();
});

app.MapGet("/api/inventory/{productCode}", (InventoryService inventoryService, string productCode) =>
{
  var item = inventoryService.GetByProductCode(productCode);
  return item != null ? Results.Ok(item) : Results.NotFound();
});

app.MapPost("/api/inventory", (InventoryService inventoryService, InventoryItem newItem) =>
{
  if (inventoryService.Add(newItem))
  {
    return Results.Created($"/api/inventory/{newItem.ProductCode}", newItem);
  }
  return Results.Conflict("Item with this product code already exists.");
});

app.MapPut("/api/inventory/{productCode}/quantity", (InventoryService inventoryService, string productCode, int quantity) =>
{
  if (inventoryService.UpdateQuantity(productCode, quantity))
  {
    return Results.Ok();
  }
  return Results.NotFound("Item not found.");
});

// Delete an item from the inventory
app.MapDelete("/api/inventory/{productCode}", (InventoryService inventoryService, string productCode) =>
{
  if (inventoryService.Delete(productCode))
  {
    return Results.NoContent();
  }
  return Results.NotFound("Item not found.");
});

app.Run();