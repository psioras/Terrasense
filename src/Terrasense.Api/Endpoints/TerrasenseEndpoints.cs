using Microsoft.AspNetCore.Http.HttpResults;
using Terrasense.Domain.Models;
using Terrasense.Infrastructure.Interfaces;

namespace Terrasense.Api.Endpoints;

public static class TerrasenseEndpoints
{
  public static void MapTerrasenseEndpoints(this WebApplication app)
  {

    app.MapGet("/api/sensor-readings", GetSensorReadings);
    app.MapPost("/api/sensor-readings", AddSensorReading);

  }

  private static async Task<IResult> GetSensorReadings(ITerrasenseService service, string? sensorId, DateTime? from = null, DateTime? to = null)
  {
    var result = await service.GetReadingsAsync(sensorId, from, to);
    return Results.Ok(result);
  }

  private static async Task<IResult> AddSensorReading(ITerrasenseService service, SensorReading reading)
  {
    //Does it need [FromBody] attribute? I think it should work without it, but we can add it if needed.
    var result = await service.AddReadingAsync(reading);
    return Results.Created($"/api/sensor-readings/{result.Id}", result);
  }
}
