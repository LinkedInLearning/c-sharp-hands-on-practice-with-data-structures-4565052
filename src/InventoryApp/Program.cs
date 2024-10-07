using InventoryApp.Models;
using InventoryApp.Services;
using InventoryApp.Converters;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InventoryService>();
builder.Services.AddSingleton<CartService>();

var app = builder.Build();
var cartItemToInventoryItemConverter = new CartItemToInventoryItemConverter();

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
  var item = inventoryService.GetByProductCode(productCode);
  if (item != null && item.Quantity > 0)
  {
    cartService.AddToCart(item);
    inventoryService.RemoveOne(productCode);
    return Results.Ok(cartService.GetAll());
  }
  return Results.NotFound("Item not available or out of stock.");
});

app.MapDelete("/api/cart/{productCode}", (CartService cartService, InventoryService inventoryService, string productCode) =>
{
  var cartItemRemoved = cartService.RemoveFromCart(productCode);
  if (cartItemRemoved != null)
  {
    var inventoryItem = cartItemToInventoryItemConverter.Convert(cartItemRemoved);
    inventoryItem.Quantity = 1;
    inventoryService.Add(inventoryItem);
  }
  return Results.Ok(cartService.GetAll());
});

// Fallback to serve the HTML page
app.MapFallbackToFile("index.html");

app.Run();
