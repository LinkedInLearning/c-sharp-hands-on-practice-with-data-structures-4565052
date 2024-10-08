using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TrainSystem.Models;
using TrainSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TrainService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/tracks", (TrainService trainService) =>
{
  var tracks = trainService.GetAllTracks();
  return Results.Json(tracks);
});

app.MapGet("/queue", (TrainService trainService) =>
{
  var nextTrain = trainService.GetAllTrains();
  return Results.Json(nextTrain);
});

app.MapPost("/arrive", (TrainService trainService, Train newTrain) =>
{
  trainService.ArriveTrain(newTrain);
  return Results.Ok();
});

app.MapPost("/assign", (TrainService trainService) =>
{
  trainService.AssignNextTrainToTrack();
  return Results.Ok();
});

app.MapPost("/depart", (TrainService trainService, int trackId) =>
{
  var track = trainService.GetAllTracks().FirstOrDefault(t => t.Id == trackId);
  if (track != null)
  {
    trainService.DepartTrain(track);
    return Results.Ok();
  }
  return Results.NotFound();
});

app.Run();