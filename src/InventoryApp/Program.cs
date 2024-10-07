using InventoryApp.Models;
using InventoryApp.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InventoryService>();
builder.Services.AddSingleton<CartService>();

var app = builder.Build();

app.UseStaticFiles();

// Inventory management endpoints
app.MapGet("/api/inventory", (InventoryService inventoryService) =>
{
  return inventoryService.GetAll();
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

// Shopping cart endpoints
app.MapGet("/api/cart", (CartService cartService) =>
{
  return cartService.GetAll();
});

app.MapPost("/api/cart", (CartService cartService, InventoryService inventoryService, [FromQuery] string productCode) =>
{
  // TODO: Add item to cart and remove from inventory
  return Results.NotFound("Item not available or out of stock.");
});

app.MapDelete("/api/cart/{productCode}", (CartService cartService, InventoryService inventoryService, string productCode) =>
{
  // TODO: Remove item from cart and restock inventory
  return Results.NotFound("Item not found in cart.");
});

// Fallback to serve the HTML page
app.MapFallbackToFile("index.html");

app.Run();
