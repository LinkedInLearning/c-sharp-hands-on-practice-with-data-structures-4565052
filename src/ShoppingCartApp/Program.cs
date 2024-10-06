using ShoppingCartApp.Models;
using ShoppingCartApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CartService>();
builder.Services.AddSingleton<ProductService>();

var app = builder.Build();

app.UseStaticFiles();

// Get all available products
app.MapGet("/api/products", (ProductService productService) =>
    productService.GetAllProducts());

// Add a product to the cart
app.MapPost("/api/cart/{productId}", (CartService cartService, ProductService productService, int productId) =>
{
  var product = productService.GetProductById(productId);
  if (product == null)
  {
    return Results.NotFound();
  }

  var cartItem = cartService.AddToCart(product);
  return Results.Created($"/api/cart/{cartItem.Id}", cartItem);
});

// Get all items in the cart
app.MapGet("/api/cart", (CartService cartService) =>
    cartService.GetAll());

// Remove an item from the cart
app.MapDelete("/api/cart/{id}", (CartService cartService, int id) =>
{
  if (cartService.RemoveFromCart(id))
  {
    return Results.NoContent();
  }
  return Results.NotFound();
});

app.MapGet("/api/cart/total", (CartService cartService) =>
{
  var total = cartService.GetCartTotal();
  return Results.Ok(total);
});

app.MapFallbackToFile("index.html");

app.Run();