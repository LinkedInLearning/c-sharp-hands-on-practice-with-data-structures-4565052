using TodoListApp.Models;
using TodoListApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TodoService>();

var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/api/todos", (TodoService todoService) => todoService.GetAll());

app.MapPost("/api/todos", (TodoService todoService, TodoItem todoItem) =>
{
  todoService.Add(todoItem);
  return Results.Created($"/api/todos/{todoItem.Id}", todoItem);
});

app.MapDelete("/api/todos/{id}", (TodoService todoService, int id) =>
{
  todoService.Delete(id);
  return Results.NoContent();
});

app.MapFallbackToFile("index.html");

app.Run();