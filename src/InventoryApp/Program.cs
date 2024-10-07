using InventoryApp.Models;
using InventoryApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InventoryService>();

var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", () => Results.Redirect("/index.html"));

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
  inventoryService.Add(newItem);
  return Results.Created($"/api/inventory/{newItem.ProductCode}", newItem);
});

app.MapDelete("/api/inventory/{productCode}", (InventoryService inventoryService, string productCode) =>
{
  inventoryService.RemoveOne(productCode);
  return Results.NoContent();
});

app.MapFallbackToFile("index.html");

app.Run();