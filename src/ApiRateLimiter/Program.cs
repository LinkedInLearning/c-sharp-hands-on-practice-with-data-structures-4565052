using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles();

var rateLimiter = new ApiRateLimiter(10, TimeSpan.FromMinutes(1));

app.MapGet("/api/RateLimiter/{userId}", (string userId) =>
{
  bool allowed = rateLimiter.IsRequestAllowed(userId);

  if (allowed)
  {
    return Results.Ok(new { message = "Request Allowed", success = true });
  }
  else
  {
    var errorResponse = new
    {
      message = "Rate limit exceeded. Try again later.",
      success = false
    };
    return Results.Json(errorResponse, statusCode: 429);
  }
});

app.MapFallbackToFile("index.html");

app.Run();