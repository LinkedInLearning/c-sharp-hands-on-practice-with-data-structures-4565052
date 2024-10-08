using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Text.Json;
using TextEditorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Register TextEditorService as a singleton
builder.Services.AddSingleton<TextEditorService>();

var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/getText", async (TextEditorService textEditorService) =>
{
  var response = new { text = textEditorService.GetText() };
  return Results.Json(response);
});

app.MapPost("/saveText", async (HttpContext context, TextEditorService textEditorService) =>
{
  var requestBody = await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(context.Request.Body);
  if (requestBody != null && requestBody.ContainsKey("text"))
  {
    textEditorService.SaveText(requestBody["text"]);
    return Results.Ok();
  }
  return Results.BadRequest();
});

app.MapPost("/clearText", (TextEditorService textEditorService) =>
{
  textEditorService.ClearText();
  return Results.Ok();
});

app.MapPost("/undo", (TextEditorService textEditorService) =>
{
  var success = textEditorService.Undo();
  return success ? Results.Ok() : Results.BadRequest();
});

app.MapPost("/redo", (TextEditorService textEditorService) =>
{
  var success = textEditorService.Redo();
  return success ? Results.Ok() : Results.BadRequest();
});

app.MapFallbackToFile("index.html");

app.Run();
