using Microsoft.AspNetCore.Http.HttpResults;
using Terrasense.Domain.Models;

namespace Terrasense.Api;

public static class TerrasenseEndpoints
{
  public static void MapTerrasenseEndpoints(this WebApplication app)
  {

    app.MapGet("/api/sensor-readings", GetSensorReadings);
    app.MapPost("/api/sensor-readings", AddSensorReading);

  }

  private static IResult GetSensorReadings()
  {
    return null; //placeholder
  }

  private static IResult AddSensorReading(SensorReading reading)
  {
    return null; //placeholder
  }
}
